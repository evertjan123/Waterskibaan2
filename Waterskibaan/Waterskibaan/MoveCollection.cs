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
            moves.Add(new Move("Jump"));
            moves.Add(new Move("Met een hand"));
            moves.Add(new Move("Omdraaien"));
            moves.Add(new Move("Op een been"));
            List<IMoves> gekozenMoves = new List<IMoves>();
            Random rand = new Random();

            for (int i = 0; i < rand.Next(1,4); i++)
            {
                gekozenMoves.Add(moves.ElementAt(rand.Next(0,4)));
            }

            return gekozenMoves;
        }
    }
}
