using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace FireTruckRoute
{
    internal class VM
    {
        const int fireStationAddress = 1;

        private static readonly string filePath = Environment.CurrentDirectory + "\\testCases";
        public static readonly char[] DELIMITER = new char[] { '\r', '\n', ' ' };

        public BindingList<TestCase> TestCases { get; set; } = new BindingList<TestCase> { };

        public BindingList<string> Solutions { get; set; } = new BindingList<string> { };

        private TestCase selectedTestCase = null;

        public TestCase SelectedTestCase
        {
            get { return selectedTestCase; }
            set { selectedTestCase = value; }
        }


        public void CalculateRoute()
        {
            TestCase testCase = new TestCase();
            testCase.FireAt = 6;
            testCase.streetEdges.Add(new int[] { 1, 2 });
            testCase.streetEdges.Add(new int[] { 1, 3 });
            testCase.streetEdges.Add(new int[] { 3, 4 });
            testCase.streetEdges.Add(new int[] { 3, 5 });
            testCase.streetEdges.Add(new int[] { 4, 6 });
            testCase.streetEdges.Add(new int[] { 5, 6 });
            testCase.streetEdges.Add(new int[] { 2, 3 });
            testCase.streetEdges.Add(new int[] { 2, 4 });

            Graph graph = new Graph(testCase);

            int fireAt = testCase.FireAt;
            bool[] visited = new bool[7];
            string psf = "";
            printAllPaths(graph.graph, fireStationAddress, fireAt,
                visited, fireStationAddress + "");
        }


        public void printAllPaths(List<Edge>[] graph, int src,
            int fireAt, bool[] visited, string psf)
        {
            if (src == fireAt)
            {
                Solutions.Add(psf);
                return;
            }

            visited[src] = true;
            foreach (Edge e in graph[src])
            {
                if (!visited[e.nbr])
                {
                    printAllPaths(graph, e.nbr, fireAt, visited, psf + e.nbr);
                }
            }
            visited[src] = false;
        }


        public void LoadTestCases()
        {
            TestCase testCase = new TestCase();
            string[] files = Directory.GetFiles(filePath);
            string text = "";
            try
            {
                text = File.ReadAllText(files[0]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //string[] lines1 = text.Split(Environment.NewLine.ToCharArray());
            string[] lines2 = text.Split(DELIMITER);
            foreach (string line in lines2)
            {

                if (line.Length == 1)
                {
                    testCase.FireAt = Convert.ToInt32(line[0]);
                }
                else if (line.Length == 2)
                {
                    int street1 = Convert.ToInt32(line[0]);
                    int street2 = Convert.ToInt32(line[1]);
                    if (street1 > 0 || street2 > 0)
                    {
                        testCase.streetEdges.Add(new int[2] { street1, street2 });
                    }
                    else if (street1 == 0 && street2 == 0)
                    {
                        TestCases.Add(testCase);
                    }
                }

            }
        }


    }
}
