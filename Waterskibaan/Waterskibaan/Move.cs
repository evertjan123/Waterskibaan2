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
        public int moves()
        {
            randomInt = random.Next(4);
            if (randomInt == 0)
            {
                return Jump();
            }
            else if (randomInt == 1)
            {
                return MetEenHand();
            }
            else if (randomInt == 2)
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
            Naam = "Jump";
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
            Naam = "Met een hand";
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
            Naam = "Omdraaien";
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
            Naam = "Op een been";
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
