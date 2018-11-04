using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoESoft.Server.Core.World
{
    public struct GameTime
    {
        public long TickCount;
        public long TotalElapsedMs;
        public int TickDelta;
        public int ElaspedMsDelta;
    }
}
