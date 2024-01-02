using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MColoringGraph
{
    class GraphColoring
    {
        private int V; // Number of vertices in the graph
        private int[] colors; // Array to store the color of each vertex
        private List<List<int>> adjList; // Adjacency list representing the graph

        public GraphColoring(int v)
        {
            V = v;
            colors = new int[V];
            adjList = new List<List<int>>();
            for (int i = 0; i < V; i++)
            {
                adjList.Add(new List<int>());
            }
        }

        // Function to add an edge to the graph
        public void AddEdge(int u, int v)
        {
            adjList[u].Add(v);
            adjList[v].Add(u);
        }

        // Function to check if it's safe to color a vertex with a given color
        private bool IsSafe(int v, int c)
        {
            foreach (var adjacent in adjList[v])
            {
                if (colors[adjacent] == c)
                    return false;
            }
            return true;
        }

        // Recursive function to solve the M-Coloring problem
        private bool MColoringUtil(int v, int m)
        {
            if (v == V)
                return true;

            for (int c = 1; c <= m; c++)
            {
                if (IsSafe(v, c))
                {
                    colors[v] = c;

                    if (MColoringUtil(v + 1, m))
                        return true;

                    colors[v] = 0; // Backtrack
                }
            }

            return false;
        }

        // Main function to solve the M-Coloring problem
        public int MColoring(int m)
        {
            if (MColoringUtil(0, m) == false)
            {
                return -1; // Solution does not exist
            }

            return m;
        }

        // Function to write the color assignment of each vertex to a file
        private void WriteOutputToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Minimum colors needed: {colors.Max()}");

                writer.WriteLine("Vertex Colors:");
                for (int i = 0; i < V; i++)
                {
                    writer.WriteLine($"Vertex {i + 1}: Color {colors[i]}");
                }
            }
        }

        // Read input from file and perform coloring
        public void PerformGraphColoring(string inputFilePath, string outputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] connection = line.Split('-');
                    int u = int.Parse(connection[0]) - 1;
                    int v = int.Parse(connection[1]) - 1;
                    AddEdge(u, v);
                }
            }

            int m = 1; // Start with 1 color
            while (MColoring(m) == -1)
            {
                m++; // Increment colors until a solution is found
            }

            WriteOutputToFile(outputFilePath);
        }
    }
}
