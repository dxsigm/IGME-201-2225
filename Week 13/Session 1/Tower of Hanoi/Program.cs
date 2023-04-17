using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_of_Hanoi
{
    internal static class Program
    {
        static Dictionary<string, Stack<int>> post = new Dictionary<string, Stack<int>>();

        static Queue<string[]> autoMoves = new Queue<string[]>();

        static int nTurn = 0;

        static void Main(string[] args)
        {
            int nBlocks = 0;

            post["A"] = new Stack<int>();
            post["B"] = new Stack<int>();
            post["C"] = new Stack<int>();

            Console.WriteLine("Move the blocks from post A to post C. \nYou may not put a larger block onto a smaller one.");
            Console.Write("Number of blocks on post A: ");

            while (int.TryParse(Console.ReadLine(), out nBlocks) == false) ;

            Console.Write("Autosolve (Y/N): ");
            string autoSolve = Console.ReadLine();

            post["A"].Push(nBlocks + 1);

            int nCntr = nBlocks;
            while( nCntr >  0)
            {
                post["A"].Push(nCntr);
                --nCntr;
            }

            post["B"].Push(nBlocks + 1);
            post["C"].Push(nBlocks + 1);

            string srcPost = null;
            string destPost = null;

            int nThisBlock = 0;

            if( autoSolve.ToLower().StartsWith("y"))
            {
                GameSolver(nBlocks, "A", "B", "C");
            }

            while (post["C"].Count != nBlocks + 1)
            {
                PrintPosts(nBlocks);

                tryAgain:
                if (autoSolve.ToLower().StartsWith("y"))
                {
                    string[] sMoves = autoMoves.Dequeue();
                    srcPost = sMoves[0];
                    destPost = sMoves[1];
                }
                else
                {
                    Console.Write("Source Post: ");
                    srcPost = Console.ReadLine().ToUpper();

                    Console.Write("Destination Post: ");
                    destPost = Console.ReadLine().ToUpper();
                }

                if (post[srcPost].Count == 1)
                {
                    Console.WriteLine("There are no blocks on post " + srcPost);
                    goto tryAgain;
                }

                if (post[srcPost].Peek() > post[destPost].Peek())
                {
                    Console.WriteLine("You may not place a larger block on a smaller block!");
                    goto tryAgain;
                }

                nThisBlock = post[srcPost].Pop();
                post[destPost].Push(nThisBlock);
            }

            PrintPosts(nBlocks);
        }

        // first called with from = "A", spare = "B", to = "C"
        // to move the blocks from A to C
        static void GameSolver(int nBlocks, string from, string spare, string to)
        {
            string[] moves = new string[2];

            // down to the last block
            if( nBlocks == 1 )
            {
                // move the block to the target post
                moves[0] = from;
                moves[1] = to;
                autoMoves.Enqueue(moves);
                return;
            }

            // first called with from = "A", spare = "C", to = "B"
            // to move the blocks from A to B
            GameSolver(nBlocks - 1, from, to, spare);

            moves[0] = from;
            moves[1] = to;
            autoMoves.Enqueue(moves);

            // first called with from = "B", spare = "A", to = "C"
            // to move the blocks from B to C
            GameSolver(nBlocks - 1, spare, from, to);
        }

        static void PrintPosts(int nBlocks)
        {
            List<int> aPost = new List<int>(post["A"].ToArray());
            List<int> bPost = new List<int>(post["B"].ToArray());
            List<int> cPost = new List<int>(post["C"].ToArray());

            aPost.Reverse();
            bPost.Reverse();
            cPost.Reverse();

            for (int i = nBlocks; i > 0; --i)
            {
                Console.Write((aPost.Count > i ? aPost[i].ToString() : " "));
                Console.Write("   ");

                Console.Write((bPost.Count > i ? bPost[i].ToString() : " "));
                Console.Write("   ");

                Console.Write((cPost.Count > i ? cPost[i].ToString() : " "));
                Console.WriteLine();
            }

            Console.WriteLine("A   B   C");
            Console.WriteLine("Turn #" + nTurn);
            ++nTurn;
            Console.WriteLine();
        }

    }
}
