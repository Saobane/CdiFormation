using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestCodingDojo20171114
{
    public class GameDecorator : BaseClassGame
    {
        private BaseClassGame _myGame;


        public override int GetScore(Player param)
        {
           throw new NotImplementedException();
        }

        public string ConvertScore(int param)
        {
            switch (param)
            {
                case 0:
                    return "0";
                case 1:
                    return "15";
                case 2:
                    return "30";
                case 3:
                    return "40";
                default:
                    return "error";
            }
        }

        protected override Player GetWinner()
        {
            int score1 = _myGame.GetScore(_myGame.Player1);
            int score2 = _myGame.GetScore(_myGame.Player2);

            if (Math.Abs(score2 - score1) < 2)
                return null;
            if (Math.Max(score1, score2) < 4)
                return null;
            if (score1 > score2)
                return _myGame.Player1;
            return _myGame.Player2;
        }

        public override string GetScoreSetString()
        {
            int score1 = _myGame.GetScore(_myGame.Player1);
            int score2 = _myGame.GetScore(_myGame.Player2);
            string score1S;
            string score2S;

            if (_myGame.Winner !=null)
            {
                return _myGame.Winner.Name + " Win";
            }
        
            if (score1 < 4 && score2 < 4)
            {
                score1S = ConvertScore(score1);
                score2S = ConvertScore(score2);
                return score1S + " - " + score2S;
            }
            if (score1 == score2 && score1 > 3)
            {
                return "Draw";
            }
            if (score1 > score2 && score1 > 3)
            {
                return "Advantage player 1";
            }
            if (score2 > score1 && score2 > 3)
            {
                return "Advantage player 2";
            }


            return "";
        }
        public GameDecorator(BaseClassGame game)
        {
            _myGame = game; 
        }
    }
}
