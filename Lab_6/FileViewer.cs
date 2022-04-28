using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    internal class FileViewer
    {
        private int n = 0;
        private int m = 0;

        public int GetM() 
        { 
            return this.m; 
        }
        public int GetN() 
        { 
            return this.n; 
        }

        public FileViewer()
        {
            n = 0;
            m = 0;
        }

        public int[,] ReadFile()
        {
            string line;
            string[] substr;
            int[,] fileInfo = null;
            try
            {
                StreamReader streamReader = new StreamReader("C:\\Users\\User\\Desktop\\Програмування Дискретних Структур\\Лаб_6\\Graphs\\graph_01_1.txt");
                line = streamReader.ReadLine();
                substr = line.Split();
                this.n = Convert.ToInt32(substr[0]);
                this.m = Convert.ToInt32(substr[1]);

                fileInfo = new int[m + 1, 2];
                line = streamReader.ReadLine();
                for (int i = 1; line != null; i++)
                {
                    substr = line.Split();
                    fileInfo[i, 0] = Convert.ToInt32(substr[0]);
                    fileInfo[i, 1] = Convert.ToInt32(substr[1]);
                    line = streamReader.ReadLine();
                }
                streamReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return fileInfo;
        }
        public void WriteIncidentFile(int[,] incidentMatrix)
        {
            try
            {
                StreamWriter sw = new StreamWriter("C:\\Users\\User\\Desktop\\Програмування Дискретних Структур\\Лаб_6\\Incident.txt");
                sw.Write("   |");
                for (int j = 1; j < this.m + 1; j++)
                {
                    sw.Write($"{j,3} |");
                }
                sw.WriteLine();
                for (int i = 1; i < this.n + 1; i++)
                {
                    sw.Write($"{i,2} | ");
                    for (int j = 1; j < this.m +1; j++)
                    {
                        sw.Write($"{incidentMatrix[i, j],2} | ");
                    }
                    sw.WriteLine();
                }
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine(" ");
            }
        }
        public void WriteAdjacencyFile(int[,] adjacencyMatrix)
        {
            try
            {
                StreamWriter sw = new StreamWriter("C:\\Users\\User\\Desktop\\Програмування Дискретних Структур\\Лаб_6\\Adjacency.txt");
                sw.Write("   |");
                for (int j = 1; j < this.n + 1; j++)
                {
                    sw.Write($"{j,3} |");
                }
                sw.WriteLine();
                for (int i = 1; i < this.n + 1; i++)
                {
                    sw.Write($"{i,2} | ");
                    for (int j = 1; j < this.n + 1; j++)
                    {
                        sw.Write($"{adjacencyMatrix[i, j],2} | ");
                    }
                    sw.WriteLine();
                }
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
        //Lab_10
        public int[,] ReadFileWeighted()
        {
            string line;
            string[] substr;
            int[,] fileInfo = null;
            try
            {
                StreamReader streamReader = new StreamReader("C:\\Users\\User\\Desktop\\Програмування Дискретних Структур\\Лаб_6\\Graphs\\graph_my.txt");
                line = streamReader.ReadLine();
                substr = line.Split();
                this.n = Convert.ToInt32(substr[0]);
                this.m = Convert.ToInt32(substr[1]);

                fileInfo = new int[m + 1, 3];
                line = streamReader.ReadLine();
                for (int i = 1; line != null; i++)
                {
                    substr = line.Split();
                    fileInfo[i, 0] = Convert.ToInt32(substr[0]);
                    fileInfo[i, 1] = Convert.ToInt32(substr[1]);
                    fileInfo[i, 2] = Convert.ToInt32(substr[2]);
                    line = streamReader.ReadLine();
                }
                streamReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return fileInfo;
        }
    }
}