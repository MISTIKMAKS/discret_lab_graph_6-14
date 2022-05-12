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
                        break;
                    }
                }
            }
            findPoints(w, weightMatrix, 3);
            Console.WriteLine("Weight: ");
            printVector(minWeight);

            Console.WriteLine("");

            Console.WriteLine("Path: ");
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
            int[] T = new int[weight.GetN() + 1];
            int[] Path = new int[weight.GetN() + 1];

            M.Add(a);
            T[a] = 0;

            for (int i = 1; i < weight.GetN() + 1; i++)
            {
                Path[i] = 0;
                if (i != a)
                {
                    T[i] = int.MaxValue;
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
                            if (T[v] > (T[x] + weightMatrix[x, v]))
                            {
                                T[v] = (T[x] + weightMatrix[x, v]);
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
                        if (T[v] < minWeight)
                        {
                            minWeight = T[v];
                            minPoint = v;
                        }
                    }
                }
                M.Add(minPoint);
                this.minWeight = T;
                this.minPath = Path;
                x = minPoint;
            }
        }
        public void printVector(int[] V)
        {
            for (int i = 1; i < V.Length; i++)
            {
                if (V[i] == int.MaxValue)
                {
                    Console.Write("{V" + i + ": " + "-" + "} ");
                }
                else
                {
                    Console.Write("{V" + i + ": " + V[i] + "} ");
                }
                Console.WriteLine();
            }
        }

        public void printVector(int[] V, int last)
        {
            for (int i = 1; i < V.Length; i++)
            {
                if (i == last)
                    if (V[i] == int.MaxValue)
                    {
                        Console.Write("{V" + i + ": " + "-" + "} ");
                    }
                    else
                    {
                        Console.Write("{V" + i + ": " + V[i] + "} ");
                    }
            }
            Console.WriteLine();
        }
    }
}
