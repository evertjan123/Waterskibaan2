using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Wachtrijintstructie : Wachtrij, IWachterij
    {
        public int MAX_LENGTE_RIJ { get; set; } = 100;

        public String toString()
        {
            String text = $"In de instructie wachtrij wachten {base.toString()}";
            Console.WriteLine(text);
            return text;
        }


    }
}
