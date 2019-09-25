using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Program
    {
        static void Main(string[] args)
        {
            //opdracht 2 & 3
            Kabel A = new Kabel();
            A.NeemLijnInGebruik(new Lijn());
            A.verschuifLijnen();
            A.NeemLijnInGebruik(new Lijn());
            A.verschuifLijnen();
            A.NeemLijnInGebruik(new Lijn());
            A.verschuifLijnen();
            A.toString();
            LijnenVoorraad B = new LijnenVoorraad();
            B.LijnToevoegenAanRij(new Lijn());
            B.LijnToevoegenAanRij(new Lijn());
            B.toString();
        }
            
    }
}
