using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Waterskibaan
    {
        private LijnenVoorraad lv = new LijnenVoorraad();
        private Kabel K = new Kabel();
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
                Lijn l = new Lijn();
                K.NeemLijnInGebruik(l);
                l.AddSporter(sp);
            } else
            {
                throw new Exception("geen zwemvest of skies");
            }

        }
        public void VerplaatsKabel()
        {
            Boolean isLeeg = false;
            if (K.IsStartPositieLeeg())
            {
                isLeeg = true; 
            }
                K.VerwijderLijnVanKabel();
            K.verschuifLijnen();
            if (isLeeg == false)
            {
                lv.VerwijderEersteLijn();
            }
            

        }

        public String toString()
        {
            String text = $"{lv.toString()} \n {K.toString()}";
            Console.WriteLine(text);
            return text;
        }
    }
}
