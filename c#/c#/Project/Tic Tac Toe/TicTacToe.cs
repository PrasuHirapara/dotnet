using System;

internal class TicTacToe
{
    private char[,] board = new char[3, 3];
    private bool flag = true;

    public TicTacToe()
    {
        SetupBoard();
    }

    public void Play1V1()
    {
        DisplayBoard(board);

        for (int i = 0; i < 9; i++)
        {
            int x, y;

            if (flag) 
            {
                Console.Write("Enter position for X : ");
                x = int.Parse(Console.ReadLine());
                y = int.Parse(Console.ReadLine());

                while (board[x, y] != '_')
                {
                    Console.Write("Enter valid input : ");
                    x = int.Parse(Console.ReadLine());
                    y = int.Parse(Console.ReadLine());
                }

                board[x, y] = 'X';
                DisplayBoard(board);
                flag = !flag;

                if (IsWon(board, 'X'))
                {
                    Console.WriteLine("Player X Won !!!");
                    break;
                }
            } 
            else
            {
                Console.Write("Enter position for O : ");
                x = int.Parse(Console.ReadLine());
                y = int.Parse(Console.ReadLine());

                while (board[x, y] != '_')
                {
                    Console.Write("Enter valid input : ");
                    x = int.Parse(Console.ReadLine());
                    y = int.Parse(Console.ReadLine());
                }

                board[x, y] = 'O';
                DisplayBoard(board);
                flag = !flag;

                if (IsWon(board, 'O'))
                {
                    Console.WriteLine("Player O Won !!!");
                    break;
                }
            }
        }
    }

    private void SetupBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = '_';
            }
        }
    }

    private void DisplayBoard(char[,] board)
    {
        for(int i = 0;i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                Console.Write(board[i, j]+ " ");
            }
            Console.WriteLine();
        }
    }

    private bool IsWon(char[,] board, char ch)
    {
        bool temp = false;

        for (int i = 0; i < 3; i++)
        {
            // checking each row
            if (board[i, 0] == ch && board[i, 1] == ch && board[i, 2] == ch)
            {
                temp = true;
            }

            // checking each col
            if (board[0, i] == ch && board[1, i] == ch && board[2, i] == ch)
            {
                temp = true;
            }
        }

        // checking l-r diagonal
        if(board[0, 0] == ch && board[1, 1] == ch && board[2, 2] == ch)
        {
            temp = true;
        }

        // checking r-l diagonal
        if (board[0, 2] == ch && board[1, 1] == ch && board[2, 0] == ch)
        {
                temp = true;
        }

        if (temp)
        {
            SetupBoard();
        }

        return temp;
    }

}
