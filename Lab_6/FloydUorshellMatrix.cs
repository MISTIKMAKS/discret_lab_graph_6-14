using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    internal class FloydUorshellMatrix
    {
        private int[,,] minPathMatrix;
        private int[,] pathMatrix;
        private int infinity = int.MaxValue;

        public FloydUorshellMatrix(WeightedMatrix weightedMatrix)
        {
            int n = weightedMatrix.GetN();
            int[,,] matrix = new int[n + 1, n + 1, n + 1];
            int[,] weightMatrix = weightedMatrix.GetMatrix();

            for (int c = 1; c < n + 1; c++)
            {
                for (int r = 1; r < n + 1; r++)
                {
                    for (int x = 1; x < n + 1; x++)
                    {
                        matrix[c, r, x] = weightMatrix[r, x];
                    }
                }
            }

            int[,] P = new int[n + 1, n + 1];
            for (int i = 1; i < n + 1; i++)
            {
                for (int j = 1; j < n + 1; j++)
                {
                    if (i == j)
                    {
                        P[i, j] = 0;
                    }
                    else
                    {
                        P[i, j] = 1;
                    }
                }
            }

            for (int k = 1; k < n + 1; k++)
            {
                for (int i = 1; i < n + 1; i++)
                {
                    for (int j = 1; j < n + 1; j++)
                    {
                        if (matrix[k - 1, i, k] != infinity && matrix[k - 1, k, j] != infinity)
                        {
                            if ((matrix[k - 1, i, k] + matrix[k - 1, k, j] < matrix[k - 1, i, j]))
                            {
                                matrix[k, i, j] = (matrix[k - 1, i, k] + matrix[k - 1, k, j]);
                                P[i, j] = k;
                            }
                        }
                    }
                }
                Console.WriteLine("k: " + k);
                printMatrix(matrix, weightedMatrix, k);
            }
        }
        public static void printMatrix(int[,,] matrix, WeightedMatrix weightedMatrix, int k)
        {
            Console.Write("   |");
            for (int j = 1; j < weightedMatrix.GetN() + 1; j++)
            {
                Console.Write($"{j,2} |");
            }
            Console.WriteLine();

            for (int i = 1; i < weightedMatrix.GetN() + 1; i++)
            {
                Console.Write($"{i,2} |");
                for (int j = 1; j < weightedMatrix.GetN() + 1; j++)
                {
                    if (matrix[k, i, j] == int.MaxValue)
                    {
                        Console.Write(" * |");
                    }
                    else
                    {
                        Console.Write($"{matrix[k, i, j],2} |");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
