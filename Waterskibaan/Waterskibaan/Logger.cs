using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Logger
    {
        public Kabel Kabel { get; set; }
        public List<Sporter> sporterLog { get; set; }
        public Logger(Kabel kabel)
        {
            Kabel = kabel;
            sporterLog = new List<Sporter>();
        }
    }
}
