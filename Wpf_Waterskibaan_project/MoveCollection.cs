using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Waterskibaan_project
{
    static class MoveCollection
    {
        public static List<IMoves> GetWillekeurigeMoves()
        {
            List<IMoves> moves = new List<IMoves>();
            Random rnd = new Random();
            for (int i = 0; i < rnd.Next(0, 6); i++)
            {
                int rand = rnd.Next(0, 4);
                if (rand == 0)
                {
                    Jump jump = new Jump();
                    moves.Add(jump);
                }
                else if (rand == 1)
                {
                    Draai draai = new Draai();
                    moves.Add(draai);
                }
                else if (rand == 2)
                {
                    EenBeen eenBeen = new EenBeen();
                    moves.Add(eenBeen);
                }
                else
                {
                    EenHand eenHand = new EenHand();
                    moves.Add(eenHand);
                }
            }
            return moves;
        }

    }
}
