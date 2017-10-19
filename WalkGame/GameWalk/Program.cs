using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using WalkGame;

namespace GameWalk
{
    class Program
    {
        static void Main(string[] args)
        {
            var player1 = new Player(-100);
            var player2 = new Player(4);
            var player3 = new Player(-7);
            var engine = new RandomEngine();
            var game= new Game(new List<Player>(){player1,player2,player3},engine );

            while (true)
            {
                game.Play();
                game.Players.ToList().ForEach(x =>
                {
                    Console.WriteLine(x.Pos);
                });
                if (game.IsOver)
                {
                    Console.WriteLine(" Fin du jeu");
                    Console.ReadLine();
                    break;
                }
            }



        }
    }
}
