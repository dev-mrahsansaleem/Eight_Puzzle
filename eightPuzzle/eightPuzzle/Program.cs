using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eightPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
            GOAL NODES
            3X3
            int[] puzzleProblem ={0,1,2,3,4,5,6,7,8,};
            4X4
            int[] puzzleProblem ={0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,};
                
             */


            /*
            TEST CASE
            3X3
            int[] puzzleProblem = { 1, 8, 2, 0, 4, 3, 7, 6, 5, };
            
            4X4
            int[] puzzleProblem ={4,1,2,3,5,6,7,0,8,9,10,11,12,13,14,15,};
             */



            //files opening
            StreamReader sr = new StreamReader("input.txt");
            StreamWriter sw = new StreamWriter("output.txt");
            Console.WriteLine("Content of the File");
            sr.BaseStream.Seek(0, SeekOrigin.Begin);

            string str = sr.ReadLine();
            //readed row in file
            //Console.WriteLine(str);
            try
            {
                int numberOfPuzzles = int.Parse(str.Trim());

                for (int counter = 0; counter < numberOfPuzzles;counter++)
                {
                    str = sr.ReadLine();
                    //readed row in file
                    //Console.WriteLine(str);
                    string[] separatingStrings = { ", ", ",", " " };
                    string[] values = str.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
                    int[] puzzleProblem = puzzleProblem = new int[values.Length];
                    int numberOfValues = values.Length;
                    double numberOfCols = Math.Sqrt(double.Parse(numberOfValues.ToString()));
                    int j = 0;
                    Console.WriteLine("======================================================");
                    Console.WriteLine("matrix created of order or dimension: " + numberOfCols + " X " + numberOfCols);
                    Console.WriteLine("======================================================");

                    //write in file
                    sw.WriteLine("======================================================");
                    sw.WriteLine("matrix created of order or dimension: " + numberOfCols + " X " + numberOfCols);
                    sw.WriteLine("======================================================");

                    foreach (var v in values)
                    {
                        //System.Console.WriteLine(v);
                        puzzleProblem[j] = Int32.Parse(v);
                        //Console.WriteLine("this is arry"+puzzleProblem[j]);
                        j++;
                    }
                    //Console.WriteLine("number of values in current line:"+numberOfValues);
                    //Console.ReadKey();
                    Stopwatch sp = new Stopwatch();
                    List<Node> solution;
                    string path = "";
                    try
                    {
                        //same puzzle for each search algo
                        Node bfsroot = new Node(puzzleProblem, numberOfValues, int.Parse(numberOfCols.ToString()));
                        Node dfsroot = new Node(puzzleProblem, numberOfValues, int.Parse(numberOfCols.ToString()));

                        Search ui = new Search();
                        //working for bfs start here
                        sp.Reset();
                        sp.Start();
                        solution = ui.BFS(bfsroot);
                        sp.Stop();
                        Console.WriteLine("Time for bfs (in millisecounds): " + sp.ElapsedMilliseconds);
                        
                        //write in file
                        sw.WriteLine("Time for bfs (in millisecounds): " + sp.ElapsedMilliseconds);
                        
                        if (solution.Count > 0)
                        {
                            Console.WriteLine("\t****************************************");
                            Console.WriteLine("\tPath found to solve the matrix from BFS");
                            Console.WriteLine("\t****************************************");
                            //write in file

                            sw.WriteLine("\t****************************************");
                            sw.WriteLine("\tPath found to solve the matrix from BFS");
                            sw.WriteLine("\t****************************************");
                            for (int i = solution.Count-2; i>=0 ; i--)
                            {
                                //solution[i].displayPuzzle();
                                //Console.WriteLine(solution[i].action);
                                path = solution[i].action + " -> " + path;
                            }
                            char[] lastChar = { '-', '>', ' ' };
                            Console.WriteLine(path.TrimEnd(lastChar));
                            //write in file
                            sw.WriteLine(path.TrimEnd(lastChar));
                        }
                        else
                        {
                            Console.WriteLine("no path found...!!!");
                        }
                        
                        //working for Dfs start here
                        sp.Reset();
                        sp.Start();
                        solution = ui.DFS(dfsroot);
                        sp.Stop();
                        Console.WriteLine("Time for Dfs (in millisecounds): " + sp.ElapsedMilliseconds);
                        //write in file
                        sw.WriteLine("Time for Dfs (in millisecounds): " + sp.ElapsedMilliseconds);

                        if (solution.Count > 0)
                        {
                            Console.WriteLine("\t****************************************");
                            Console.WriteLine("\tPath found to solve the matrix from DFS");
                            Console.WriteLine("\t****************************************");
                            
                            //write in file
                            sw.WriteLine("\t****************************************");
                            sw.WriteLine("\tPath found to solve the matrix from DFS");
                            sw.WriteLine("\t****************************************");
                            for (int i = solution.Count - 2; i >= 0; i--)
                            {
                                //solution[i].displayPuzzle();
                                //Console.WriteLine(solution[i].action);
                                path = solution[i].action + " -> " + path;
                            }
                            char[] lastChar = { '-', '>', ' ' };
                            Console.WriteLine(path.TrimEnd(lastChar));
                            //write in file
                            sw.WriteLine(path.TrimEnd(lastChar));
                        }
                        else
                        {
                            Console.WriteLine("no path found...!!!");
                        }
                        //Console.WriteLine("test break press a key");
                        //Console.ReadKey();
                    }
                    catch
                    {
                        Console.WriteLine("number of colums are not integer that is number of values are not a perfect square that's mean not a square matrix: " + numberOfCols.ToString());
                    }
                }
            }
            catch
            {
                Console.WriteLine("1st line of file must contain number of puzzles: " + str);
            }
            sw.Flush();
            sr.Close();
            sw.Close();
            Console.WriteLine("press any key to countinue...");
            Console.ReadKey();

        }
    }
}
