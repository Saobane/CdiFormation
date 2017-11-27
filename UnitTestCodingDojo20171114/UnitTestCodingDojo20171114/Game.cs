using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace UnitTestCodingDojo20171114
{
    public class Game : BaseClassGame
    {
        public Game(Player player1, Player player2)
        {
            if (player1 == null || player2 == null)
                throw new PlayerNullException();

            Player1 = player1;
            Player2 = player2;
            points=new List<Player>()
            ;
        }
        public void PlayRound(Player player)
        {
            points.Add(player);
        }


        public override int GetScore(Player player)
        {
            return points.Count(x => x == player);
        }

        public override string GetScoreSetString()
        {
            throw new NotImplementedException();
        }
    }
}
