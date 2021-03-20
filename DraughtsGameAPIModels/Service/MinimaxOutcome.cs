using System;
using System.Collections.Generic;
using System.Text;

namespace DraughtsGameAPIModels.Service
{
    public class MinimaxOutcome
    {
        public int Evaluation { get; set; }

        public AvailableBoard Board { get; set; }
    }
}
