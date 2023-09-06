namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] matrix = new char[3, 3];
            Console.Write("Enter row and column coordinates (separated by commas): ");
            string coordinate = Console.ReadLine();
            int[] c = coordinate.Split(',').Select(int.Parse).ToArray();

            if (c.Length == 2 && c[0] >= 0 && c[0] < 3 && c[1] >= 0 && c[1] < 3)
            {
                matrix[c[0], c[1]] = 'x';
            }
            else
            {
                Console.WriteLine("Invalid coordinates. Please enter valid coordinates within the matrix bounds.");
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "  ");
                }
                Console.Write("\n");
            }
        }
    }
}