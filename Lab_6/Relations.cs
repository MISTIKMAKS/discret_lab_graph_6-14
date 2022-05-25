using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    internal class Relations
    {
        //private bool isAsymetrical;
        private bool isTransitive;
        private bool isAsymetricalDuble;

        public Relations(int[,] matrix_adj, AdjacencyMatrix matrix)
        {
            //isAsymetrical = checkAsymetrical(matrix_adj, matrix);
            isAsymetricalDuble = checkAsymetricalDuble(matrix_adj, matrix);
            isTransitive = checkTransitive(matrix_adj, matrix);

            //Console.WriteLine("Asymetrical: " + isAsymerical);
            Console.WriteLine("");
            Console.WriteLine("Asymetrical: " + isAsymetricalDuble);
            Console.WriteLine("Transitive: " + isTransitive);
        }

        private bool checkAsymetricalDuble(int[,] matrix_adj, AdjacencyMatrix adjMatrix)
        {
            int n = adjMatrix.GetN();
            int[,] matrix = matrix_adj;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if ((matrix[i, j] == 1 && matrix[j, i] == 0) || (matrix[i, j] == 0 && matrix[j, i] == 1))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool checkAsymetrical(int[,] matrix_adj, AdjacencyMatrix adjMatrix)
        {
            int n = adjMatrix.GetN();
            int[,] matrix = matrix_adj;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (matrix[i, j] == 1 && matrix[j, i] == 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool checkTransitive(int[,] matrix_adj, AdjacencyMatrix adjMatrix)
        {
            int n = adjMatrix.GetN();
            int[,] matrix = matrix_adj;

            for (int i = 1; i < n; ++i)
                for (int j = 1; j < n; ++j)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    if (matrix[i, j] == 0)
                    {
                        continue;
                    }
                    for (int k = 0; k < n; ++k)
                    {
                        if (k == i || k == j)
                        {
                            continue;
                        }
                        if (matrix[j, k] == 0)
                        {
                            continue;
                        }

                        if (matrix[i, k] == 0)
                        {
                            return false;
                        }
                    }
                }
            return true;
        }
    }
}
