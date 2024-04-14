public class CycleDetection
{
    public static bool HasCycle(int[,] matrix, int start, int end)
    {
        int n = end - start;
        if (n < 3)
        {
            return false;
        }

        int mid = start + n / 2;


        bool hasLeftCycle = HasCycle(matrix, start, mid);
        bool hasRightCycle = HasCycle(matrix, mid, end);
        if(hasLeftCycle || hasRightCycle==true )
        {
            return true;
        }

        for (int i = start; i < mid; i++)
        {
            for (int j = mid; j < end; j++)
            {
                if (matrix[i, j] == 1 && matrix[j, (i + 1) % n] == 1 && matrix[(i + 1) % n, i] == 1)
                {
                    return true;
                }
                if (matrix[j, i] == 1 && matrix[(i + 1) % n, j] == 1 && matrix[i, (i + 1) % n] == 1)
                {
                    return true;
                }
            }
        }

      return false;
    }

    public static bool HasCycleWrapper(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        return HasCycle(matrix, 0, n);
    }

    public static void Main(string[] args)
    {
        int n;


        n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];


        for (int i = 0; i < n; i++)
        {
            string[] row = Console.ReadLine().Split(' ');
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = int.Parse(row[j]);
            }
        }

        if (HasCycleWrapper(matrix))
        {
            Console.WriteLine("YES");
        }
        else
        {
            Console.WriteLine("NO");
        }
    }
}
