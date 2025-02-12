using System;

namespace TicTacToe
{
    class Program
    {
        static int[,] board = new int[3, 3];

        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Tic-Tac-Toe ===");
                Console.WriteLine("1. New Game");
                Console.WriteLine("2. About the Author");
                Console.WriteLine("3. Exit");
                Console.Write("> ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    StartNewGame();
                }
                else if (choice == "2")
                {
                    DisplayAbout();
                }
                else if (choice == "3")
                {
                    if (ConfirmExit())
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Press Enter to try again...");
                    Console.ReadLine();
                }
            }
        }

        static void StartNewGame()
        {
            InitializeGame();
            int currentPlayer = 1;

            while (true)
            {
                Console.Clear();
                DisplayBoard();

                int winner = CheckWinner();
                if (winner != 0)
                {
                    Console.WriteLine($"{(winner == 1 ? "X" : "O")} won!");
                    Console.WriteLine("[Press Enter to return to main menu...]");
                    Console.ReadLine();
                    break;
                }

                if (IsBoardFull())
                {
                    Console.WriteLine("It's a draw!");
                    Console.WriteLine("[Press Enter to return to main menu...]");
                    Console.ReadLine();
                    break;
                }

                Console.Write($"{(currentPlayer == 1 ? "X" : "O")}'s move (1-9) > ");
                if (int.TryParse(Console.ReadLine(), out int position) && position >= 1 && position <= 9)
                {
                    int row = (position - 1) / 3;
                    int col = (position - 1) % 3;

                    if (IsMoveLegal(row, col))
                    {
                        board[row, col] = currentPlayer;
                        currentPlayer = (currentPlayer == 1) ? 2 : 1;
                    }
                    else
                    {
                        Console.WriteLine("Illegal move! Try again.");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input! Try again.");
                    Console.ReadLine();
                }
            }
        }

        static void DisplayAbout()
        {
            Console.Clear();
            Console.WriteLine("=== Tic-Tac-Toe Game ===");
            Console.WriteLine("Author: Dogus SURMELIOGLU");
            Console.WriteLine("[Press Enter to return to main menu...]");
            Console.ReadLine();
        }

        static bool ConfirmExit()
        {
            Console.Write("Are you sure you want to quit? [y/n] > ");
            return Console.ReadLine().ToLower() == "y";
        }

        static void InitializeGame()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    board[i, j] = 0;
        }

        static bool IsMoveLegal(int row, int col)
        {
            return row >= 0 && row < 3 && col >= 0 && col < 3 && board[row, col] == 0;
        }

        static bool IsBoardFull()
        {
            foreach (int cell in board)
                if (cell == 0) return false;
            return true;
        }

        static int CheckWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] && board[i, 0] != 0)
                    return board[i, 0];
                if (board[0, i] == board[1, i] && board[1, i] == board[2, i] && board[0, i] != 0)
                    return board[0, i];
            }

            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != 0)
                return board[0, 0];
            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[0, 2] != 0)
                return board[0, 2];

            return 0;
        }

        static void DisplayBoard()
        {
            Console.WriteLine("\n  1 | 2 | 3 ");
            Console.WriteLine(" ---+---+---");
            Console.WriteLine("  4 | 5 | 6 ");
            Console.WriteLine(" ---+---+---");
            Console.WriteLine("  7 | 8 | 9 \n");

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == 0)
                        Console.Write("   ");
                    else if (board[i, j] == 1)
                        Console.Write(" X ");
                    else
                        Console.Write(" O ");

                    if (j < 2)
                        Console.Write("|");
                }
                if (i < 2)
                    Console.WriteLine("\n---+---+---");
            }
            Console.WriteLine();
        }
    }
}
