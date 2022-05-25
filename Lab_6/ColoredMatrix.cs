using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    internal class ColoredMatrix
    {
        //Degree - степінь вершини (Скільком ребрам вона принадлежить)
        Dictionary<int, int> colorsDiction = new Dictionary<int, int>();

        public Dictionary<int, int> getColorsDiction()
        {
            return colorsDiction;
        }

        public ColoredMatrix(int[,] matrix_adj, AdjacencyMatrix matrix, int[,] result_adj, FileViewer file_adj)
        {
            ColorMatrix(matrix_adj, matrix, result_adj, file_adj);
        }

        public void ColorMatrix(int[,] matrix_adj, AdjacencyMatrix matrix, int[,] result_adj, FileViewer file_adj)
        {
            Queue<int> points = sortDegree(matrix, result_adj, file_adj);
            Dictionary<int, int> colors = new Dictionary<int, int>();

            int[,] aMatrix = matrix_adj;

            int color = 0;
            while (points.Count != 0)
            {
                color++;
                int point = points.Dequeue();
                colors.Add(point, color);

                bool canBeColored;
                foreach (int elem in points)
                {
                    canBeColored = true;

                    foreach (int e in colors.Keys)
                    {
                        if (colors[e] == color)
                        {
                            if (aMatrix[elem, e] == 1 || aMatrix[e, elem] == 1)
                            {
                                canBeColored = false;
                            }
                        }
                    }
                    if (canBeColored)
                    {
                        colors.Add(elem, color);
                        points = new Queue<int>(points.Where(x => x != elem));
                    }
                }
            }
            var colorsDiction = colors.ToLookup(x => x.Value, x => x.Key).Where(x => x.Count() > 1);
            foreach (var item in colorsDiction)
            {
                var keys = item.Aggregate("", (s, v) => s + ", " + v);
                var message = "Points That Have The Color [" + item.Key + "] Are :" + keys;
                Console.WriteLine(message);
            }
        }

        public Queue<int> sortDegree(AdjacencyMatrix matrix, int[,] result_adj, FileViewer file_adj)
        {
            Queue<int> queue = new Queue<int>();

            int[,] degrees = GraphCharacter.FindInnerAndOuter(matrix, result_adj, file_adj);

            int[,] degree = new int[matrix.GetN() + 1, 2];

            for (int i = 1; i < matrix.GetN() + 1; i++)
            {
                degree[i, 0] = i;
                degree[i, 1] = degrees[i, 1] + degrees[i, 2];
                Console.WriteLine("Point: " + i + " Degree: " + degree[i, 1]);
            }
            Console.WriteLine("");
            while (queue.Count() != matrix.GetN())
            {
                int max = -1;
                int maxPoint = 0;

                for (int i = 1; i < matrix.GetN() + 1; i++)
                {
                    if (!queue.Contains(i))
                    {
                        if (degree[i, 1] > max)
                        {
                            maxPoint = degree[i, 0];
                            max = degree[i, 1];
                        }
                    }
                }
                if(maxPoint != 0)
                {
                    queue.Enqueue(maxPoint);
                }
            }
            return queue;
        }
    }
}
