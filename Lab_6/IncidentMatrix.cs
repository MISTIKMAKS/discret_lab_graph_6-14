using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    class IncidentMatrix
    {
        private int[,] matrix = null;
        private int n = 0;
        private int m = 0;
        public int[,] createMatrix(FileViewer file, int[,] matrix)
        {
            int[] order = fillOrder(file.GetN());
            this.n = file.GetN();
            this.m = file.GetM();
            int[,] result = new int[file.GetN() + 1, file.GetM() + 1];

            for (int i = 1; i < file.GetN() + 1; i++)
            {
                for (int j = 1; j < file.GetM() + 1; j++)
                {
                    int v = matrix[j, 0];
                    int u = matrix[j, 1];

                    if (order[i] == v && v == u)
                    {
                        result[i, j] = 2;
                    }
                    else if (order[i] == v)
                    {
                        result[i, j] = 1;
                    }
                    else if (order[i] == u)
                    {
                        result[i, j] = -1;
                    }
                    else
                    {
                        result[i, j] = 0;
                    }
                }
            }
            this.matrix = result;
            return result;
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
        public static void printMatrix(int[,] incidentMatrix, FileViewer file)
        {
            Console.Write("   | ");
            for (int j = 1; j < file.GetM() + 1; j++)
            {
                Console.Write($"{j,2} | ");
            }
            Console.WriteLine();
            for (int i = 1; i < file.GetN() + 1; i++)
            {
                Console.Write($"{i,2} | ");
                for (int j = 1; j < file.GetM() + 1; j++)
                {
                    Console.Write($"{incidentMatrix[i, j],2} | ");
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
