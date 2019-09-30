using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class InstructieGroep : Wachtrij, IWachterij
    {
        public int MAX_LENGTE_RIJ { get; set; } = 5;

        public String toString()
        {
            String text = $"In de instructiegroep wachten {base.toString()}";
            Console.WriteLine(text);
            return text;
        }
    }
}
