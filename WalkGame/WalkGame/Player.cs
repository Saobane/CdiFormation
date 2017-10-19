using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WalkGame
{
    public class Player
    {
        private int _position; 
        public int Pos { get { return _position; } set
        {
            _position = value;
            if (_position == 0) 
            this.Alive = false;
            
        } }

        public Player(int position)
        {
            if (position ==0)
            {
                throw new DeadPlayerException();
            }

            Pos = position;
            Alive = true;
        }


        public bool Alive { get; set; }
    }
}
