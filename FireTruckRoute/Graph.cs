using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireTruckRoute
{
    internal class Graph
    {
        public List<Edge>[] graph = new List<Edge>[7];
        public Graph(TestCase testCase)
        {

            int edges = testCase.streetEdges.Count();
            int vertices = 7;
            for (int i = 0; i < vertices; i++)
            {
                graph[i] = new List<Edge>();
            }

            foreach(int[] edge in testCase.streetEdges)
            {
                int v1 = edge[0];
                int v2 = edge[1];
                graph[v1].Add(new Edge(v1, v2));
                graph[v2].Add(new Edge(v2, v1));
            }
        }

        
        
}
}
