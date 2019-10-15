using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Waterskibaan
{
    public class Sporter
    {
        Random rand = new Random();
        public int AantalRondenNogTeGaan { get; set; }
        public Zwemvest Zwemvest { get; set; }
        public Skies Skies { get; set; }
        public Color KledingKleur { get; set; }       
        public List<IMoves> Moves { get; set; }
        public Move HuidigeMove { get; set; }
        public int BehaaldePunten { get; set; }
        public Sporter()
        {
            Moves = MoveCollection.GetWillekeurigeMoves();
            AantalRondenNogTeGaan = rand.Next(2);
            KledingKleur = Color.White;
            Zwemvest = new Zwemvest();
            Skies = new Skies();
            int red = rand.Next(0, 256);
            int green = rand.Next(0, 256);
            int blue = rand.Next(0, 256);
            Color randomColor = Color.FromArgb(255, (byte)red, (byte)green, (byte)blue);
            KledingKleur = randomColor;
        }
    }

}
