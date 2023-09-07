namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] matrix = new char[3, 3];
            bool isXTurn = true;

            while (true)
            {
                Console.Clear();
                PrintBoard(matrix);

                char currentPlayer = isXTurn ? 'X' : 'O';
                Console.WriteLine($"Player {currentPlayer}'s turn.");
                Console.Write("Enter row and column coordinates (separated by commas): ");
                string coordinate = Console.ReadLine();
                int[] c = coordinate.Split(',').Select(int.Parse).ToArray();

                if (c.Length == 2 && c[0] >= 0 && c[0] < 3 && c[1] >= 0 && c[1] < 3 && matrix[c[0], c[1]] == '\0')
                {
                    matrix[c[0], c[1]] = currentPlayer;
                    isXTurn = !isXTurn;

                    if (CheckWin(matrix, currentPlayer))
                    {
                        Console.Clear();
                        PrintBoard(matrix);
                        Console.WriteLine($"Player {currentPlayer} wins!");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates or the cell is already occupied. Please enter valid coordinates within the matrix bounds.");
                }

                if (IsBoardFull(matrix))
                {
                    Console.Clear();
                    PrintBoard(matrix);
                    Console.WriteLine("It's a draw!");
                    break;
                }
            }
        }
        static void PrintBoard(char[,] matrix)
        {
            Console.WriteLine("  0 1 2");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    char cellValue = matrix[i, j] == '\0' ? ' ' : matrix[i, j];
                    Console.Write(cellValue + " ");
                }
                Console.WriteLine();
            }
        }
        static bool CheckWin(char[,] matrix, char player)
        {
            for (int i = 0; i < 3; i++)
            {
                if ((matrix[i, 0] == player && matrix[i, 1] == player && matrix[i, 2] == player) ||
                    (matrix[0, i] == player && matrix[1, i] == player && matrix[2, i] == player))
                {
                    return true;
                }
            }

            return (matrix[0, 0] == player && matrix[1, 1] == player && matrix[2, 2] == player) ||
                   (matrix[0, 2] == player && matrix[1, 1] == player && matrix[2, 0] == player);
        }
        static bool IsBoardFull(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == '\0')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
