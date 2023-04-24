using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using Newtonsoft.Json;


namespace _20Questions
{
    class BTNode
    {
        public string message;
        public BTNode noNode;
        public BTNode yesNode;

        public BTNode(string nodeMessage)
        {
            message = nodeMessage;
            yesNode = null;
            noNode = null;
        }

        public void Query()
        {
            if( noNode != null && yesNode != null )
            {
                Console.WriteLine(message);
                Console.WriteLine("Yes or No:");

                string input = Console.ReadLine().ToLower();

                if( input.StartsWith("y"))
                {
                    yesNode.Query();
                }
                else
                {
                    noNode.Query();
                }
            }
            else
            {
                OnQueryObject();
            }
        }

        public void OnQueryObject()
        {
            Console.Write("Are you thinking of " + message + "? : ");
            string input = Console.ReadLine().ToLower();

            if( input.StartsWith("y"))
            {
                Console.WriteLine("The Computer Wins!");
                Console.WriteLine();
            }
            else
            {
                UpdateTree();
            }
        }

        public void UpdateTree()
        {
            Console.WriteLine();
            Console.Write("You won!  What were you thinking of? : ");
            string userObject = Console.ReadLine();

            Console.Write("Please enter a yes/no question to distinguish " + message + " from " + userObject + " : ");
            string userQuestion = Console.ReadLine();

            Console.Write("If you were thinking of " + userObject + ", what would the answer to that question be? : ");
            string input = Console.ReadLine().ToLower();

            if( input.StartsWith("y"))
            {
                this.noNode = new BTNode(message);
                this.yesNode = new BTNode(userObject);
            }
            else
            {
                this.yesNode = new BTNode(message);
                this.noNode = new BTNode(userObject);
            }

            message = userQuestion;

            Console.WriteLine("Thank you, my knowledge has increased!");
            Console.WriteLine();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string s;

            BTNode root = null;

            StreamReader reader;
            StreamWriter writer;

            HttpWebRequest request;
            HttpWebResponse response;
            string url;

            Console.WriteLine("Welcome to 20 Questions!");
            Console.WriteLine();

            try
            {
                url = "http://people.rit.edu/dxsigm/20q.php?get";

                request = (HttpWebRequest)WebRequest.Create(url);
                response = (HttpWebResponse)request.GetResponse();
                reader = new StreamReader(response.GetResponseStream());

                //reader = new StreamReader("c:/temp/20q.json");

                s = reader.ReadToEnd();
                reader.Close();

                if( s.Length == 0)
                {
                    throw new Exception();
                }

                // convert html escape sequences to special characters (eg. ">" for "gt;")
                s = HttpUtility.UrlDecode(s);

                root = JsonConvert.DeserializeObject<BTNode>(s);               
            }
            catch
            {
                Console.WriteLine("Enter a yes/no question about an object: ");
                string question = Console.ReadLine();
                Console.Write("Enter a guess if the response is Yes: ");
                string yesGuess = Console.ReadLine();
                Console.Write("Enter a guess if the response is No: ");
                string noGuess = Console.ReadLine();

                root = new BTNode(question);
                root.yesNode = new BTNode(yesGuess);
                root.noNode = new BTNode(noGuess);
            }

            do
            {
                Console.WriteLine();
                root.Query();

                Console.Write("Play again? : ");
                string input = Console.ReadLine().ToLower();

                if (input.StartsWith("n"))
                {
                    break;
                }
            } while (true);

            s = JsonConvert.SerializeObject(root);

            // convert special characters to their html escape sequences (eg. "gt;" for ">")
            s = HttpUtility.UrlEncode(s);

            url = "http://people.rit.edu/dxsigm/20q.php?set=" + s;

            request = (HttpWebRequest)WebRequest.Create(url);
            response = (HttpWebResponse)request.GetResponse();
            reader = new StreamReader(response.GetResponseStream());
            s = reader.ReadToEnd();
            reader.Close();


            //writer = new StreamWriter("c:/temp/20q.json");
            //writer.Write(s);
            //writer.Close();
        }
    }
}
