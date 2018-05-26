using System;

namespace TetrisEngine
{
    public static class TetrisTimers
    {
        public static TetrisTimer Basic => new TetrisTimer(new TimeSpan(0,0,0,0,400));
    }
}