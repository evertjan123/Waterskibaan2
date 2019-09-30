using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Waterskibaan
{
    class Game
    {
        Waterskibaan w = new Waterskibaan();
        public void Initialize()
        {
            for (int i = 0; i < 15; i++)
            {
                w.SporterStart(new Sporter());
                w.toString();
                w.VerplaatsKabel();
                Console.WriteLine("Kabel verplaatst");
                w.toString();
                Console.WriteLine("------------------------------------");
                Thread.Sleep(1000);

            }

        }
    }
}
