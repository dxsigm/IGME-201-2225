using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinFlip
{
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
            /* TTH */ new int[] { 0, 3 },
            /* THT */ new int[] { 0 },
            /* THH */ new int[] { 1, 7 },
            /* HTT */ new int[] { 0, 6 },
            /* HTH */ new int[] { 7 },
            /* HHT */ new int[] { 4, 7 },
            /* HHH */ new int[] { 3, 5, 6 }
};

        static int nState = 0;
        static string sUserState = null;

        static void Main(string[] args)
        {
            Random rand = new Random();
            string sState = null;

            int nUserState = 0;

            int nMoves = 0;

            while(true)
            {
                nState = rand.Next(0,8);

                if( nState != (int)ECoinState.HTH)
                {
                    break;
                }
            }

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

                nState = (int)Enum.Parse(typeof(ECoinState), sUserState);

            }
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

    }
}
