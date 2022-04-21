using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    internal class DFS
    {
        //Lab_8
        string[,] result = null;
        int n = 0;

        public string[,] Search(AdjacencyMatrix adjacencyMatrix, int[,] matrix, int point)
        {
            Stack<int> stack = new Stack<int>();
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            this.n = adjacencyMatrix.GetN();

            String[,] resultTable = new string[n * 2 + 1, 3];

            dictionary.Add(point, 1);
            stack.Push(point);

            resultTable[1, 0] = stack.Peek().ToString();
            resultTable[1, 1] = 1.ToString();
            string joinedString = String.Join(",", stack);
            resultTable[1, 2] = joinedString;

            int DFCNum = 2;
            bool isFound = false;
            int pointer;

            for (int itr = 2; stack.Count > 0; itr++)
            {
                pointer = stack.Peek();
                isFound = false;
                for (int i = 1; i < n + 1; i++)
                {
                    if (matrix[pointer, i] == 1 && pointer != i)
                    {
                        if (!dictionary.ContainsKey(i))
                        {
                            dictionary.Add(i, DFCNum);
                            stack.Push(i);

                            resultTable[itr, 0] = i.ToString();
                            resultTable[itr, 1] = DFCNum.ToString();
                            DFCNum++;
                            isFound = true;
                            break;
                        }
                    }
                }
                if(!isFound)
                {
                    resultTable[itr, 0] = "-";
                    resultTable[itr, 1] = "-";
                    stack.Pop();
                }
                joinedString = String.Join(",", stack);
                resultTable[itr, 2] = joinedString;
            }
            this.result = resultTable;
            return resultTable;
        }
        public void PrintResult()
        {
            for (int i = 1; i < this.n * 2 + 1; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{this.result[i, j],20}");
                }
                Console.WriteLine();
            }
        }
    }
}
