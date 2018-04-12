using System;
using System.Collections;

namespace UR{
public class Board
{
    public string[,] board;
    public int length = 14;
    Hashtable start = new Hashtable();
    Hashtable end = new Hashtable();

	public Board()
	{
        board = new string[2, length];
        for(int i = 0; i < 2; i++)
        {
            for(int j = 0; j < length; j++)
            {
                board[i, j] = "E";
            }
        }
        start.Add("X", 7);
        start.Add("O", 7);
        end.Add("X", 0);
        end.Add("O", 0);
	}


    public int starts(string piece)
    {
        return (int)start[piece];
    }


    public int ends(string piece)
    {
        return (int)end[piece];
    }

    public string raw()
    {
        string st = "";

        for(int i = 0; i < 2; i++)
        {
            for(int j = 0; j < length; j++)
            {
                st += board[i,j];
            }
            st += "\n";
        }
        return st;
    }

    public override string ToString()
    {
        
         string[,] pri = new string[3,length-6];
         for(int i = 0; i < pri.GetLength(1); i++)
         {
             if(i < 4)
             {
                pri[0,i] = board[0,3-i];
                pri[1,i] = helper(board[0, i + 4], board[1, i + 4]);
                pri[2,i] = board[1,3-i];
             }
             else if(i < pri.GetLength(1) - 2)
             {
                 pri[0,i] = " ";
                 //Console.WriteLine(pri.GetLength(1));
                 pri[1,i] = helper(board[0, i + 4], board[1, i + 4]);
                 pri[2,i] = " ";
             }
             else
             {
                pri[0,i] = board[0, 6 + (length - i) - 1];
                pri[1,i] = helper(board[0, i + 4], board[1, i + 4]);
                pri[2,i] = board[1, 6 + (length - i) - 1];
             }
             
         }

         string st = "";
         for(int i = 0; i < 3; i++)
         {
             for(int j = 0; j < pri.GetLength(1); j++)
             {
                 st += pri[i,j];
             }
             st += "\n";
         }
         return st;
    }

    private string helper(string a, string b)
    {
        if(a == "E")
        {
            return b;
        }
        else
        {
            return a;
        }
    }

    public Boolean checkSpot(int spot, string piece)
    {
        int pos;
        if (piece == "X")
        {
            pos = 0;
        }
        else
        {
            pos = 1;
        }
        
        if (spot == -1)
        {
            if ((int)start[piece] <= 0) 
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
        else if (spot >= length)
        {
            return true;
        }
        //Console.Write(spot);
        else if (board[pos, spot] == piece)
        {
            return false;
        }
        else
        {
            return true;
        }
    }


    public string oppPiece(string piece)
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
    

    public Boolean movePiece(int begin, int movement, string piece)
    {
        int pos;
        if(piece == "X")
        {
            pos = 0;
        }
        else
        {
            pos = 1;
        }
        if (begin == -1)
        {
            if((int)start[piece] == 0)
            {
                return false;
            }
            int st = (int)start[piece];
            start.Remove(piece);
            start.Add(piece, st - 1);
            board[pos, movement - 1] = piece;
            return true;
        }
        else if (begin + movement >= length)
        {
            if(board[pos,begin] == "E")
            {
                return false;
            }
            board[pos, begin] = "E";
            int en = (int)end[piece];
            end.Remove(piece);
            end.Add(piece, en + 1);
            return true;
        }
        else
        {
            if (board[pos, begin] == "E")
            {
                return false;
            }
            board[pos, begin] = "E";
            string oppiece = oppPiece(piece);
            if (checkSpot(begin + movement, oppiece) == false && (begin + movement >= 4 && begin + movement <= 11))
            {
                int tem = (int)start[oppiece];
                tem++;
                start.Remove(oppiece);
                start.Add(oppiece, tem);
                board[Math.Abs(pos - 1), begin + movement] = "E";
            }
            board[pos, begin + movement] = piece;
            return true;
        }
    }

    public Boolean isWin(string piece)
    {
        if ((int)end[piece] == 7)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
}