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
                item.PositieOpDeKabel += 1;
            }
            if(_lijnen.Last.Value.PositieOpDeKabel == 10)
            {
                _lijnen.RemoveLast();
                NeemLijnInGebruik(new Lijn());
            }
        }
        public Lijn VerwijderLijnVanKabel()
        {
            if(_lijnen.Last.Value.PositieOpDeKabel == 9)
            {
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
            Console.WriteLine(text);
            return text;
        }
    }
}
