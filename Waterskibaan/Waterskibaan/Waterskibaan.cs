using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Waterskibaan
    {
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
