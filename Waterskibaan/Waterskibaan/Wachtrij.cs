using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    abstract class Wachtrij
    {
        private Queue<Sporter> _wachtrij = new Queue<Sporter>();

        public void SporterNeemPlaatsInRij(Sporter sporter)
        {
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
                sportList.Add(_wachtrij.ElementAt(i));
                _wachtrij.Dequeue();
            }
            return sportList;
        }
        public String toString()
        {
            String text = $"{_wachtrij.Count} Sporters";
            return text;
        }
    }
}
