using System;
using System.Collections.Generic;

namespace CodeWarsProject
{
    public class ScreenLockingPattern
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(CountPatternsFrom('D', 3));
        }
        public static int CountPatternsFrom(char firstDot, int length) 
        {
            if (length < 1 || length > 9) return 0;
            if (length == 1) return 1;
            var graph = CreateGraph();
            bool[] visited = new bool[9];
                
            return CountPatterns(graph, firstDot - 'A', length, visited)-1;
        }
        public static int CountPatterns(GraphBase graph,int start, int remaingLength,bool[] visited)
        {
            if (remaingLength == 1) return 1;
            visited[start] = true;
            int sum = 0;

            foreach (var point in graph.GetAdjacentVertices(start))
            {
                if(!visited[point])
                    sum += CountPatterns(graph, point, remaingLength-1, visited);
                
            }
            
            visited[start] = false;
            
            return sum;
        }
        private static AdjacencyMatrixGraphChars CreateGraph()
        {
            var graph = new AdjacencyMatrixGraphChars(9);
            
            graph.AddEdge(0, 1); // A -> B
            graph.AddEdge(1, 2); // B -> C
            graph.AddEdge(3, 4); // D -> E
            graph.AddEdge(4, 5); // E -> F
            graph.AddEdge(6, 7); // G -> H
            graph.AddEdge(7, 8); // H -> I

            graph.AddEdge(0, 3); // A -> D
            graph.AddEdge(3, 6); // D -> G
            graph.AddEdge(1, 4); // B -> E
            graph.AddEdge(4, 7); // E -> H
            graph.AddEdge(2, 5); // C -> F
            graph.AddEdge(5, 8); // F -> I
            
            graph.AddEdge(0, 4); // A -> E
            graph.AddEdge(2, 4); // C -> E
            graph.AddEdge(6, 4); // G -> E
            graph.AddEdge(8, 4); // I -> E
            graph.AddEdge(0, 8); // A -> I
            graph.AddEdge(2, 6); // C -> G
            //Verticals Edge

            graph.AddEdge(0, 7);
            graph.AddEdge(1, 8);
            
            graph.AddEdge(0, 5);
            graph.AddEdge(3,8);
            
            graph.AddEdge(2, 7);
            graph.AddEdge(1,6);
            
            graph.AddEdge(2, 3);
            graph.AddEdge(5,6);
            return graph;
        }

        public abstract class GraphBase
        {
            protected int NumVertices { get; }
            protected readonly bool Directed;

            public GraphBase(int numVertices, bool directed = false)
            {
                this.NumVertices = numVertices;
                this.Directed = directed;
            }

            public abstract void AddEdge(int v1, int v2, int weight = 1);

            public abstract IEnumerable<int> GetAdjacentVertices(int v);
        }

        public class AdjacencyMatrixGraphChars : GraphBase
        {
            private readonly int[,] Matrix;

            public AdjacencyMatrixGraphChars(int numVertices, bool directed = false) : base(numVertices, directed)
            {
                this.Matrix = new int[numVertices, numVertices];
            }

            public override void AddEdge(int v1, int v2, int weight = 1)
            {
                if (v1 >= this.NumVertices || v2 >= this.NumVertices || v1 < 0 || v2 < 0)
                    throw new ArgumentOutOfRangeException("Vertices are out of bounds");

                this.Matrix[v1, v2] = weight;

                if (!this.Directed)
                    this.Matrix[v2, v1] = weight;
            }

            public override IEnumerable<int> GetAdjacentVertices(int v)
            {
                List<int> adjacentVertices = new List<int>();
                for (int i = 0; i < this.NumVertices; i++)
                {
                    if (this.Matrix[v, i] > 0)
                        adjacentVertices.Add(i);
                }
                return adjacentVertices;
            }
        }
    }
}
