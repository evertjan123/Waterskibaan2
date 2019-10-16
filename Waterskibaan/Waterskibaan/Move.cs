using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Move : IMoves
    {
        public string Naam { get; set; }
        Random random = new Random();
        int randomInt;
        public Move(string name)
        {          
            if (name == "Jump")
            {
                Naam = "Jump";
            }
            else if (name == "Met een hand")
            {
                Naam = "Met een hand";
            }
            else if (name == "Omdraaien")
            {
                Naam = "Omdraaien";
            }
            else if (name == "Op een been")
            {
                Naam = "Op een been";
            }
        }
        public int moves()
        {

            if (Naam == "Jump")
            {
                return Jump();
            }
            else if (Naam == "Met een hand")
            {
                return MetEenHand();
            }
            else if (Naam == "Omdraaien")
            {
                return Omdraaien();
            }
            else
            {
                return OpEenBeen();
            }
        }
        public int Jump()
        {
            if (voerUit() == 1)
            {
                return 200;
            } else
            {
                return 0;
            }
        }
        public int MetEenHand()
        {
            if(voerUit() == 1)
            {
                return 120;
            } else
            {
                return 0;
            }
        }
        public int Omdraaien()
        {
            if(voerUit() == 1)
            {
                return 250;
            } else
            {
                return 0;
            }
        }
        public int OpEenBeen()
        {
            if(voerUit() == 1)
            {
                return 275;
            } else
            {
                return 0;
            }
        }
        public int voerUit()
        {
            int rand = random.Next(2);
            if(rand == 1)
            {
                return 1;
            } else
            {
                return 0;
            }
        }

    }
}
