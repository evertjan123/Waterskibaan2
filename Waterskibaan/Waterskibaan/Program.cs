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
            //Kabel A = new Kabel();
            //A.NeemLijnInGebruik(new Lijn());
            //A.verschuifLijnen();
            //A.NeemLijnInGebruik(new Lijn());
            //A.verschuifLijnen();
            //A.NeemLijnInGebruik(new Lijn());
            //A.verschuifLijnen();
            //A.toString();
            //LijnenVoorraad B = new LijnenVoorraad();
            //B.LijnToevoegenAanRij(new Lijn());
            //B.LijnToevoegenAanRij(new Lijn());
            //B.toString();
            //opdracht 5
            //Sporter s1 = new Sporter();
            //foreach (var item in s1.Moves)
            //{
            //    Console.WriteLine(item.moves());
            //}
            //foreach (var item in s1.Moves)
            //{
            //    Console.WriteLine(item.moves());
            //}
            //opdracht 9 en 10
            //Wachtrijintstructie w = new Wachtrijintstructie();
            //w.toString();
            //opdracht 11
            Sporter s = new Sporter();
            Console.WriteLine(s.AantalRondenNogTeGaan);
            Game g = new Game();
            g.Initialize();
        }
            
    }
}
