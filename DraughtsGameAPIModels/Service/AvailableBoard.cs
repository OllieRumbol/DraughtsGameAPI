using System;
using System.Collections.Generic;
using System.Text;

namespace DraughtsGameAPIModels.Service
{
    public class AvailableBoard
    {

        public int[,] Board { get; set; }

        public int CurrentHeight { get; set; }

        public int CurrentWidth { get; set; }

        public int NextHeight { get; set; }

        public int NextWidth { get; set; }

        public List<Take> Takes { get; set; }

        public List<NextMove> moves { get; set; }
    }
}
