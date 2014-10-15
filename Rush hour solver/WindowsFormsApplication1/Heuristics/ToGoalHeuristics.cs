using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class ToGoalHeuristics : BaseHeuristics
    {
        public override int CalculateHeuristics(GameStateNode state)
        {
            int k = 0;
            bool goalCarfound = false;
            for (int i = 0; i < 6; i++)
            {
                if ((state.getGameState()[2 * 6 + i] == 'X') && (state.getGameState()[2 * 6 + i + 1] != 'X'))
                    goalCarfound = true;
                if (goalCarfound == true && state.getGameState()[2 * 6 + i] != '.')
                    k++;
                else
                    continue;
            }

            int h = 0;
            for (int i = 0; i < 6; i++)
            {
                if (state.getGameState()[2 * 6 + i] == 'X' && state.getGameState()[2 * 6 + i] != 'X')
                    return 6 - h + k;
                h++;
            }
            return h + k;
        }
    }
}
