using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    internal class WeightedMatrix
    {
        //Lab_10
        private int[,] matrix = null;
        private int n = 0;
        private int m = 0;

        int infinite = int.MaxValue;
        public int[,] CreateMatrix(FileViewer file, int[,] result)
        {
            this.n = file.GetN();
            this.m = file.GetM();

            int iterator = 0;

            int[] order = fillOrder(n);

            int[,] matrix = new int[n + 1, n + 1];

            bool isEqual = false;
            for (int i = 1; i < n + 1; i++)
            {
                for (int j = 1; j < n + 1; j++)
                {
                    isEqual = false;
                    int[] grid = { order[i], order[j] };
                    for (int k = 1; k < m + 1; k++)
                    {
                        if ((grid[0] == result[k, 0]) && (grid[1] == result[k, 1]))
                        {
                            isEqual = true;
                            iterator = k;
                            break;
                        }
                    }
                    if (isEqual)
                    {
                        matrix[i, j] = result[iterator, 2];
                    }
                    else if (i == j)
                    {
                        matrix[i, j] = 0;
                    }
                    else
                    {
                        matrix[i, j] = infinite;
                    }
                }
            }
            this.matrix = result;
            return matrix;
        }
        public int[] fillOrder(int n)
        {
            int[] order = new int[n + 1];
            for (int i = 1; i < n + 1; i++)
            {
                order[i] = i;
            }
            return order;
        }
        public void printMatrix(int[,] matrix, FileViewer file)
        {
            Console.Write("   |");
            for (int j = 1; j < file.GetN() + 1; j++)
            {
                Console.Write($"{j,2} |");
            }
            Console.WriteLine();

            for (int i = 1; i < file.GetN() + 1; i++)
            {
                Console.Write($"{i,2} |");
                for (int j = 1; j < file.GetN() + 1; j++)
                {
                    if (matrix[i, j] == int.MaxValue)
                    {
                        Console.Write(" * |");
                    }
                    else
                        Console.Write($"{matrix[i, j],2} |");
                }
                Console.WriteLine();
            }
        }
        public int GetN()
        {
            return this.n;
        }
        public int GetM()
        {
            return this.m;
        }
        public int[,] GetMatrix()
        {
            return this.matrix;
        }
    }
}