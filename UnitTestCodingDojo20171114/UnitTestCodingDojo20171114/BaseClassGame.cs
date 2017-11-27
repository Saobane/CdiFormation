using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestCodingDojo20171114
{
    public abstract class BaseClassGame
    {
        public Player Player1 { get; set; }

        public Player Player2 { get; set; }

        public List<Player> points { get; set; }

        public Player Winner { get { return GetWinner(); } }


        protected virtual Player GetWinner()
        {
            return null;
        }
        public abstract int GetScore(Player param);
        public abstract string GetScoreSetString();
    }
}
