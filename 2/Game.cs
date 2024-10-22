using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLAYER;

namespace GAME
{
    enum GameState
    {
        Start,
        End
    }

    internal class Game
    {
        public int size;
        public Player cat;
        public Player mouse;
        public GameState state;

        public string inputFile;
        public string outFile;

        public Game(string inputFile, string outFile)
        {
            this.inputFile = inputFile;
            this.outFile = outFile;
            cat = new Player("Cat");
            mouse = new Player("Mouse");
            state = GameState.Start;
        }

        public void Run()
        {
            StreamReader reader = new StreamReader(inputFile);
            StreamWriter writer = new StreamWriter(outFile);
            size = int.Parse(reader.ReadLine());
            if (size > 10000 || size <= 0)
            {
                writer.Write("Ivalid Input!");
                reader.Close();
                writer.Close();
                return;
            }
            writer.Write("Cat and Mouse\n\nCat\tMouse\tDistance");
            writer.Write("\n------------------------\n");

            while (state != GameState.End && !reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] lineArr = line.Split();
                if (char.Parse(lineArr[0]) == 'P')
                {
                    if (mouse.location == cat.location)
                    {
                        mouse.state = State.Looser;
                        cat.state = State.Winner;
                        state = GameState.End;
                    }
                    DoPrintCommand(writer);
                    continue;
                }
                DoMoveCommand(char.Parse(lineArr[0]), int.Parse(lineArr[1]));
            }
            writer.Write("------------------------\n");
            writer.Write($"{"Distance traveled:"}\t{"Mouse"}\t{"Cat"}\n\t\t\t{GetDistance(mouse)}\t{GetDistance(cat)}");
            if (mouse.state == State.Looser)
            {
                writer.Write($"\n\n{"Mouse caught at: "}{mouse.location}");
            }
            else
            {
                cat.state = State.Looser;
                mouse.state = State.Winner;
                writer.Write($"\n\n{"Mouse evaded Cat"}");
            }

            reader.Close();
            writer.Close();
        }

        public void DoMoveCommand(char command, int steps)
        {
            switch (command)
            {
                case 'M': mouse.Move(steps, size);    break;
                case 'C': cat.Move(steps, size);    break;
            }
        }

        public void DoPrintCommand(StreamWriter writer)
        {
            if (cat.location == -1)
            {
                writer.Write($"{"??"}\t");
                if (mouse.location == -1)
                {
                    writer.Write($"{"??"}\n");
                }
                else
                {
                    writer.Write($"{mouse.location.ToString()}\n");
                }
            }
            else
            {
                writer.Write($"{cat.location.ToString()}\t");
                if (mouse.location == -1)
                {
                    writer.Write($"{"??"}\n");
                }
                else
                {
                    writer.Write($"{mouse.location.ToString()}\t{Math.Abs(cat.location - mouse.location)}\n");
                }
            }
        }

        public int GetDistance(Player player)
        {
            return player.distanceTraveled;
        }
    }
}
