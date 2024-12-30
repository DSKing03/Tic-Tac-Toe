using System;

class Program
{
    static int[,] board = new int[3, 3];

    public static void Main()
    {
        Console.WriteLine("Welcome to tic-tac-toe!");
        InitializeGame();
        Player();
        Console.WriteLine("Game over!");
    }

    static void InitializeGame()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = 0; 
            }
        }
    }

    static void Player()
    {
        int currentPlayer = 1;
        bool gameRunning = true;

        while (gameRunning)
        {
            Game();

            if (currentPlayer == 1)
            {
                Console.Write("X");
            }
            else
            {
                Console.Write("O");
            }
            Console.Write("'s move > ");

            int position = Convert.ToInt32(Console.ReadLine());

            int row = (position - 1) / 3;
            int col = (position - 1) % 3;

            if (IsMoveLegal(row, col))
            {
                board[row, col] = currentPlayer;
                if (currentPlayer == 1)
                {
                    currentPlayer = 2;
                }
                else
                {
                    currentPlayer = 1;
                }
            }
            else
            {
                Console.WriteLine("Illegal move! Try again.");
            }

            if (IsBoardFull())
            {
                gameRunning = false;
            }
        }
    }

    static bool IsMoveLegal(int row, int col)
    {
        return row >= 0 && row < 3 && col >= 0 && col < 3 && board[row, col] == 0;
    }

    static bool IsBoardFull()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[i, j] == 0)
                {
                    return false;
                }
            }
        }
        return true;
    }

    static void Game()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[i, j] == 0)
                {
                    Console.Write(' ');
                }
                else if (board[i, j] == 1)
                {
                    Console.Write('X');
                }
                else
                {
                    Console.Write('O');
                }

                if (j < 2)
                {
                    Console.Write(" | ");
                }
            }
            if (i < 2)
            {
                Console.WriteLine("\n---+---+---");
            }
        }
        Console.WriteLine(); 
    }
}