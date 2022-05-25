using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    internal class DeykstraMatrix
    {
        int[] minPath;
        int[] minWeight;

        public DeykstraMatrix(WeightedMatrix w, int[,] weightMatrix)
        {
            for (int i = 1; i <= w.GetN(); i++)
            {
                for (int j = 1; j <= w.GetN(); j++)
                {
                    if (weightMatrix[i, j] < 0)
                    {
                        //throw new Exception("Element must be > 0");
                        Console.WriteLine("Element must be > 0");
                        break;
                    }
                }
            }
            findPoints(w, weightMatrix, 1);
            Console.WriteLine("Path Weight: ");
            printVector(minWeight);

            Console.WriteLine("");

            Console.WriteLine("Path Point: ");
            printVector(minPath);

            /*
            findPoints(w, weightMatrix, 3);
            Console.WriteLine("Weight: ");
            printVector(minWeight, 5);

            Console.WriteLine("");

            Console.WriteLine("Path: ");
            printVector(minPath, 5);
            */
        }

        private void findPoints(WeightedMatrix weight, int[,] weightMatrix, int a)
        {
            HashSet<int> M = new HashSet<int>();
            int[] Point = new int[weight.GetN() + 1];
            int[] Path = new int[weight.GetN() + 1];

            M.Add(a);
            Point[a] = 0;

            for (int i = 1; i < weight.GetN() + 1; i++)
            {
                Path[i] = 0;
                if (i != a)
                {
                    Point[i] = int.MaxValue;
                }
            }

            int x = a;
            for (int i = 1; i < weight.GetN() + 1; i++)
            {
                for (int v = 1; v < weight.GetN() + 1; v++)
                {
                    if (weightMatrix[x, v] > 0 && weightMatrix[x, v] != int.MaxValue)
                    {
                        if (!M.Contains(v))
                        {
                            if (Point[v] > (Point[x] + weightMatrix[x, v]))
                            {
                                Point[v] = (Point[x] + weightMatrix[x, v]);
                                Path[v] = x;
                            }
                        }
                    }
                }
                int minWeight = int.MaxValue;
                int minPoint = 0;

                for (int v = 1; v < weight.GetN() + 1; v++)
                {
                    if (!M.Contains(v))
                    {
                        if (Point[v] < minWeight)
                        {
                            minWeight = Point[v];
                            minPoint = v;
                        }
                    }
                }
                M.Add(minPoint);
                this.minWeight = Point;
                this.minPath = Path;
                x = minPoint;
            }
        }
        public void printVector(int[] Vector)
        {
            for (int i = 1; i < Vector.Length; i++)
            {
                if (Vector[i] == int.MaxValue)
                {
                    Console.Write("[Vector" + i + ": " + "-" + "] ");
                }
                else
                {
                    Console.Write("[Vector" + i + ": " + Vector[i] + "] ");
                }
                Console.WriteLine();
            }
        }

        public void printVector(int[] Vector, int last)
        {
            for (int i = 1; i < Vector.Length; i++)
            {
                if (i == last)
                    if (Vector[i] == int.MaxValue)
                    {
                        Console.Write("[Vector" + i + ": " + "-" + "] ");
                    }
                    else
                    {
                        Console.Write("[Vector" + i + ": " + Vector[i] + "] ");
                    }
            }
            Console.WriteLine();
        }
    }
}
