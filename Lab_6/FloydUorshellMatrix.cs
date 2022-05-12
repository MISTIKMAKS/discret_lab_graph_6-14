using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    internal class FloydUorshellMatrix
    {
        public FloydUorshellMatrix(WeightedMatrix weight, int[,] weightedMatrix)
        {
            int n = weight.GetN();
            int[,,] Matrix = new int[n + 1, n + 1, n + 1];
            int[,] Path = createPathMatrix(n);

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    Matrix[0, i, j] = weightedMatrix[i, j];
                }
            }

            for (int k = 1; k <= n; k++)
            {
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {
                        if (Matrix[k -1,  i, k] != int.MaxValue && Matrix[k - 1, k, j] != int.MaxValue)
                        {
                            if (Matrix[k -1, i, k] + Matrix[k - 1, k, j] < Matrix[k - 1, i, j])
                            {
                                Matrix[k, i, j] = Matrix[k - 1, i, k] + Matrix[k - 1, k, j];
                                Path[i, j] = k;
                            }
                            else
                            {
                                Matrix[k, i, j] = Matrix[k - 1, i, j];
                            }
                        }
                        else
                        {
                            Matrix[k, i, j] = Matrix[k - 1, i, j];
                        }
                    }
                }
                Console.WriteLine("");
                printMatrix(Matrix, n, k);
            }
            Console.WriteLine("");
            Console.WriteLine("Path matrix:");
            printPathMatrix(Path, n);
        }

        private int[,] createPathMatrix(int n)
        {
            int[,] T = new int[n + 1, n + 1];
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (i == j)
                    {
                        T[i, j] = 0;
                    }
                    else
                    {
                        T[i, j] = i;
                    }
                }
            }
            return T;
        }

        public static void printPathMatrix(int[,] matrix, int n)
        {
            Console.Write("   |");
            for (int j = 1; j < n + 1; j++)
            {
                Console.Write($"{j,2} |");
            }
            Console.WriteLine();

            for (int i = 1; i < n + 1; i++)
            {
                Console.Write($"{i,2} |");
                for (int j = 1; j < n + 1; j++)
                {
                    if (matrix[i, j] == int.MaxValue)
                    {
                        Console.Write(" - |");
                    }
                    else
                        Console.Write($"{matrix[i, j],2} |");
                }
                Console.WriteLine();
            }
        }

        public static void printMatrix(int[,,] matrix, int n, int k)
        {
            Console.Write("   |");
            for (int j = 1; j < n + 1; j++)
            {
                Console.Write($"{j,2} |");
            }
            Console.WriteLine();

            for (int i = 1; i < n + 1; i++)
            {
                Console.Write($"{i,2} |");
                for (int j = 1; j < n + 1; j++)
                {
                    if (matrix[k, i, j] == int.MaxValue)
                    {
                        Console.Write(" - |");
                    }
                    else
                        Console.Write($"{matrix[k, i, j],2} |");
                }
                Console.WriteLine();
            }
        }
    }
}
