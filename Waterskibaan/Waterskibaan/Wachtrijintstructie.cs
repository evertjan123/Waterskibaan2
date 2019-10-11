using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Wachtrijintstructie : Wachtrij, Iwachtrij
    {
        public override int MAX_LENGTE_RIJ { get { return 100; } }

        public String toString()
        {
            String text = $"In de instructie wachtrij wachten {base.toString()}";
            Console.WriteLine(text);
            return text;
        }


    }
}
