using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    abstract class BaseHeuristics : IHeuristics
    {
        public abstract int CalculateHeuristics(GameStateNode state);
    }
}
