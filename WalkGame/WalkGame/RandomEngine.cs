using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkGame
{
public class RandomEngine :  IMoveEngine
    {
        public int Play()
        {
            return Rand.Next(-2, 3);
        }

        private Random Rand { get; set; }
        public RandomEngine()
        {
            Rand = new Random();
        }
    }
}
