using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using MColoringGraph;

namespace MColoringGraph
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            var watch = System.Diagnostics.Stopwatch.StartNew();


            string inputFilePath = "C:\\Users\\Sepehr\\OneDrive\\Desktop\\New folder (2)\\New Folder\\movazi\\Minimum-Coloring-Graph\\MColoringGraph\\input.txt"; // Replace with your input file path
            string outputFilePath = "C:\\Users\\Sepehr\\OneDrive\\Desktop\\New folder (2)\\New Folder\\movazi\\Minimum-Coloring-Graph\\MColoringGraph\\output.txt"; // Replace with your output file path

            int numberOfNodes = 20;

            //GraphColoring graph = new GraphColoring(numberOfNodes);
            //graph.PerformGraphColoring(inputFilePath, outputFilePath);

            ParallelGraphColoring parallelGraphColoring = new ParallelGraphColoring(numberOfNodes);
            parallelGraphColoring.PerformGraphColoring(inputFilePath, outputFilePath);


            watch.Stop();

            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        }
    }
}