using System;

internal class TicTacToe
{
    private char[,] board = new char[3, 3];
    private bool flag = true;
    private Random random = new Random();

    public TicTacToe()
    {
        SetupBoard();
    }

    public void Play1V1()
    {
        DisplayBoard(board);

        for (int i = 0; i < 9; i++)
        {
            int x = 0, y = 0;

            if (flag)
            {
                UserInput(ref x, ref y, 'X', board);
                board[x, y] = 'X';
                DisplayBoard(board);
                flag = !flag;

                if (IsWon(board, 'X'))
                {
                    Console.WriteLine("Player X Won !!!");
                    return;
                }
            }
            else
            {
                UserInput(ref x, ref y, 'O', board);
                board[x, y] = 'O';
                DisplayBoard(board);
                flag = !flag;

                if (IsWon(board, 'O'))
                {
                    Console.WriteLine("Player O Won !!!");
                    return;
                }
            }
        }

        Console.WriteLine("Match Drawn!");
    }

    public void PlayComputer()
    {
        char user = random.Next(0, 2) == 0 ? 'X' : 'O';
        char bot = user == 'X' ? 'O' : 'X';

        Console.WriteLine($"You are playing as '{user}'");
        DisplayBoard(board);

        for (int i = 0; i < 9; i++)
        {
            int x = 0, y = 0;

            if (flag)
            {
                if (user == 'X')
                {
                    UserInput(ref x, ref y, user, board);
                    board[x, y] = user;
                    DisplayBoard(board);
                    flag = false;

                    if (IsWon(board, user))
                    {
                        Console.WriteLine("You Won!");
                        return;
                    }
                }
                else
                {
                    // Bot plays as X
                    if (!BotSmartMove('X'))
                        BotRandomMove('X');

                    DisplayBoard(board);
                    flag = false;

                    if (IsWon(board, 'X'))
                    {
                        Console.WriteLine("Bot (X) Won!");
                        return;
                    }
                }
            }
            else
            {
                if (user == 'O')
                {
                    UserInput(ref x, ref y, user, board);
                    board[x, y] = user;
                    DisplayBoard(board);
                    flag = true;

                    if (IsWon(board, user))
                    {
                        Console.WriteLine("You Won!");
                        return;
                    }
                }
                else
                {
                    // Bot plays as O
                    if (!BotSmartMove('O'))
                        BotRandomMove('O');

                    DisplayBoard(board);
                    flag = true;

                    if (IsWon(board, 'O'))
                    {
                        Console.WriteLine("Bot (O) Won!");
                        return;
                    }
                }
            }
        }

        Console.WriteLine("Match Drawn!");
    }

    private bool BotSmartMove(char ch)
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (board[row, col] != '_')
                    continue;

                board[row, col] = ch;

                if (IsWon(board, ch))
                {
                    return true;
                }

                board[row, col] = '_';
            }
        }

        return false;
    }

    private void BotRandomMove(char ch)
    {
        int x, y;
        do
        {
            x = random.Next(0, 3);
            y = random.Next(0, 3);
        }
        while (board[x, y] != '_');

        board[x, y] = ch;
    }

    private void UserInput(ref int x, ref int y, char ch, char[,] board)
    {
        bool valid = false;

        while (!valid)
        {
            Console.Write("Enter position for " + ch);
            string[] inputs = Console.ReadLine()?.Split();

            if (inputs?.Length != 2 ||
                !int.TryParse(inputs[0], out x) ||
                !int.TryParse(inputs[1], out y))
            {
                Console.WriteLine("Invalid input. Please enter two numbers.");
                continue;
            }

            if (x < 0 || x > 2 || y < 0 || y > 2)
            {
                Console.WriteLine("Coordinates out of range. Enter values between 0 and 2.");
                continue;
            }

            if (board[x, y] != '_')
            {
                Console.WriteLine("Cell is already occupied. Choose another.");
                continue;
            }

            valid = true;
        }
    }

    private void SetupBoard()
    {
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                board[i, j] = '_';
    }

    private void DisplayBoard(char[,] board)
    {
        Console.WriteLine();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
                Console.Write(board[i, j] + " ");
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    private bool IsWon(char[,] board, char ch)
    {
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == ch && board[i, 1] == ch && board[i, 2] == ch)
                return true;

            if (board[0, i] == ch && board[1, i] == ch && board[2, i] == ch)
                return true;
        }

        if (board[0, 0] == ch && board[1, 1] == ch && board[2, 2] == ch)
            return true;

        if (board[0, 2] == ch && board[1, 1] == ch && board[2, 0] == ch)
            return true;

        return false;
    }
}
