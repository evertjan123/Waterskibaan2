using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public abstract class Wachtrij
    {
        public abstract int MAX_LENGTE_RIJ { get; }
        private Queue<Sporter> _wachtrij = new Queue<Sporter>();

        public void SporterNeemPlaatsInRij(Sporter sporter)
        {
            if(_wachtrij.Count < MAX_LENGTE_RIJ)
            _wachtrij.Enqueue(sporter);
        }

        public List<Sporter> GetAlleSporters()
        {
            List<Sporter> sportList = new List<Sporter>();
            foreach (var item in _wachtrij)
            {
                sportList.Add(item);
            }
            return sportList;
        }
        public List<Sporter> SportersVerlatenRij(int aantal)
        {
            List<Sporter> sportList = new List<Sporter>();
            for (int i = 0; i < aantal; i++)
            {
                try
                {
                    sportList.Add(_wachtrij.Dequeue());
                } catch
                {
                    Console.WriteLine("Wachtrij leeg");
                }
            }
            return sportList;
        }

        public Queue<Sporter> ReturnWachtrij()
        {
            return _wachtrij;
        }
        public string toString()
        {
            string text = $"{_wachtrij.Count} Sporters";
            return text;
        }
    }
}
