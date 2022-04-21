using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    internal class GraphCharacter
    {
        //AdjacencyMatrix Lab_7
        public static int[,] FindInnerAndOuter(AdjacencyMatrix adjacencyMatrix, int[,] matrix)
        {
            int n = adjacencyMatrix.GetN();
            int m = adjacencyMatrix.GetM();
            //int[,] matrix = adjacencyMatrix.GetMatrix();

            int tmp_inner;
            int tmp_outer;

            int[,] result = new int[n + 1, 3];

            for (int i = 1; i < n + 1; i++)
            {
                tmp_inner = 0;
                tmp_outer = 0;
                for (int j = 1; j < n + 1; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        tmp_inner += matrix[j, i];
                        tmp_outer += matrix[i, j];
                    }
                    result[i, 0] = i;
                    result[i, 1] = tmp_outer;
                    result[i, 2] = tmp_inner;
                }
            }
            return result;
        }

        public static int isHomogen(AdjacencyMatrix adjacencyMatrix, int[,] tmp_Matrix)
        {
            for (int i = 1; i < adjacencyMatrix.GetN() + 1; i++)
            {
                if ((i + 1) < adjacencyMatrix.GetN())
                {
                    if (!(tmp_Matrix[i, 1] == tmp_Matrix[i + 1, 1]))
                    {
                        return 0;
                    }

                    if (!(tmp_Matrix[i, 2] == tmp_Matrix[i + 1, 2]))
                    {
                        return 0;
                    }
                }
            }
            return tmp_Matrix[1, 1];
        }
        public static void isIsolated(AdjacencyMatrix adjacencyMatrix, int[,] tmp_Matrix)
        {
            bool Isolated = false;
            for (int i = 1; i < adjacencyMatrix.GetN() + 1; i++)
            {
                if (tmp_Matrix[i, 1] == 0 && tmp_Matrix[i, 2] == 0)
                {
                    Console.WriteLine(i + " Is Isolated Point");
                    Isolated = true;
                }
            }
            if(!Isolated)
            {
                Console.WriteLine("There Is No Isolated Points");
            }
        }
        public static void isHanged(AdjacencyMatrix adjacencyMatrix, int[,] tmp_Matrix)
        {
            bool Hanged = false;
            for (int i = 1; i < adjacencyMatrix.GetN() + 1; i++)
            {
                if (tmp_Matrix[i, 1] == 1 && tmp_Matrix[i, 2] == 0)
                {
                    Console.WriteLine(i + " Is Hanging Point");
                    Hanged = true;
                }
            }
            if (!Hanged)
            {
                Console.WriteLine("No Hanged Points");
            }
        }
    }
}
