// represent game as directed graph (for AI version) or not (for human player)
#define DIGRAPH
//#define USE_MATRIX


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CoinFlip
{
    public class Node : IComparable<Node>
    {
        public int nState;

        public List<Edge> edges = new List<Edge>();

        public int minCostToStart;
        public Node nearestToStart;
        public bool visited;

        public Node(int nState)
        {
            this.nState = nState;
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


    enum ECoinState
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

    internal static class Program
    {
#if DIGRAPH
        // the adjacency values for the directed graph version.  
        // Only allow the paths that reach the goal
        static bool[,] mGraph = new bool[,]
        {
           { false   , true    , false   , false   , true    , false   , false   , false },
           { false   , false   , false   , true    , false   , false   , false   , false },
           { true    , false   , false   , false   , false   , false   , false   , false },
           { false   , false   , false   , false   , false   , false   , false   , true },
           { false   , false   , false   , false   , false   , false   , true    , false },
           { false   , false   , false   , false   , false   , false   , false   , false },
           { false   , false   , false   , false   , false   , false   , false   , true },
           { false   , false   , false   , false   , false   , true    , false   , false }
        };

        static int[][] lGraph = new int[][]
        {
            new int[] { (int)ECoinState.TTH,(int)ECoinState.HTT },
            new int[] { (int)ECoinState.THH },
            new int[] { (int)ECoinState.TTT },
            new int[] { (int)ECoinState.HHH },
            new int[] { (int)ECoinState.HHT },
            null,
            new int[] { (int)ECoinState.HHH },
            new int[] { (int)ECoinState.HTH }
        };
#else

        static bool[,] mGraph = new bool[,]
{
            // "TTT"     "TTH"    THT       THH       HTT      HTH        HHT       HHH
         /* TTT */  { false   , true    , true    , false   , true    , false   , false   , false },
         /* TTH */  { true    , false   , false   , true    , false   , false   , false   , false },
         /* THT */  { true    , false   , false   , false   , false   , false   , false   , false },
         /* THH */  { false   , true    , false   , false   , false   , false   , false   , true  },
         /* HTT */  { true    , false   , false   , false   , false   , false   , true    , false },
         /* HTH */  { false   , false   , false   , false   , false   , false   , false   , true  },
         /* HHT */  { false   , false   , false   , false   , true    , false   , false   , true  },
         /* HHH */  { false   , false   , false   , true    , false   , true    , true    , false }
};

        static int[][] lGraph = new int[][]
{
            /* TTT */ new int[] { (int)ECoinState.TTH, (int)ECoinState.THT, (int)ECoinState.HTT },
            /* TTH */ new int[] { (int)ECoinState.TTT, (int)ECoinState.THH },
            /* THT */ new int[] { (int)ECoinState.TTT },
            /* THH */ new int[] { (int)ECoinState.TTH, (int)ECoinState.HHH },
            /* HTT */ new int[] { (int)ECoinState.TTT, (int)ECoinState.HHT },
            /* HTH */ new int[] { (int)ECoinState.HHH },
            /* HHT */ new int[] { (int)ECoinState.THT, (int)ECoinState.HHH },
            /* HHH */ new int[] { (int)ECoinState.THH, (int)ECoinState.HTH, (int)ECoinState.HHT }
};
#endif

        static int nState = 0;
        static string sUserState = null;

        static bool bWaitingForMove = false;

        static void Main(string[] args)
        {
            Random rand = new Random();
            string sState = null;

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
                int[] thisStateList = lGraph[nState];
                bool valid = false;

                if( thisStateList != null)
                {
                    foreach(int n in thisStateList)
                    {
                        if( n == nUserState)
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

        // convert the string to the equivalent 2-based integer
        static int SState2NState(string sState)
        {
            int nState = 0;

            // HHT should be converted to 6
            for (int i = 0; i < 3; ++i)
            {
                if (sState[i] == 'H')
                {
                    nState += (1 << (2 - i));
                }
            }

            return (nState);
        }

        // convert the 2-based integer to the equivalent string
        static string NState2SState(int nState)
        {
            string r = null;

            // 6 should be HHT
            for (int i = 0; i < 3; ++i)
            {
                if ((nState & (1 << (2 - i))) != 0)
                {
                    r += "H";
                }
                else
                {
                    r += "T";
                }
            }

            return (r);
        }

        static void DFS()
        {
            bool[] visited = new bool[lGraph.Length];

            DFSUtil(nState, visited);
        }

        static void DFSUtil(int v, bool[] visited)
        {
            while (!bWaitingForMove) ;

            visited[v] = true;

            Console.Write(((ECoinState)v).ToString() + " ");

            sUserState = ((ECoinState)v).ToString();

            bWaitingForMove = false;

            int[] thisStateList = lGraph[v];

            if (thisStateList != null)
            {
                foreach (int n in thisStateList)
                {
                    if (!visited[n])
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

    }
}
