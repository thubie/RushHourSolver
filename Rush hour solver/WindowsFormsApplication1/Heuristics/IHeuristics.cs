﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    interface IHeuristics
    {
        int CalculateHeuristics(GameStateNode state);
    }
}
