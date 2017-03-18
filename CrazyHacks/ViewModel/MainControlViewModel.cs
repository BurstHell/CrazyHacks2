using CrazyHacks.Async;
using CrazyHacks.Command;
using CrazyHacks.Message;
using CrazyHacks.Model;
using Fiddler;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyHacks.Util;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Windows.Data;

namespace CrazyHacks.ViewModel
{
    public class MainControlViewModel : ViewModelBase
    {
        private AsyncObservableCollection<HttpRecord> _records;
        private AsyncObservableCollection<HttpRecord> SelectedRecords { get; set; }

        public ICollectionView RecordCollectionView {
            get { return CollectionViewSource.GetDefaultView(Records); }
        }
        public FilterConfig FilterSetting { get; set; }

        private int _count;
        private string _search;
        private string FilterDomain { get; set; }

        private string _requestTextContent;
        private string _responseTextContent;
        int iListenPort = 8080;

        const FiddlerCoreStartupFlags flags = FiddlerCoreStartupFlags.AllowRemoteClients |
            FiddlerCoreStartupFlags.CaptureLocalhostTraffic |
            FiddlerCoreStartupFlags.DecryptSSL |
            FiddlerCoreStartupFlags.MonitorAllConnections |
            FiddlerCoreStartupFlags.RegisterAsSystemProxy;

        public RelayCommand<object> IsSelected { get; private set; }

        public RelayCommand Send2XssViewModel { get; private set; }

        public RelayCommand FilterRecordCollectionView { get; private set; }
        public RelayCommand ClearFilterCollectionView { get; private set; }

        public MainControlViewModel()
        {
            Records = new AsyncObservableCollection<HttpRecord>();
            SelectedRecords = new AsyncObservableCollection<HttpRecord>();
            IsSelected = new RelayCommand<object>(i => SelectedRowChange(i));
            Send2XssViewModel = new RelayCommand(() => SendToXssViewModel());
            // Register Filter Commands
            FilterRecordCollectionView = new RelayCommand(() => FilterRecords());
            ClearFilterCollectionView = new RelayCommand(() => ClearFilters());
            FilterSetting = new FilterConfig();
            
            _requestTextContent = "[There is no Selected HttpRecord]";
            _responseTextContent = "[There is no Selected HttpRecord]";

            Messenger.Default.Register<FiddlerStateMessage>(this, ReceiveMessages);
            Messenger.Default.Register<SingleHttpRecordTransfer>(this, ReceiveRecord);
        }
        private void SendToXssViewModel()
        {
            Messenger.Default.Send(new TransferRecordMessage
            {
                records = SelectedRecords
            });
        }

        private void FilterRecords() {
            RecordCollectionView.Filter = o =>
            {
                var item = (HttpRecord)o;
                if (FilterSetting.FilterStatus200 && item.Status.ToString().StartsWith("2")) {
                    return true;
                }
                if (FilterSetting.FilterStatus300 && item.Status.ToString().StartsWith("3"))
                {
                    return true;
                }
                if (FilterSetting.FilterStatus400 && item.Status.ToString().StartsWith("4"))
                {
                    return true;
                }
                if (FilterSetting.FilterStatus500 && item.Status.ToString().StartsWith("5"))
                {
                    return true;
                }
                if (FilterSetting.FilterMimeFlash && item.MIME.ToString().Contains("shockwave-flash"))
                {
                    return true;
                }
                return false;
            };
        }
        private void ClearFilters()
        {
            // All Filters are Cleared.
            FilterSetting.Clear();
            Console.WriteLine("Check it out");

            Console.WriteLine(FilterSetting.FilterStatus200);
        }
        private void SelectedRowChange(object param)
        {
            // Before assigning SelectedRecords Collection, Clear SelectedRecords
            SelectedRecords.Clear();
            GC.Collect(); // Garbage Collect
            if (param != null) { 
                // How 2 Cast System.Windows.Controls.SelectedItemCollection to Collection
                System.Collections.IList items = (System.Collections.IList)param;
                var collection = items.Cast<HttpRecord>();
                // IEnumerable<HttpRecord> 를 AsyncObservableCollection<HttpRecord> 로 변환하는 방법?
                SelectedRecords = new AsyncObservableCollection<HttpRecord>(collection);
            }
        }

        private void ReceiveRecord(SingleHttpRecordTransfer record)
        {
            if (record.Item != null)
                Records.Add(record.Item);
        }

        public void SendToXssControl(object sender, RoutedEventArgs e)
        {
            //Get the clicked MenuItem
            var menuItem = (MenuItem)sender;

            //Get the ContextMenu to which the menuItem belongs
            var contextMenu = (ContextMenu)menuItem.Parent;

            //Find the placementTarget


            var item = (DataGrid)contextMenu.PlacementTarget;
            IList<HttpRecord> buffer = new List<HttpRecord>();
            //Get the underlying item, that you cast to your object that is bound
            //to the DataGrid (and has subject and state as property)
            foreach ( var elem in item.SelectedCells)
            {
                buffer.Add((HttpRecord)elem.Item);
            }


            //Remove the toDeleteFromBindedList object from your ObservableCollection
            Messenger.Default.Send(new TransferRecordMessage
            {
                records = buffer
            });
        }
        private object _selectedItem { get; set; }

        public object SelectedItem {
            get { return _selectedItem; }
            set {
                _selectedItem = value;
                if (_selectedItem != null ) { 
                    RequestTextContent = ((HttpRecord)_selectedItem).Request.Header + "\r\n" + ((HttpRecord)_selectedItem).Request.Body;
                    ResponseTextContent = ((HttpRecord)_selectedItem).Response.Header + "\r\n" +((HttpRecord)_selectedItem).Response.Body;
                }
                if (_selectedItem != value)
                {
                    RaisePropertyChanged("SelectedItem");
                }
            }
        }

        public string RequestTextContent {
            get {
                return _requestTextContent;
            }
            set {
                _requestTextContent = value;
                RaisePropertyChanged("RequestTextContent");
            }
        }

        public string ResponseTextContent {
            get {
                return _responseTextContent;
            }
            set {
                _responseTextContent = value;
                RaisePropertyChanged("ResponseTextContent");
            }
        }

        private void ReceiveMessages(FiddlerStateMessage message) {

            if (message.Execute) {
                if (FiddlerHelper.CanStartCapture())
                    FilterDomain = message.FilterDomain;
                    StartCapture();
            }

            if (message.Stop) {
                StopCapture();
            }

            if (message.RegsiterCert)
            {
                if (FiddlerHelper.CanInstallCert())
                    InstallCert();
            }

            if (message.UnRegisterCert) { 
                if (FiddlerHelper.CanUninstallCert())
                    UninstallCert();
            }

            if (message.ClearCache)
            {
                // 모든 Record 들을 제거 
                if (MessageBoxResult.OK == MessageBox.Show("Do you want Clear Cache?", "Confirm", MessageBoxButton.OKCancel, MessageBoxImage.Question))
                {
                    // To Clear AsyncObservableCollection, We need to Stop Capturing, and then restart Capture.
                    // I think that this has a synchronization Problem. 
                    if (!FiddlerHelper.CanStartCapture())
                    {
                        StopCapture();
                        Records.Clear();
                        StartCapture();
                    }
                    else {
                        Records.Clear();
                    }
                    GC.Collect(); // Garbage Collect

                }

            }
           
        }

        public string Search
        {
            get
            {
                return _search;
            }
            set
            {
                _search = value;
                RaisePropertyChanged("Search");
            }
        }

        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
                RaisePropertyChanged("Count");
            }
        }

        public AsyncObservableCollection<HttpRecord> Records
        {
            get
            {
                return _records;
            }
            set
            {
                _records = value;
                RaisePropertyChanged("Records");
            }
        }

        private void UninstallCert()
        {
            CertMaker.removeFiddlerGeneratedCerts(true);
        }

        private void InstallCert()
        {
            // RootCert 를 생성
            CertMaker.createRootCert();
            // RootCert 를 신뢰하는 인증서 목록에 추가
            CertMaker.trustRootCert();
        }

        private void StopCapture()
        {
            // 등록한 Handler 를 제거
            FiddlerApplication.AfterSessionComplete -= AfterSessionComplete;
            if (FiddlerApplication.IsStarted())
                FiddlerApplication.Shutdown();
        }

        private void StartCapture()
        {
            FiddlerApplication.AfterSessionComplete += AfterSessionComplete;
            FiddlerApplication.Startup(iListenPort, flags);
        }

        private void AfterSessionComplete(Session sess)
        {
            if (FilterDomain != null && !RegexHelper.DomainRegexMatcher(FilterDomain, sess.fullUrl))
            {
                // 필터링 케이스 정리 
                // .*.yes24.com 을 도메인 필터로 지정하였을 경우 www.google.com 의 레코드가 필터되지 않음을 확인 
                // 만약 이것을 정규 표현식으로 풀어야 한다면,,,,,, 사용자측에서 좀더 정확한 Regex Filter 문자열을 
                // 제공하는 것이 옳겠지만, 그렇지 않을 경우 일반 사용자의 단순 필터 문자열을 입력받는다고 예상할 경우 
                // 수정이 필요로 함.

                // Then, pass Session
                return;
            }
                
            // Connect 는 무시
            if (sess.RequestMethod == "CONNECT")
                return;

            // sess 파라미터가 null 인경우 return
            if (sess == null || sess.oRequest == null || sess.oRequest.headers == null)
                return;
            // 헤더 추출
            string headers = sess.oRequest.headers.ToString();

            // Content Type 추출, 아래의 코드가 의심스럽긴한데... 
            string contentType = sess.oRequest.headers.Where(hd => hd.Name.ToLower() == "content-type")
                .Select(hd => hd.Value)
                .FirstOrDefault();

            var item = sess.oRequest.headers.Where(hd => hd.Name.ToLower() == "content-type");
            var item2 = item.Select(hd => hd.Value).FirstOrDefault();
         
            string reqBody = null;

            if (sess.RequestBody.Length > 0)
            {
                if(contentType != null) {

                    if (sess.requestBodyBytes.Contains((byte)0) || contentType.StartsWith("image/"))
                    {
                        // 이미지인 경우 base64 로 변환
                        reqBody = Convert.ToBase64String(sess.requestBodyBytes);
                    }else
                    {
                    // 그렇지 않을 경우 문자열로 변환
                    //reqBody = Encoding.Default.GetString(sess.ResponseBody);
                    reqBody = sess.GetRequestBodyAsString();
                    }
                }
                else
                {
                    // 그렇지 않을 경우 문자열로 변환
                    //reqBody = Encoding.Default.GetString(sess.ResponseBody);
                    reqBody = sess.GetRequestBodyAsString();
                }
            }
            
            #region FirstLineAssemble Make the FirstLine of HttpRequest
            // HTTP Request Header 의 URL 부분을 FullRequest로 변경
            string firstLine = sess.RequestMethod + " " + sess.fullUrl + " " + sess.oRequest.headers.HTTPVersion;
            int at = headers.IndexOf("\r\n");
            if (at > 0)
                headers = firstLine + headers.Substring(at + 1);

            #endregion


            #region Split URL for indentifying URL extensions Like aspx, asp, ...
            // 우선 HttpRequest 객체를 생성
            string[] splitUri = sess.url.Split('/');
            // ? 분해 [0]
            // / 분해 [-1]
            // . 존재 ? 
            // . 분해 [-1]
            // 여기서 부터 시작하면됨 ..... 2017.01.31
            string[] param = sess.url.Split('?');
            string[] path = param[0].Split('/');
            // End Of Path Item
            int pointAt = path[path.Length - 1].IndexOf('.');
            string ext = "";
            if (pointAt > 0)
            {
                // 확장자가 존재함을 의미
                string[] tmp = path[path.Length - 1].Split('.');
                ext = tmp[tmp.Length - 1];
            }

            #endregion

            #region Create HttpRequest 
            HttpRequest _request = new HttpRequest();
            _request.Domain = sess.isHTTPS == true ? "https://" + "" + splitUri[0] : "http://" + "" + splitUri[0];
            _request.Method = sess.RequestMethod;
            _request.Header = headers;
            _request.Body = reqBody;
            _request.URL = sess.PathAndQuery;
            _request.Extension = ext;
            // Get, Post Param Check 완료
            _request.HasParam = sess.RequestBody.Length > 0 || param.Length > 1 ? true : false;
            _request.IsSSL = sess.isHTTPS;
            #endregion

            #region Create HttpResponse

            string respContentType = sess.oResponse.headers.Where(hd => hd.Name.ToLower() == "content-type")
                .Select(hd => hd.Value)
                .FirstOrDefault();

            string resBody = null;

            if (sess.ResponseBody.Length > 0)
            {   
                if (respContentType != null) {
                    if (sess.responseBodyBytes.Contains((byte)0) || respContentType.Contains("image/"))
                    {
                        // 이미지인 경우 base64 로 변환
                        resBody = Convert.ToBase64String(sess.responseBodyBytes);
                    }
                    else
                    {
                        // 그렇지 않을 경우 문자열로 변환
                        resBody = sess.GetResponseBodyAsString();
                    }

                }
                else
                {
                    resBody = sess.GetResponseBodyAsString();
                    // 그렇지 않을 경우 문자열로 변환
                    /*
                    Regex r = new Regex(@"www.yes24.com", RegexOptions.IgnoreCase);
                    Match m = r.Match(sess.url);
                    if (m.Success) {
                        Console.WriteLine(resBody);
                        Console.WriteLine(Convert.FromBase64String(resBody));
                    }
                    */
                }
            }

            // 아래와 같은 타입은 좀 깔끔하지 않은 코딩 방법인듯하다. 
            HttpResponse _response = new HttpResponse();
            _response.Status = sess.responseCode;
            _response.Length = sess.ResponseBody.Length;
            _response.ContenType = respContentType;
            _response.Header = sess.oResponse.headers.ToString();
            _response.Body = resBody;
            _response.HostIP = sess.m_hostIP;
            
            #endregion

            // ObservableCollection<HttpRecord> 에 HttpRecord 객체 추가
            Messenger.Default.Send(new SingleHttpRecordTransfer { Item = new HttpRecord(++Count, _request, _response) });
        }
    }
}
