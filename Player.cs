using System;
//using Board;

namespace UR
{
public class Player
{
    protected string piece;
    protected int numMoves;

	public Player(string pi)
	{
        if (pi != "X" && pi != "O")
        {
            Console.Write("Please pick X or O");
        }
        piece = pi;
        numMoves = 0;
	}

    public override string ToString()
    {
        return piece;
    }

    public string pieceChecker()
    {
        return piece;
    }

    public string oppChecker()
    {
        if(piece == "X")
        {
            return "O";
        }
        else
        {
            return "X";
        }
    }

    public Boolean canStart(Board board, int roll)
    {
        for(int i = 0; i < roll; i++)
        {
            if(board.checkSpot(i,piece))
            {
                return true;
            }
        }
        return false;
    }

    public int[] piececCanMove(int start, int move, Board board)
    {

        int[] moves = new int[move];
        if (start == -1)
        {
            for(int i = 0; i < move; i++)
            {
                if(board.checkSpot(i, piece))
                {
                    moves[i] = i + 1;
                }
            }
            return moves;
        }
        else if (start < board.length)
        {
            for(int i = 0; i < move; i++)
            {
                if(board.checkSpot(start + i + 1, piece))
                {
                    moves[i] = i + 1;
                }
            }
            return moves;
        }
        else
        {
            return moves;
        }
    }


    public Boolean canMove(int move, Board board)
    {
        
        if(board.starts(piece) > 0)
        {
            for(int i = 0; i < move; i++)
            {
                if (board.checkSpot(i, piece))
                {
                    return true;
                }
            }
        }

        for (int i = 0; i < board.length; i++)
        {
            if (board.checkSpot(i, piece) == false)
            {
                for (int j = 0; j < move; j++)
                {
                    if(board.checkSpot(i + move, piece))
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }


    protected int roll()
    {
        Random rand = new Random();
        int dis = rand.Next(16);
        if(dis == 0)
        {
            return 0;
        }
        else if (dis < 5)
        {
            return 1;
        }
        else if (dis < 11)
        {
            return 2;
        }
        else if (dis < 15)
        {
            return 3;
        }
        else 
        {
            return 4;
        }
    }

    public virtual int[] nextMove(Board board)
    {
        
        int rol = roll();
        if (canMove(rol, board) == false)
        {
            Console.WriteLine("Your roll was " + rol.ToString() + ", but you can't move anywhere.");
            int[] ret = {1000,1000};
            return ret;
        }
        while(true)
        {
            Console.WriteLine("Your roll is " + rol.ToString());
            Console.WriteLine("Enter the start space for the piece you want to move or -1 to move a new piece:");
            int start = Int32.Parse(Console.ReadLine());
            if (board.checkSpot(start,piece) == false)
            {
               Boolean val = false;
               int[] moves = piececCanMove(start, rol, board);
               for (int i = 0; i < moves.Length; i++)
               {
                   if (moves[i] != 0)
                   {
                       val = true;
                       Console.WriteLine("This piece can move " + moves[i] + " spaces.");
                   }
               }
                if (val == false)
                {
                    Console.WriteLine("There is nowhere for that piece to go! Please try again.");
                    continue;
                }
                Console.WriteLine("How many spaces do you want to move your piece?");
                int mov = Int32.Parse(Console.ReadLine());
                if(Array.IndexOf(moves, mov) == -1 || mov == 0)
                {
                    Console.WriteLine("That is not a valid move. Please try again.");
                }
                else
                {
                    int[] ret = {mov,start};
                    return ret;
                }

            }
            else
            {
                Console.WriteLine("There is no piece there! Please try again.");
            }
        }
    }
}
}