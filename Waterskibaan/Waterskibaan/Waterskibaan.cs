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
            if (K.IsStartPositieLeeg() == false)
            {
                if (K.VerwijderLijnVanKabel() == null)
                {
                }
                else
                {
                    lv.LijnToevoegenAanRij(new Lijn());
                }
                K.verschuifLijnen();
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
