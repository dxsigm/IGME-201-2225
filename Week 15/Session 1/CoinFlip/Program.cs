// represent game as directed graph (for AI version) or not (for human player)
#define DIGRAPH
//#define USE_MATRIX


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Policy;

namespace CoinFlip
{
    public enum ECoinState
    {
        TTT,
        TTH,
        THT,
        THH,
        HTT,
        HTH,
        HHT,
        HHH
    }

    public class Node : IComparable<Node>
    {
        public ECoinState eState;

        public List<Edge> edges = new List<Edge>();

        public int minCostToStart;
        public Node nearestToStart;
        public bool visited;

        public Node(ECoinState eState)
        {
            this.eState = eState;
            this.minCostToStart = int.MaxValue;
        }

        public void AddEdge(int cost, Node connection)
        {
            Edge e = new Edge(cost, connection);
            edges.Add(e);
        }

        public int CompareTo(Node n)
        {
            return this.minCostToStart.CompareTo(n.minCostToStart);
        }
    }

    public class Edge : IComparable<Edge>
    {
        public int cost;
        public Node connectedNode;

        public Edge(int cost, Node connectedNode)
        {
            this.cost = cost;
            this.connectedNode = connectedNode;
        }

        public int CompareTo(Edge e)
        {
            return this.cost.CompareTo(e.cost);
        }
    }

    internal static class Program
    {
#if DIGRAPH
        // the adjacency values for the directed graph version.  
        // Only allow the paths that reach the goal
        static bool[,] mGraph = new bool[,]
        {
                     // TTT       TTH       THT       THH       HTT      HTH        HHT       HHH
            /* TTT */ { false   , true    , false   , false   , true    , false   , false   , false },
            /* TTH */ { false   , false   , false   , true    , false   , false   , false   , false },
            /* THT */ { true    , false   , false   , false   , false   , false   , false   , false },
            /* THH */ { false   , false   , false   , false   , false   , false   , false   , true },
            /* HTT */ { false   , false   , false   , false   , false   , false   , true    , false },
            /* HTH */ { false   , false   , false   , false   , false   , false   , false   , false },
            /* HHT */ { false   , false   , false   , false   , false   , false   , false   , true },
            /* HHH */ { false   , false   , false   , false   , false   , true    , false   , false }
        };

        
//        static int[,] mGraph = new int[,]
//{
//                     // TTT       TTH       THT       THH       HTT      HTH        HHT       HHH
//            /* TTT */ { -1   , 1    , false   , false   , true    , false   , false   , false },
//            /* TTH */ { false   , false   , false   , true    , false   , false   , false   , false },
//            /* THT */ { true    , false   , false   , false   , false   , false   , false   , false },
//            /* THH */ { false   , false   , false   , false   , false   , false   , false   , true },
//            /* HTT */ { false   , false   , false   , false   , false   , false   , true    , false },
//            /* HTH */ { false   , false   , false   , false   , false   , false   , false   , false },
//            /* HHT */ { false   , false   , false   , false   , false   , false   , false   , true },
//            /* HHH */ { false   , false   , false   , false   , false   , true    , false   , false }
//
//};


        static ECoinState[][] lGraph = new ECoinState[][]
        {
             /* TTT */ new ECoinState[] { ECoinState.TTH, ECoinState.HTT },
             /* TTH */ new ECoinState[] { ECoinState.THH },
             /* THT */ new ECoinState[] { ECoinState.TTT },
             /* THH */ new ECoinState[] { ECoinState.HHH },
             /* HTT */ new ECoinState[] { ECoinState.HHT },
             /* HTH */ null,
             /* HHT */ new ECoinState[] { ECoinState.HHH },
             /* HHH */ new ECoinState[] { ECoinState.HTH }
        };

        static int[][] wGraph = new int[][]
{
             /* TTT */ new int[] { 1, 4 }
                       // etc...
};

#else

        static bool[,] mGraph = new bool[,]
{
                   // TTT       TTH       THT       THH       HTT      HTH        HHT       HHH
         /* TTT */  { false   , true    , true    , false   , true    , false   , false   , false },
         /* TTH */  { true    , false   , false   , true    , false   , false   , false   , false },
         /* THT */  { true    , false   , false   , false   , false   , false   , false   , false },
         /* THH */  { false   , true    , false   , false   , false   , false   , false   , true  },
         /* HTT */  { true    , false   , false   , false   , false   , false   , true    , false },
         /* HTH */  { false   , false   , false   , false   , false   , false   , false   , true  },
         /* HHT */  { false   , false   , false   , false   , true    , false   , false   , true  },
         /* HHH */  { false   , false   , false   , true    , false   , true    , true    , false }
};

        static ECoinState[][] lGraph = new ECoinState[][]
{
            /* TTT */ new ECoinState[] { ECoinState.TTH, ECoinState.THT, ECoinState.HTT },
            /* TTH */ new ECoinState[] { ECoinState.TTT, ECoinState.THH },
            /* THT */ new ECoinState[] { ECoinState.TTT },
            /* THH */ new ECoinState[] { ECoinState.TTH, ECoinState.HHH },
            /* HTT */ new ECoinState[] { ECoinState.TTT, ECoinState.HHT },
            /* HTH */ new ECoinState[] { ECoinState.HHH },
            /* HHT */ new ECoinState[] { ECoinState.THT, ECoinState.HHH },
            /* HHH */ new ECoinState[] { ECoinState.THH, ECoinState.HTH, ECoinState.HHT }
};
#endif

        static int nState = 0;
        static string sUserState = null;

        static bool bWaitingForMove = false;

        static List<Node> graph = new List<Node>();

        static void Main(string[] args)
        {
            Random rand = new Random();
            string sState = null;


            Node node;
            node = new Node(ECoinState.TTT);
            graph.Add(node);

            node = new Node(ECoinState.TTH);
            graph.Add(node);

            node = new Node(ECoinState.THT);
            graph.Add(node);

            node = new Node(ECoinState.THH);
            graph.Add(node);

            node = new Node(ECoinState.HTT);
            graph.Add(node);

            node = new Node(ECoinState.HTH);
            graph.Add(node);

            node = new Node(ECoinState.HHT);
            graph.Add(node);

            node = new Node(ECoinState.HHH);
            graph.Add(node);

            graph[(int)ECoinState.TTT].AddEdge(1, graph[(int)ECoinState.TTH]);
            graph[(int)ECoinState.TTT].AddEdge(2, graph[(int)ECoinState.THT]);
            graph[(int)ECoinState.TTT].AddEdge(4, graph[(int)ECoinState.HTT]);
            graph[(int)ECoinState.TTT].edges.Sort();

            graph[(int)ECoinState.TTH].AddEdge(1, graph[(int)ECoinState.TTT]);
            graph[(int)ECoinState.TTH].AddEdge(3, graph[(int)ECoinState.THH]);
            graph[(int)ECoinState.TTH].edges.Sort();

            graph[(int)ECoinState.THT].AddEdge(2, graph[(int)ECoinState.TTT]);
            graph[(int)ECoinState.THT].edges.Sort();

            graph[(int)ECoinState.THH].AddEdge(3, graph[(int)ECoinState.TTH]);
            graph[(int)ECoinState.THH].AddEdge(7, graph[(int)ECoinState.HHH]);
            graph[(int)ECoinState.THH].edges.Sort();

            graph[(int)ECoinState.HTT].AddEdge(4, graph[(int)ECoinState.TTT]);
            graph[(int)ECoinState.HTT].AddEdge(6, graph[(int)ECoinState.HHT]);
            graph[(int)ECoinState.HTT].edges.Sort();

            graph[(int)ECoinState.HTH].AddEdge(7, graph[(int)ECoinState.HHH]);
            graph[(int)ECoinState.HTH].edges.Sort();

            graph[(int)ECoinState.HHT].AddEdge(6, graph[(int)ECoinState.HTT]);
            graph[(int)ECoinState.HHT].AddEdge(7, graph[(int)ECoinState.HHH]);
            graph[(int)ECoinState.HHT].edges.Sort();

            graph[(int)ECoinState.HHH].AddEdge(7, graph[(int)ECoinState.THH]);
            graph[(int)ECoinState.HHH].AddEdge(7, graph[(int)ECoinState.HTH]);
            graph[(int)ECoinState.HHH].AddEdge(7, graph[(int)ECoinState.HHT]);
            graph[(int)ECoinState.HHH].edges.Sort();

            List<Node> shortestPathFromTHTtoHTH = GetShortestPathDijkstra();

            int nUserState = 0;

            int nMoves = 0;

            while(true)
            {
                nState = rand.Next(0, Enum.GetNames(typeof(ECoinState)).Length);

                if( nState != (int)ECoinState.HTH)
                {
                    break;
                }
            }

            Thread t = new Thread(DFS);
            t.Start();

            while( nState != (int)ECoinState.HTH)
            {
                // convert the current numeric state to a string
                //sState = NState2SState(nState);
                sState = ((ECoinState)nState).ToString();

                // output the current state
                Console.WriteLine("Current coin state: " + sState);

                // prompt for the desired state
                Console.Write("Enter the desired state: ");
                sUserState = Console.ReadLine().ToUpper();

                bWaitingForMove = true;
                while (bWaitingForMove) ;

                nUserState = (int)Enum.Parse(typeof(ECoinState), sUserState);

#if USE_MATRIX
                if (mGraph[nState,nUserState])
                {
                    nState = nUserState;
                    ++nMoves;
                }
                else
                {
                    Console.WriteLine("That is an invalid move.");
                }
#else
                ECoinState[] thisStateList = lGraph[nState];
                bool valid = false;

                if( thisStateList != null)
                {
                    foreach(ECoinState n in thisStateList)
                    {
                        if( n == (ECoinState)nUserState)
                        {
                            valid = true;
                            nState = nUserState;
                            ++nMoves;
                        }
                    }
                }

                if( !valid)
                {
                    Console.WriteLine("That is an invalid move.");
                }
#endif
            }

            Console.WriteLine($"You won in {nMoves} moves!");
        }

        static void DFS()
        {
            bool[] visited = new bool[lGraph.Length];

            DFSUtil((ECoinState)nState, visited);
        }

        static void DFSUtil(ECoinState v, bool[] visited)
        {
            while (!bWaitingForMove) ;

            visited[(int)v] = true;

            Console.Write(v.ToString() + " ");

            sUserState = v.ToString();

            bWaitingForMove = false;

            ECoinState[] thisStateList = lGraph[(int)v];

            if (thisStateList != null)
            {
                foreach (ECoinState n in thisStateList)
                {
                    if (!visited[(int)n])
                    {
                        DFSUtil(n, visited);
                    }
                }
            }
        }

        /****************************************************************************************
        The Dijkstra algorithm was discovered in 1959 by Edsger Dijkstra.
        This is how it works:
        
        1. From the start node, add all connected nodes to a priority queue.
        2. Sort the priority queue by lowest cost and make the first node the current node.
           For every child node, select the shortest path to start.
           When all edges have been investigated from a node, that node is "Visited" 
           and you don´t need to go there again.
        3. Add each child node connected to the current node to the priority queue.
        4. Go to step 2 until the queue is empty.
        5. Recursively create a list of each node that defines the shortest path 
           from end to start.
        6. Reverse the list and you have found the shortest path
        
        In other words, recursively for every child of a node, measure its distance to the start. 
        Store the distance and what node led to the shortest path to start. When you reach the end 
        node, recursively go back to the start the shortest way, reverse that list and you have the 
        shortest path.
        ******************************************************************************************/
        static public List<Node> GetShortestPathDijkstra()
        {
            // traverse the path and calculate the minCostToStart and nearestToStart
            DijkstraSearch();

            List<Node> shortestPath = new List<Node>();

            // start from the end
            shortestPath.Add(graph[(int)ECoinState.HTH]);

            // recursively traverse from finish to start
            BuildShortestPath(shortestPath, graph[(int)ECoinState.HTH]);

            // reverse the path
            shortestPath.Reverse();

            // return the shortest path
            return(shortestPath);
        }

        static private void BuildShortestPath(List<Node> list, Node node)
        {
            if (node.nearestToStart == null)
            {
                return;
            }

            list.Add(node.nearestToStart);
            BuildShortestPath(list, node.nearestToStart);
        }


        static int NodeOrderBy( Node n)
        {
            return n.minCostToStart;
        }

        static private void DijkstraSearch()
        {
            Node start = graph[(int)ECoinState.THT];

            start.minCostToStart = 0;

            List<Node> queue = new List<Node>();
            queue.Add(start);

            // 2 ways to point our delegate variable to a delegate method
            Func<Node, int> nodeOrderBy = new Func<Node, int>(NodeOrderBy);
            //Func<Node, int> nodeOrderBy = NodeOrderBy;

            // stay in this loop while we have items in our queue
            do
            {
                // sort our queue by minCostToStart
                // option #1, use .Sort() which sorts in place
                queue.Sort();

                // option #2, use .OrderBy() with a delegate method or lambda expression 
                // the next 5 lines are equivalent from descriptive to abbreviated:
                queue = queue.OrderBy(nodeOrderBy).ToList();
                queue = queue.OrderBy(delegate (Node n) { return n.minCostToStart; }).ToList();
                queue = queue.OrderBy((Node n) => { return n.minCostToStart; }).ToList();
                queue = queue.OrderBy((n) => { return n.minCostToStart; }).ToList();
                queue = queue.OrderBy((n) => n.minCostToStart).ToList();
                queue = queue.OrderBy(n => n.minCostToStart).ToList();

                // grab the first node from our sorted queue
                Node node = queue.First();

                // remove it
                queue.Remove(node);

                // look at each edge and calculate the minCostToStart for each neighbor
                foreach( Edge cnn in node.edges)
                {
                    Node neighborNode = cnn.connectedNode;

                    if( neighborNode.visited)
                    {
                        continue;
                    }

                    // check if the path from this neighbor to the start is shorter if passing through this node
                    if( neighborNode.minCostToStart == int.MaxValue ||
                        node.minCostToStart + cnn.cost < neighborNode.minCostToStart)
                    {
                        // if it is then set this node as being nearest to start
                        neighborNode.minCostToStart = node.minCostToStart + cnn.cost;
                        neighborNode.nearestToStart = node;

                        // and add this neighbor to the queue
                        if( !queue.Contains(neighborNode))
                        {
                            queue.Add(neighborNode);
                        }
                    }
                }

                // set this node as being visited
                node.visited = true;

                // if we reached the target, then we're done!
                if( node == graph[(int)ECoinState.HTH])
                {
                    return;
                }

            } while (queue.Any());
        }
    }
}
