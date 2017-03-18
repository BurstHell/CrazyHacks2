using CrazyHacks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyHacks.Message
{
    public class TransferRecordMessage
    {
        public IList<HttpRecord> records { get; set; }
    }
}
