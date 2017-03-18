using CrazyHacks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyHacks.Message
{
    public class SingleHttpRecordTransfer
    {
        private HttpRecord _item;

        public HttpRecord Item
        {
            get
            {
                if (_item != null)
                {
                    return _item;
                }
                return null;
            }
            set
            {
                _item = value;
            }
        }
    }
}
