namespace CodeWarsProject;

public class KataTicTacToe
{
    public int IsSolved(int[,] board)
    {
        int d1 = 1, d2 = 1;
        bool empty = false;
        for (int i = 0; i < 3; i++)
        {
            d1 *= board[i, i];
            d2 *= board[2 - i, i];
            int row = 1, col = 1;
            for (int j = 0; j < 3; j++)
            {
                row *= board[i, j];
                col *= board[j, i];
            }
            if (row == 1 || col == 1) return 1;
            if (row == 8 || col == 8) return 2;
            if (row == 0 || col == 0) empty = true;           
        }
        if (d1 == 1 || d2 == 1) return 1;
        if (d1 == 8 || d2 == 8) return 2;
        if (empty) return -1;
        return 0;
    }
}