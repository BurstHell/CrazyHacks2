using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CrazyHacks.Model
{
    class FilterConfig
    {
        public bool FilterStatus200 { get; set; }
        public bool FilterStatus300 { get; set; }
        public bool FilterStatus400 { get; set; }
        public bool FilterStatus500 { get; set; }
        public bool FilterHasParameter { get; set; }
        public bool FilterMimeHTML { get; set; }
        public bool FilterMimeScipts { get; set; }
        public bool FilterMimeImages { get; set; }
        public bool FilterMimeXML { get; set; }
        public bool FilterMimeCSS { get; set; }
        public bool FilterMimeBinary { get; set; }
        public bool FilterMimeText { get; set; }
        public bool FilterDomain { get; set; }
        public string DomainFocus { get; set; }
        public void Clear() {
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
                    p.SetValue(this, null);
                }
            }
        }
        public FilterConfig() {
            // 초기화, 필터 여부를모두 False 로 조정
            PropertyInfo[] properties = this.GetType().GetProperties();

            foreach (var p in properties) {
                
                if (typeof(System.Boolean).IsAssignableFrom(p.PropertyType)) {
                    p.SetValue(this, false);
                }

                if (typeof(System.String).IsAssignableFrom(p.PropertyType)) {
                    p.SetValue(this, null);
                }
            }
        }
    }
}
