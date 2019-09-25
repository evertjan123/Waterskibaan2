using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class LijnenVoorraad
    {
        private Queue<Lijn> _lijnen = new Queue<Lijn>();

        public void LijnToevoegenAanRij(Lijn lijn)
        {
            _lijnen.Enqueue(lijn);
        }
        public Lijn VerwijderEersteLijn()
        {
            if(_lijnen.Count() < 1)
            {
                _lijnen.Dequeue();              
            } else
            {
                return null;
            }
            return null;
        }
        public int GetAantalLijnen()
        {
            return _lijnen.Count();
        }
        public String toString()
        {
            String text = $"{GetAantalLijnen()} lijnen op voorraad";
            Console.WriteLine(text);
            return text;
        }
    }
}
