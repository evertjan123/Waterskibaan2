using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class InstructieGroep : Wachtrij, Iwachtrij
    {
        public override int MAX_LENGTE_RIJ { get { return 5; } }


        public string toString()
        {
            String text = $"In de instructiegroep wachten {base.toString()}";
            Console.WriteLine(text);
            return text;
        }
    }
}
