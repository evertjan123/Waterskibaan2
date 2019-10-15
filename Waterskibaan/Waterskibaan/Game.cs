using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Waterskibaan
{
    public class Game
    {
        public Waterskibaan w = new Waterskibaan();
        public Kabel kabel;
        public Logger logger;

        private int counter;
        public Wachtrijintstructie wachtrijintstructie = new Wachtrijintstructie();
        public WachtrijStarten WachtrijStarten = new WachtrijStarten();
        public InstructieGroep instructieGroep = new InstructieGroep();

        public delegate void NieuweBezoekerHandler(NieuweBezoekerArgs args);
        public event NieuweBezoekerHandler NieuweBezoeker;
        public delegate void NaarInstructieHandler();
        public event NaarInstructieHandler NieuweInstructie;
        public delegate void InstructieAfgelopenHandler(InstructieAfgelopenArgs args);
        public event InstructieAfgelopenHandler InstructieAfgelopen;
        public delegate void VerplaatsLijnenHandler();
        public event VerplaatsLijnenHandler LijnenVerplaatst;




        public void Initialize()
        {
            NieuweBezoeker += onNieuweBezoeker;
            NieuweInstructie += bezoekerNaarInstructie;
            InstructieAfgelopen += instructieNaarWachtrij;
            LijnenVerplaatst += verplaatsLijnen;
            counter = 1;
            kabel = w.ReturnKabel();
            logger = new Logger(kabel);

        }

        public void rondeSpel()
        {
            if (kabel.IsStartPositieLeeg() == true)
            {
                if (WachtrijStarten.ReturnWachtrij().Count != 0)
                {
                    Sporter sporter = WachtrijStarten.SportersVerlatenRij(1).ElementAt(0);
                    w.SporterStart(sporter);
                }
            }
            if (counter % 3 == 0)
            {
                LijnenVerplaatst.Invoke();
            }
            if (counter % 4 == 0)
            {
                NieuweBezoeker.Invoke(new NieuweBezoekerArgs(new Sporter()));
            }
            if (counter % 10 == 0)
            {
                NieuweInstructie.Invoke();
            }
            if (counter % 20 == 0)
            {
                InstructieAfgelopen.Invoke(new InstructieAfgelopenArgs(new List<Sporter>()));
            }
            counter++;

        }


        public void onNieuweBezoeker(NieuweBezoekerArgs e)
        {
            wachtrijintstructie.SporterNeemPlaatsInRij(e.Sporter);
            logger.sporterLog.Add(e.Sporter);
        }

        public void bezoekerNaarInstructie()
        {
            List<Sporter> sporters = new List<Sporter>();
            if(instructieGroep.ReturnWachtrij().Count() == 0)
            {
                sporters = wachtrijintstructie.SportersVerlatenRij(5);
            }   
            foreach (Sporter sporter in sporters)
            {
                instructieGroep.SporterNeemPlaatsInRij(sporter);
            }

        }
        public void instructieNaarWachtrij(InstructieAfgelopenArgs e)
        {
            List<Sporter> sporters = new List<Sporter>();
            sporters = instructieGroep.SportersVerlatenRij(5);
            foreach (Sporter sporter in sporters)
            {
                WachtrijStarten.SporterNeemPlaatsInRij(sporter);
            }
        }
        public void verplaatsLijnen()
        {
            w.VerplaatsKabel();
        }

    }
}
