using System;

namespace UR
{
public class RandomPlayer : Player
{
    public RandomPlayer(string pi) : base(pi) {}

    public override int[] nextMove(Board board)
    {
        int rol = roll();
        Console.WriteLine(rol);
        if (rol == 0)
        {
            int[] ret = {500,500};
            return ret;
        }
        if (canMove(rol, board) == false)
        {
            int[] ret = {1000,1000};
            return ret;
        }
        int left = 7 - board.ends(piece);
        int yet = board.starts(piece);
        Random rand = new Random();
        int check = rand.Next(left);
        int start;
        Console.WriteLine(piece + ": | left: " + left + " | yet: " + yet);
        if (check < yet && canStart(board, rol))
        {
            //Console.WriteLine("Check: " + check.ToString());
            start = -1;
            int[] moves = piececCanMove(-1, rol, board);
            int mov = 0;
            for(int i = 0; i < moves.Length; i++)
            {
                if(moves[i] != 0)
                {
                    mov = moves[i];
                }
            }
            int[] ret = {mov, start};
            return ret;
        }
        else
        {
            
            int[] moves = new int[left - yet];
            int cursor = 0;
            for(int i = 0; i < board.length; i++)
            {
                if(board.checkSpot(i, piece) == false)
                {
                    moves[cursor] = i;
                    //Console.WriteLine("Potential Move: " + i);
                    cursor++;
                }
            }
            while(true)
            {
                int val = rand.Next(moves.Length);
                int[] mos = piececCanMove(moves[val],rol,board);
                //Console.WriteLine("rand: " + val + " | move: " + moves[val]);
                start = moves[val];
                int mov = 0;
                for(int j = 0; j < mos.Length; j++)
                {
                    if(mos[j] != 0)
                    {
                        mov = mos[j];
                        //start = mos[j];
                    }
                }
                if(mov != 0)
                {
                    int[] ret = {mov, start};
                    return ret;
                }
            }           
        }
    }
}
}