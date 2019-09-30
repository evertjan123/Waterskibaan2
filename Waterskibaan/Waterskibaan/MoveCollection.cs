using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    static class MoveCollection
    {
        public static List<IMoves> GetWillekeurigeMoves()
        {
            List<IMoves> moves = new List<IMoves>();
            Random rand = new Random();

            for (int i = 0; i < rand.Next(4); i++)
            {
                moves.Add(new Move());
            }

            return moves;
        }
    }
}
