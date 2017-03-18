using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyHacks.Message
{
    public class FiddlerStateMessage
    {
        private bool _execute;
        private bool _stop;
        private bool _registerCert;
        private bool _unregisterCert;
        private bool _clearCache;
        private string _filterDomain;

        public string FilterDomain
        {
            get { return _filterDomain; }
            set
            {
                _filterDomain = value;
            }
        }

        public bool Execute {
            get { return _execute; }
            set {
                _execute = value;
            }
        }

        public bool ClearCache
        {
            get { return _clearCache; }
            set
            {
                _clearCache = value;
            }
        }

        public bool Stop
        {
            get { return _stop; }
            set
            {
                _stop = value;
            }
        }

        public bool RegsiterCert {
            get { return _registerCert; }
            set { _registerCert = value; }
        }

        public bool UnRegisterCert {
            get { return _unregisterCert; }
            set { _unregisterCert = value; }
        }
    }
}
