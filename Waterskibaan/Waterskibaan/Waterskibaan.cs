using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Waterskibaan
    {
        Random rand = new Random();
        public LijnenVoorraad lv = new LijnenVoorraad();
        public Kabel K = new Kabel();
        public Waterskibaan()
        {
            for (int i = 0; i < 15; i++)
            {
                lv.LijnToevoegenAanRij(new Lijn());
            }
        }
        public void SporterStart(Sporter sp)
        {
            if (sp.Zwemvest != null && sp.Skies != null)
            {
                if (K.IsStartPositieLeeg() == true)
                {
                    Lijn l = new Lijn();

                    K.NeemLijnInGebruik(l);
                    l.AddSporter(sp);
                    lv.VerwijderEersteLijn();
                }
            }
            else
            {
                throw new Exception("geen zwemvest of skies");
            }

        }
        public void VerplaatsKabel()
        {

            foreach (Lijn lijn in K._lijnen) 
            {
                int kansMove = rand.Next(3);
                if (kansMove == 0)
                {
                    int move = rand.Next(0, lijn.Sporter.Moves.Count);
                    lijn.Sporter.HuidigeMove = (Move)lijn.Sporter.Moves.ElementAt(rand.Next(0,lijn.Sporter.Moves.Count));
                    lijn.Sporter.BehaaldePunten += lijn.Sporter.HuidigeMove.moves();
                } else
                {
                    lijn.Sporter.HuidigeMove = null; 
                }
            }
            K.verschuifLijnen();
            Lijn verwijderdeLijn = K.VerwijderLijnVanKabel();
            if (verwijderdeLijn != null)
            {
                lv.LijnToevoegenAanRij(new Lijn());
            }



        }

        public Kabel ReturnKabel()
        {
            return K;
        }

        public String toString()
        {
            String text = $"{lv.toString()} \n {K.toString()}";
            Console.WriteLine(text);
            return text;
        }
    }
}
