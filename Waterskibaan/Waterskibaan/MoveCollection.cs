using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public static class MoveCollection
    {

        public static List<IMoves> GetWillekeurigeMoves()
        {
            List<IMoves> moves = new List<IMoves>();
            moves.Add(new Move());
            moves.Add(new Move());
            moves.Add(new Move());
            moves.Add(new Move());
            List<IMoves> gekozenMoves = new List<IMoves>();
            Random rand = new Random();

            for (int i = 0; i < rand.Next(1,3); i++)
            {
                gekozenMoves.Add(moves.ElementAt(rand.Next(0,3)));
            }

            return gekozenMoves;
        }
    }
}
