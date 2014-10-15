using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class NullHeuristics : BaseHeuristics
    {

        public override int CalculateHeuristics(GameStateNode state)
        {
            return 0;
        }
    }
}
