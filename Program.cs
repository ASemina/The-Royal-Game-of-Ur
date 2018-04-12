using System;

namespace UR
{
    class Program
    {

        static void play(Player p1, Player p2)
        {
            Board b = new Board();
            Random rand = new Random();
            int check = rand.Next(2);
            if(check == 1)
            {
                Console.WriteLine(p1 + " will go first.");
            }
            else
            {
                Console.WriteLine(p2 + " will go first.");
            }
            while(true)
            {
                if(check == 1)
                {
                    int[] m = p1.nextMove(b);
                    if(m[0] == 1000)
                    {
                        Console.WriteLine("Nowhere to Move. Skipping turn.");
                        Console.WriteLine(b.ToString());
                    }
                    else if (m[0] == 500)
                    {
                        Console.WriteLine("Rolled a 0. Skipping turn.");
                        Console.WriteLine(b.ToString());
                    }
                    else
                    {
                        b.movePiece(m[1], m[0], p1.ToString());
                        Console.WriteLine(b.ToString());
                        if(b.isWin(p1.ToString()))
                        {
                            Console.WriteLine(p1 + " Wins!");
                            break;
                        }
                    }
                    int[] m2 = p2.nextMove(b);
                    if(m2[0] == 1000)
                    {
                        Console.WriteLine("Nowhere to Move. Skipping turn.");
                        Console.WriteLine(b.ToString());
                    }
                    else if (m2[0] == 500)
                    {
                        Console.WriteLine("Rolled a 0. Skipping turn.");
                        Console.WriteLine(b.ToString());
                    }
                    else
                    {
                        b.movePiece(m2[1], m2[0], p2.ToString());
                        Console.WriteLine(b.ToString());
                        if(b.isWin(p2.ToString()))
                        {
                            Console.WriteLine(p2 + " Wins!");
                            break;
                        }
                    }
                }
                else
                {
                    int[] m2 = p2.nextMove(b);
                    if(m2[0] == 1000)
                    {
                        Console.WriteLine("Nowhere to Move. Skipping turn.");
                        Console.WriteLine(b.ToString());
                    }
                    else if (m2[0] == 500)
                    {
                        Console.WriteLine("Rolled a 0. Skipping turn.");
                        Console.WriteLine(b.ToString());
                    }
                    else
                    {
                        b.movePiece(m2[1], m2[0], p2.ToString());
                        Console.WriteLine(b.ToString());
                        if(b.isWin(p2.ToString()))
                        {
                            Console.WriteLine(p2 + " Wins!");
                            break;
                        }
                    }
                    int[] m = p1.nextMove(b);
                    if(m[0] == 1000)
                    {
                        Console.WriteLine("Nowhere to Move. Skipping turn.");
                        Console.WriteLine(b.ToString());
                    }
                    else if (m[0] == 500)
                    {
                        Console.WriteLine("Rolled a 0. Skipping turn.");
                        Console.WriteLine(b.ToString());
                    }
                    else
                    {
                        b.movePiece(m[1], m[0], p1.ToString());
                        Console.WriteLine(b.ToString());
                        if(b.isWin(p1.ToString()))
                        {
                            Console.WriteLine(p1 + " Wins!");
                            break;
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Player p1 = new Player("X");
            RandomPlayer p2 = new RandomPlayer("O");
            RandomPlayer p3 = new RandomPlayer("X");
            play(p3,p2);
        }
    }
}
