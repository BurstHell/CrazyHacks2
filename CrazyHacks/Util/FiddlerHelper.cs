using Fiddler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyHacks.Util
{
    public class FiddlerHelper
    {
        public static bool CanUninstallCert()
        {
            if (CertMaker.rootCertExists())
            {
                // Root Cert 가 존재하는 경우
                return true;
            }
            else
            {
                // Root Cert 가 존재하지 않는 경우
                return false;
            }
        }

        public static bool CanInstallCert()
        {
            if (CertMaker.rootCertExists())
            {
                // Root Cert 가 존재하는 경우
                return false;
            }
            else
            {
                // Root Cert 가 존재하지 않는 경우
                return true;
            }
        }

        public static bool CanStopCapture()
        {
            return FiddlerApplication.IsStarted();
        }

        public static bool CanStartCapture()
        {
            return !FiddlerApplication.IsStarted();
        }
    }
}
