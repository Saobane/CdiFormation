using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WalkGame
{
  public   class Game
    {
        public int PlayerNumber { get; set; }
        private IMoveEngine Engine { get; set; }
        public IEnumerable<Player> Players { get; private set; }
        public bool IsOver {
            get
            {
                return Players.Where(x => x.Alive).Count() == 0;
                
            }
        }
        public Game(IEnumerable<Player> players, IMoveEngine engine)
        {
            PlayerNumber = players.Count();
            Players = players;
            Engine = engine;
            if (players == null || players.Count() == 0)
            {
                throw new EmptyGameException();
            }
        }

        internal bool ContainsPlayer(Player player)
        {
            return Players.Contains(player);

        }

        public void Play()
        {
            
            Players.ToList().ForEach(x =>
            {
                if (x.Alive)
                {
                    x.Pos += Engine.Play();
                }
                

            });
        }

        
    }
}
