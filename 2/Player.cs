using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAME;

namespace PLAYER
{
    enum State
    {
        Winner,
        Looser,
        Playing,
        NotInGame
    }

    internal class Player
    {
        public string name;
        public int location;
        public State state = State.NotInGame;
        public int distanceTraveled = 0;

        public Player(string name)
        {
            this.name = name;
            this.location = -1;
        }

        public void Move(int steps, int size)
        {
            distanceTraveled += Math.Abs(steps);

            if (location == -1)
            {
                location = 0;
                state = State.Playing;
                distanceTraveled = 0;
            }
            location += steps;
            if (location <= 0)
            {
                location += size;
            }
            else if (location > size)
            {
                location -= size;
            }
        }
    }
}
