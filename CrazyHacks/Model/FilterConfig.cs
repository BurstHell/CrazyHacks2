using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CrazyHacks.Model
{
    public class FilterConfig : Notifier
    {
        bool filterStatus200;
        public bool FilterStatus200 {
            get {
                return filterStatus200;
            } set {
                if (value != filterStatus200) {
                    filterStatus200 = value;
                    RaisePropertyChanged("FilterStatus200");
                }                
            }
        }
        bool filterStatus300;
        public bool FilterStatus300
        {
            get
            {
                return filterStatus300;
            }
            set
            {
                if (value != filterStatus300)
                {
                    filterStatus300 = value;
                    RaisePropertyChanged("FilterStatus300");
                }
            }
        }
        bool filterStatus400;
        public bool FilterStatus400
        {
            get
            {
                return filterStatus400;
            }
            set
            {
                if (value != filterStatus400)
                {
                    filterStatus400 = value;
                    RaisePropertyChanged("FilterStatus400");
                }
            }
        }
        bool filterStatus500;
        public bool FilterStatus500
        {
            get
            {
                return filterStatus500;
            }
            set
            {
                if (value != filterStatus500)
                {
                    filterStatus500 = value;
                    RaisePropertyChanged("FilterStatus500");
                }
            }
        }
        bool filterHasParameter;
        public bool FilterHasParameter
        {
            get
            {
                return filterHasParameter;
            }
            set
            {
                if (value != filterHasParameter)
                {
                    filterHasParameter = value;
                    RaisePropertyChanged("FilterHasParameter");
                }
            }
        }
        bool filterMimeHTML;
        public bool FilterMimeHTML
        {
            get
            {
                return filterMimeHTML;
            }
            set
            {
                if (value != filterMimeHTML)
                {
                    filterMimeHTML = value;
                    RaisePropertyChanged("FilterMimeHTML");
                }
            }
        }
        bool filterMimeScripts;
        public bool FilterMimeScipts
        {
            get
            {
                return filterMimeScripts;
            }
            set
            {
                if (value != filterMimeScripts)
                {
                    filterMimeScripts = value;
                    RaisePropertyChanged("FilterMimeScipts");
                }
            }
        }
        bool filterMimeImages;
        public bool FilterMimeImages
        {
            get
            {
                return filterMimeImages;
            }
            set
            {
                if (value != filterMimeImages)
                {
                    filterMimeImages = value;
                    RaisePropertyChanged("FilterMimeImages");
                }
            }
        }
        bool filterMimeXML;
        public bool FilterMimeXML
        {
            get
            {
                return filterMimeXML;
            }
            set
            {
                if (value != filterMimeXML)
                {
                    filterMimeXML = value;
                    RaisePropertyChanged("FilterMimeXML");
                }
            }
        }
        bool filterMimeCSS;
        public bool FilterMimeCSS
        {
            get
            {
                return filterMimeCSS;
            }
            set
            {
                if (value != filterMimeCSS)
                {
                    filterMimeCSS = value;
                    RaisePropertyChanged("FilterMimeCSS");
                }
            }
        }
        bool filterMimeBinary;
        public bool FilterMimeBinary
        {
            get
            {
                return filterMimeBinary;
            }
            set
            {
                if (value != filterMimeBinary)
                {
                    filterMimeBinary = value;
                    RaisePropertyChanged("FilterMimeBinary");
                }
            }
        }
        bool filterMimeText;
        public bool FilterMimeText
        {
            get
            {
                return filterMimeText;
            }
            set
            {
                if (value != filterMimeText)
                {
                    filterMimeText = value;
                    RaisePropertyChanged("FilterMimeText");
                }
            }
        }
        bool filterMimeFlash;
        public bool FilterMimeFlash
        {
            get
            {
                return filterMimeFlash;
            }
            set
            {
                if (value != filterMimeFlash)
                {
                    filterMimeFlash = value;
                    RaisePropertyChanged("FilterMimeFlash");
                }
            }
        }
        bool filterDomain;
        public bool FilterDomain
        {
            get
            {
                return filterDomain;
            }
            set
            {
                if (value != filterDomain)
                {
                    filterDomain = value;
                    RaisePropertyChanged("FilterDomain");
                }
            }
        }
        string domainFocus;
        public string DomainFocus
        {
            get
            {
                return domainFocus;
            }
            set
            {
                if (value != domainFocus)
                {
                    domainFocus = value;
                    RaisePropertyChanged("DomainFocus");
                }
            }
        }
        public void Clear()
        {
            // 초기화, 필터 여부를모두 False 로 조정
            PropertyInfo[] properties = this.GetType().GetProperties();

            foreach (var p in properties)
            {
                if (typeof(System.Boolean).IsAssignableFrom(p.PropertyType))
                {
                    p.SetValue(this, false);
                }

                if (typeof(System.String).IsAssignableFrom(p.PropertyType))
                {
                    p.SetValue(this, "");
                }
            }
        }
        public FilterConfig()
        {
            // 초기화, 필터 여부를모두 False 로 조정
            PropertyInfo[] properties = this.GetType().GetProperties();

            foreach (var p in properties)
            {

                if (typeof(System.Boolean).IsAssignableFrom(p.PropertyType))
                {
                    p.SetValue(this, false);
                }

                if (typeof(System.String).IsAssignableFrom(p.PropertyType))
                {
                    p.SetValue(this, "");
                }
            }
        }
    }
}
