using CrazyHacks.Async;
using CrazyHacks.Message;
using CrazyHacks.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyHacks.ViewModel
{
    public class XssControlViewModel : ViewModelBase
    {
        public AsyncObservableCollection<HttpRecord> XssTarget { get; set; }
        public XssControlViewModel() {
            XssTarget = new AsyncObservableCollection<HttpRecord>();
            Messenger.Default.Register<TransferRecordMessage>(this, ReceiveRecord);
        }

        private object _selectedItem { get; set; }

        public object SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                if (_selectedItem != null)
                {
                }
                if (_selectedItem != value)
                {
                    RaisePropertyChanged("SelectedItem");
                }
            }
        }
        private void ReceiveRecord(TransferRecordMessage record)
        {
            if (record.records.Count != 0)
                foreach ( var item in record.records)
                {
                    XssTarget.Add(item);
                }
        }
    }
}
