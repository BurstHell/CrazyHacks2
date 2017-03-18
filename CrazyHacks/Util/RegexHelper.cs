using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrazyHacks.Util
{
    public class RegexHelper
    {
        public static bool DomainRegexMatcher(string domain, string matchee)
        {
            Regex r = new Regex(String.Format(@"^https?:\/\/{0}", domain), RegexOptions.IgnoreCase);
            Match m = r.Match(matchee);
            if (m.Success)
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
}
