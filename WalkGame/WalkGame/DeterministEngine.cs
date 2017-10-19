using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WalkGame
{
    public  interface IMoveEngine
    {
        int Play();
    }

    internal class DeterministEngine : IMoveEngine
    {
        public int Play()
        {
            return 1;
        }
    }
}
