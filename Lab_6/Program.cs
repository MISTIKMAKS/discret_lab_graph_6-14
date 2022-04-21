using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    class Program
    {
        static void Main(string[] args)
        {
            FileViewer file = new FileViewer();
            int[,] result = file.ReadFile();

            /*for (int i = 1; i < 21; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(result[i, j] + " ");
                }
                Console.WriteLine();
            }*/

            int choice;

            IncidentMatrix incMatrix = new IncidentMatrix();
            AdjacencyMatrix adjMatrix = new AdjacencyMatrix();

            do
            {
                Console.WriteLine("--------------------------");
                Console.WriteLine("Main Menu");
                Console.WriteLine("Please make your selection");
                Console.WriteLine("1 - Lab_6");
                Console.WriteLine("2 - Lab_7");
                Console.WriteLine("3 - Lab_8");
                Console.WriteLine("4 - Lab_9");
                Console.WriteLine("0 - Quit");
                Console.WriteLine("--------------------------");
                Console.Write("Selection: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        //Lab_6
                        Console.WriteLine("You Chosen Lab_6:");
                        int[,] incidentMatrix = incMatrix.createMatrix(file, result);
                        IncidentMatrix.printMatrix(incidentMatrix, file);
                        file.WriteIncidentFile(incidentMatrix);

                        int[,] adjacencyMatrix = adjMatrix.CreateMatrix(file, result);
                        adjMatrix.printMatrix(adjacencyMatrix, file);
                        file.WriteAdjacencyFile(incidentMatrix);
                        break;
                    case 2:
                        Console.WriteLine("You Chosen Lab_7:");
                        //Lab_7
                        Console.WriteLine();

                        int[,] inner_outer = GraphCharacter.FindInnerAndOuter(adjMatrix, adjMatrix.CreateMatrix(file, result));

                        for (int i = 1; i < file.GetN() + 1; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                Console.Write(inner_outer[i, j] + " ");
                            }
                            Console.WriteLine();
                        }
                        GraphCharacter.isHanged(adjMatrix, inner_outer);
                        GraphCharacter.isIsolated(adjMatrix, inner_outer);
                        break;
                    case 3:
                        Console.WriteLine("You Chosen Lab_8:");
                        //Lab_8
                        Console.WriteLine();

                        DFS dfs = new DFS();
                        dfs.Search(adjMatrix, adjMatrix.CreateMatrix(file, result), 4);
                        dfs.PrintResult();
                        break;
                    case 4:
                        Console.WriteLine("You Chosen Lab_9:");
                        //Lab_9
                        Console.WriteLine();

                        BFS bfs = new BFS();
                        bfs.Search(adjMatrix, adjMatrix.CreateMatrix(file, result), 4);
                        bfs.PrintResult();
                        break;
                    case 0:
                        Console.WriteLine("Goodbye! See Ya Later, Aligator!!!");
                        break;
                    default:
                        Console.WriteLine("--------------------------");
                        Console.WriteLine("Main Menu");
                        Console.WriteLine("Please make your selection");
                        Console.WriteLine("1 - Lab_6");
                        Console.WriteLine("2 - Lab_7");
                        Console.WriteLine("3 - Lab_8");
                        Console.WriteLine("4 - Lab_9");
                        Console.WriteLine("0 - Quit");
                        Console.WriteLine("--------------------------");
                        Console.Write("Selection: ");
                        choice = Convert.ToInt32(Console.ReadLine());
                        break;
                }
            } while (choice != 0);

            Console.ReadKey();
        }
    }
}
