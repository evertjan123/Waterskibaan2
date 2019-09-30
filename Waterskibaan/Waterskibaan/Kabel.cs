using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Kabel
    {
        private LinkedList<Lijn> _lijnen = new LinkedList<Lijn>();
        public LinkedListNode<Lijn> First { get; }
        public bool IsStartPositieLeeg()
        {
            if(_lijnen.First == null || _lijnen.First.Value.PositieOpDeKabel != 0)
            {
                return true;
            } else
            {
                Console.WriteLine("Startpositie vol");
                return false;
            }
            
        }
        public void NeemLijnInGebruik(Lijn lijn)
        {
            if (IsStartPositieLeeg() == true)
            {
                _lijnen.AddFirst(lijn);
                lijn.PositieOpDeKabel = 0;
            }
        }
        public void verschuifLijnen()
        {
            foreach (var item in _lijnen)
            {
                Console.WriteLine("positie +1");
                item.PositieOpDeKabel += 1;
            }
            if (_lijnen.Last.Value.PositieOpDeKabel == 10 && _lijnen.Last.Value.Sporter.AantalRondenNogTeGaan > 0)
            {
                Lijn lastLine = _lijnen.Last.Value;
                if(lastLine.Sporter.AantalRondenNogTeGaan > 0)
                {
                    Console.WriteLine("Ronde minder");
                    lastLine.Sporter.AantalRondenNogTeGaan--;
                }

                Console.WriteLine("reset line");
                _lijnen.RemoveLast();
                NeemLijnInGebruik(lastLine);
            }
        }
        public Lijn VerwijderLijnVanKabel()
        {
            if (_lijnen.Last.Value.PositieOpDeKabel == 9 && _lijnen.Last.Value.Sporter.AantalRondenNogTeGaan == 0)
            {
                Console.WriteLine("lijn verwijderd");
                _lijnen.RemoveLast();
                return _lijnen.Last.Value;
            } else
            {
                return null;
            }
        }
        public String toString()
        {
            String text = "";
            foreach (var item in _lijnen)
            {
                text += $"{item.PositieOpDeKabel}|";
            }
            return text;
        }
    }
}
