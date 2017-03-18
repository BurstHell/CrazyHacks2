using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyHacks.Model
{
    public class HttpRecord : Notifier
    {
        private Guid _id;
        private int _no;
        private HttpRequest _req;
        private HttpResponse _res;
        private DateTime _sessTime; // After session complete time

        public HttpRecord(int count, HttpRequest req, HttpResponse res) {
            _id = Guid.NewGuid();
            _no = count;
            _req = req;
            _res = res;
            _sessTime = DateTime.Now;
        }

        public HttpRequest Request {
            get { return _req; }
            private set { }
        }

        public HttpResponse Response
        {
            get { return _res; }
            private set { }
        }

        public int No {
            get { return _no; }
            private set
            {
                _no = value;
                RaisePropertyChanged("No");
            }
        }

        public string Host {
            get { return _req.Domain; }
            private set { }
        }

        public string Method
        {
            get { return _req.Method; }
            private set { }
        }

        public string URL
        {
            get { return _req.URL; }
            private set { }
        }

        public bool Params {
            get { return _req.HasParam; }
            private set { }
        }

        public int Status {
            get { return _res.Status; }
            private set { }
        }

        public int Length {
            get { return _res.Length; }
            private set { }
        }

        public string MIME {
            get { return _res.ContenType; }
            private set { }
        }

        public string Extension {
            get { return _req.Extension; }
            private set { }
        }

        public bool SSL {
            get { return _req.IsSSL; }
            private set { }
        }

        public string IP {
            get { return _res.HostIP; }
            private set { }
        }

        public DateTime Time {
            get { return _sessTime; }
            private set { }
        }
        public Guid Id
        {
            get { return _id; }
            private set
            {
                _id = value;
                RaisePropertyChanged("Id");
            }
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
                return false;

            var other = obj as HttpRecord;
            return other != null && other.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    public class HttpResponse : Notifier {

        private Guid _id;
        private int _status; //
        private int _length; //
        private string _contentType; // Content-Type header
        private string _header; //
        private string _body; //
        private string _hostIp;

        public HttpResponse() {
            _id = Guid.NewGuid();
        }

        public HttpResponse(int status, int length, string contentType, string header, string body , string hostip) {
            _id = Guid.NewGuid();
            _status = status;
            _length = length;
            _contentType = contentType;
            _header = header;
            _body = body;
            _hostIp = hostip;
        }

        public string GetFullResponse() {
            string _httpResponse = "";

            _httpResponse += _header + "\r\n" + 
                (!string.IsNullOrEmpty(_body) ? _body + "\r\n" : string.Empty) + "\r\n\r\n";

            return _httpResponse;
        }

        public Guid Id
        {
            get { return _id; }
            private set
            {
                _id = value;
                RaisePropertyChanged("Id");
            }
        }

        public int Status {
            get {
                return _status;
            }
            set {
                if (value.GetType() == typeof(int))
                {
                    _status = value;

                    RaisePropertyChanged("Status");
                }
                else {
                    // error raise
                }
            }
        }

        public int Length {
            get { return _length; }
            set
            {
                if (value.GetType() == typeof(int))
                {
                    _length = value;

                    RaisePropertyChanged("Length");
                }
                else
                {
                    // error raise
                }
            }
        }

        public string ContenType {
            get
            {
                return _contentType;
            }
            set {
                _contentType = value;
                RaisePropertyChanged("ContenType");
            }
        }

        public string Header
        {
            get
            {
                return _header;
            }
            set
            {
                _header = value;
                RaisePropertyChanged("Header");
            }
        }

        public string Body
        {
            get
            {
                return _body;
            }
            set
            {
                _body = value;
                RaisePropertyChanged("Body");
            }
        }

        public string HostIP {
            get { return _hostIp; }
            set {
                _hostIp = value;
                RaisePropertyChanged("HostIP");
            }
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
                return false;

            var other = obj as HttpResponse;
            return other != null && other.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    public class HttpRequest : Notifier
    {
        private Guid _id;
        private string _domain; // http://domain.com
        private string _method; // Get/Post
        private string _header; // Host: asdfadfs \r\n Content-Type: asdfasdf \r\n
        private string _body; // Param=gura&gura=Param
        private string _extension; // Extension, aspx
        private string _url; // /something/happen/index.aspx
        private bool _hasParam; // Parameter 존재 여부
        private bool _isSSL; // ssl 여부

        public HttpRequest() {
            _id = Guid.NewGuid();
        }

        public HttpRequest(string domain, string method, 
            string header, string body, string extension, string url, bool hasParam=false, bool isSSL=false) {
            _id = Guid.NewGuid();
            _domain = domain;
            _method = method;
            _header = header;
            _body = body;
            _extension = extension;
            _url = url;
            _hasParam = hasParam;
            _isSSL = isSSL;
        }

        public string GetFullRequest() {
            string _httpRequest = "";
            _httpRequest += _header + "\r\n" +
                    (!string.IsNullOrEmpty(_body) ? _body + "\r\n" : string.Empty) + "\r\n\r\n";
            return _httpRequest;
        }
        public Guid Id
        {
            get { return _id; }
            private set
            {
                _id = value;
                RaisePropertyChanged("Id");
            }
        }

        public string Domain {
            get { return _domain; }
            set {
                _domain = value;
                RaisePropertyChanged("Domain");
            }
        }

        public string Method {
            get { return _method; }
            set {
                _method = value;
                RaisePropertyChanged("Method");
            }
        }

        public string Header {
            get { return _header; }
            set
            {
                _header = value;
                RaisePropertyChanged("Header");
            }
        }

        public string Body {
            get { return _body; }
            set
            {
                _body = value;
                RaisePropertyChanged("Body");
            }
        }

        public string Extension
        {
            get { return _extension; }
            set
            {
                _extension = value;
                RaisePropertyChanged("Extension");
            }
        }

        public string URL
        {
            get { return _url; }
            set
            {
                _url = value;
                RaisePropertyChanged("URL");
            }
        }

        public bool HasParam
        {
            get { return _hasParam; }
            set
            {
                _hasParam = value;
                RaisePropertyChanged("HasParam");
            }
        }

        public bool IsSSL
        {
            get { return _isSSL; }
            set
            {
                _isSSL = value;
                RaisePropertyChanged("IsSSL");
            }
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
                return false;

            var other = obj as HttpRequest;
            return other != null && other.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
