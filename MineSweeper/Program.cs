using System;
using System.Collections.Generic;

public class MineSweeper
{
    public MineSweeper()
    {
    }

    public static void Main(string[] args)
    {
        Random r = new Random();
        int mineCount = 0;
        int[,] map = new int[10, 10];
        int revealed = 0;
        List<string> inputs = new List<string>();

        int y, x;
        for (y = 0; y < map.GetLength(0); y++)
        {
            for (x = 0; x < map.GetLength(1); x++)
            {
                map[y, x] = r.Next(4) - 3;
                if (map[y, x] == 0)
                {
                    mineCount++;
                }
            }
        }

        while (revealed < 100 - mineCount)
        {
            Console.WriteLine("   A  B  C  D  E  F  G  H  I  J");

            for (y = 0; y < map.GetLength(0); y++)
            {
                Console.Write($"{y} ");

                for (x = 0; x < map.GetLength(1); x++)
                {
                    switch (map[y, x])
                    {
                        case 1:
                            Console.Write("[*]");
                            break;
                        case 2:
                            Console.Write("[-]");
                            break;
                        default:
                            Console.Write("[ ]");
                            break;
                    }
                }

                Console.WriteLine();
            }

            double percent = (double)(100 * revealed) / (double)(100 - mineCount);
            string xxx = $"You have revealed: {revealed} / {100 - mineCount} ({percent:0.00}%) of the map";
            Console.WriteLine(xxx);
            Console.WriteLine($"There are: {mineCount} mines still hidden.");

            string userInput;
            int col, row;
            do
            {
                do
                {
                    Console.WriteLine("Where do you want to search?? Type a letter (A-J) followed by a number (0-9)...");
                    userInput = Console.ReadLine().ToUpper();
                    col = userInput[0] - 'A';
                    row = userInput[1] - '0';
                } while (col < 0);
            } while (col > 9 || row < 0 || row > 9 || inputs.Contains(userInput));

            inputs.Add(userInput);
            if (map[row, col] == 0)
            {
                map[row, col] = 1;
                Console.WriteLine("That's a mine.. GAME OVER!!");
                break;
            }

            if (map[row, col] == -1)
            {
                map[row, col] = 2;
                revealed++;
            }
            else
            {
                int i, j;
                if (map[row, col] == -2)
                {
                    for (i = row - 1; i <= row + 1; i++)
                    {
                        for (j = col - 1; j <= col + 1; j++)
                        {
                            if (i >= 0 && i < map.GetLength(0) && j >= 0 && j < map.GetLength(1))
                            {
                                if (map[i, j] == 0)
                                {
                                    map[i, j] = 1;
                                }
                                else
                                {
                                    map[i, j] = 2;
                                    revealed++;
                                }
                            }
                        }
                    }
                }
                else if (map[row, col] == -3)
                {
                    for (i = row - 2; i <= row + 2; i++)
                    {
                        for (j = col - 2; j <= col + 2; j++)
                        {
                            if (i >= 0 && i < map.GetLength(0) && j >= 0 && j < map.GetLength(1))
                            {
                                if (map[i, j] == 0)
                                {
                                    map[i, j] = 1;
                                }
                                else
                                {
                                    map[i, j] = 2;
                                    revealed++;
                                }
                            }
                        }
                    }
                }
            }

            if (revealed == 100 - mineCount)
            {
                Console.WriteLine("Congrats!! You have swept all the area!");
            }
        }
    }
}

