using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake_Game
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Beep();
            Console.Beep();
            Console.Title = "Snake Game by ImBahmanRanjbar";


            Coord gridDimensions = new Coord(50, 20);
            Coord snakePos = new Coord(10, 1);
            Random r = new Random();
            Coord applePos = new Coord(r.Next(1, gridDimensions.X - 1), r.Next(1, gridDimensions.Y - 1));
            int framedelaymilli = 100;
            Direction movementDirection = Direction.Down;
            List<Coord> snakePosHistory = new List<Coord>();
            int tailLenght = 0;
            int Score = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Score :  "+Score);
                snakePos.ApplyMovementDirection(movementDirection);
                for (int i = 0; i < gridDimensions.Y; i++)
                {

                    for (int j = 0; j < gridDimensions.X; j++)
                    {
                        Coord currentCoord = new Coord(j, i);
                        if (snakePos.Equals(currentCoord))
                        {
                            Console.Write("■");
                        }
                        else if (applePos.Equals(currentCoord) || snakePosHistory.Contains(currentCoord))
                        {
                            Console.Write("■");
                        }
                        else if (j == 0 || i == 0 || j == gridDimensions.X - 1 || i == gridDimensions.Y - 1)
                        {
                            Console.Write("#");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }
                if (snakePos.Equals(applePos))
                {
                   
                    tailLenght++;
                    Score++;
                    applePos = new Coord(r.Next(1, gridDimensions.X - 1), r.Next(1, gridDimensions.Y - 1));
                }
                else if (snakePos.X==0||snakePos.Y==0||snakePos.X==gridDimensions.X-1||snakePos.Y==gridDimensions.Y-1||snakePosHistory.Contains(snakePos))
                { Console.Beep();
                    Score = 0;
                    tailLenght = 0;
                    snakePos = new Coord(10, 1);
                    snakePosHistory.Clear();
                    movementDirection = Direction.Down;
                    continue;
                }
                snakePosHistory.Add(new Coord(snakePos.X, snakePos.Y));
                if (snakePosHistory.Count>tailLenght)
                {
                    snakePosHistory.RemoveAt(0);
                }

                DateTime time = DateTime.Now;
                while ((DateTime.Now-time).Milliseconds<framedelaymilli)
                {
                    if (Console.KeyAvailable)
                    {
                        ConsoleKey key = Console.ReadKey().Key;
                        switch (key)
                        {
                            case ConsoleKey.LeftArrow:
                                movementDirection = Direction.Left;
                                break;
                            case ConsoleKey.RightArrow:
                                movementDirection = Direction.Right;
                                break;
                            case ConsoleKey.UpArrow:
                                movementDirection = Direction.Up;
                                break;
                            case ConsoleKey.DownArrow:
                                movementDirection = Direction.Down;
                                break;
                        }
                    }
                }
                  
            }
        }
    }
}
