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
            int[,] result_weighted = file.ReadFileWeighted();

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
            WeightedMatrix weightMatrix = new WeightedMatrix();

            do
            {
                Console.WriteLine("--------------------------");
                Console.WriteLine("Main Menu");
                Console.WriteLine("Please make your selection");
                Console.WriteLine("1 - Lab_6");
                Console.WriteLine("2 - Lab_7");
                Console.WriteLine("3 - Lab_8");
                Console.WriteLine("4 - Lab_9");
                Console.WriteLine("5 - Lab_10");
                Console.WriteLine("6 - Lab_11");
                Console.WriteLine("7 - Lab_12");
                Console.WriteLine("8 - Lab_13");
                Console.WriteLine("9 - Lab_14");
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
                        file.WriteAdjacencyFile(adjacencyMatrix);
                        break;
                    case 2:
                        Console.WriteLine("You Chosen Lab_7:");
                        //Lab_7
                        Console.WriteLine();

                        int[,] inner_outer = GraphCharacter.FindInnerAndOuter(adjMatrix, result, file);

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
                        dfs.Search(adjMatrix, adjMatrix.CreateMatrix(file, result), 3);
                        dfs.PrintResult();
                        break;
                    case 4:
                        Console.WriteLine("You Chosen Lab_9:");
                        //Lab_9
                        Console.WriteLine();

                        BFS bfs = new BFS();
                        bfs.Search(adjMatrix, adjMatrix.CreateMatrix(file, result), 3);
                        bfs.PrintResult();
                        break;
                    case 5:
                        Console.WriteLine("You Chosen Lab_10:");
                        //Lab_10
                        int[,] myGraph = weightMatrix.CreateMatrix(file, result_weighted);
                        weightMatrix.printMatrix(myGraph, file);
                        break;
                    case 6:
                        Console.WriteLine("You Chosen Lab_11:");
                        //Lab_11
                        int[,] myGraphFloydUorshel = weightMatrix.CreateMatrix(file, result_weighted);
                        FloydUorshellMatrix floydUorshellMatrix = new FloydUorshellMatrix(weightMatrix, myGraphFloydUorshel);
                        break;
                    case 7:
                        Console.WriteLine("You Chosen Lab_12:");
                        //Lab_12
                        int[,] myGraphDeykstra = weightMatrix.CreateMatrix(file, result_weighted);
                        DeykstraMatrix lab = new DeykstraMatrix(weightMatrix, myGraphDeykstra);
                        break;
                    case 8:
                        Console.WriteLine("You Chosen Lab_13:");
                        int[,] result_lab13 = file.ReadFile();
                        adjacencyMatrix = adjMatrix.CreateMatrix(file, result_lab13);
                        adjMatrix.printMatrix(adjacencyMatrix, file);
                        Console.WriteLine();
                        ColoredMatrix graphColor = new ColoredMatrix(adjacencyMatrix, adjMatrix, result_lab13, file);
                        break;
                    case 9:
                        Console.WriteLine("You Chosen Lab_14:");
                        int[,] result_lab14 = file.ReadFile();
                        adjacencyMatrix = adjMatrix.CreateMatrix(file, result_lab14);
                        Relations relations = new Relations(adjacencyMatrix, adjMatrix);
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
                        Console.WriteLine("5 - Lab_10");
                        Console.WriteLine("6 - Lab_11");
                        Console.WriteLine("7 - Lab_12");
                        Console.WriteLine("8 - Lab_13");
                        Console.WriteLine("9 - Lab_14");
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
