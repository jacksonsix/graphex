using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLDot
{
    using System.IO;

    public class XMLtoDot
    {

        static  Dictionary<string,string> symtable = new Dictionary<string, string>();
        static Stack<List<string>> mstack = new Stack<List<string>>();

        public static void read()
        {
            var lines = System.IO.File.ReadAllLines(@"C:\Users\JLiang\Documents\s.xml");
            stackwalker(lines);
        }

        private static string getNodeId(string line)
        {
            int start = line.IndexOf("NodeId=") + "NodeId=".Length;
            StringBuilder sb = new StringBuilder();
            var terms = new[] { ' ', '>' };
            for (int i = start; i < line.Length; i++)
            {
                if (terms.Any(s => s.Equals(line.ElementAt(i)))) break;
                sb.Append(line.ElementAt(i));
            }
            return sb.ToString().Trim(new []{'"'});
        }

        public static void stackwalker(IList<string> xml )
        {
           
            List<string> root = new List<string>();
            root.Add("0");
            mstack.Push(root);

            for (int k = 0; k < xml.Count;k++ )
            {
                var line = xml[k];
                if (line.IndexOf("<RelOp") != -1)
                {
                    string nodeId = getNodeId(line);
                    var player = mstack.Pop();
                    player.Add(nodeId);
                    mstack.Push(player);
                    var layer = new List<string>();
                    layer.Add(nodeId);
                    mstack.Push(layer);
                    //
                    var head = player.First();
                    if (symtable.ContainsKey(head))
                    {
                        symtable[head] = String.Join(",", player.Skip(1));
                    }
                    else
                    {
                        symtable.Add(head, String.Join(",", player.Skip(1)));
                    }
                    
                }
                else if (line.IndexOf("</RelOp") != -1)
                {
                    mstack.Pop();
                }

            }

            writeEdges();
            writeDot();
        }

        private static void writeDot()
        {
            var enm1 = symtable.GetEnumerator();
            List<string> dots = new List<string>();
            while (enm1.MoveNext())
            {
                var key = enm1.Current.Key;
                var val = enm1.Current.Value;
                var tos = val.Split(new char[] { ',' });
                foreach (var s in tos)
                {
                    var edge = key + " -> " + s + "; ";
                    dots.Add(edge);
                }
            }

            string dothead = "digraph {";
            string dotend = "}";

            var write1 = System.IO.File.OpenWrite(@"C:\Users\JLiang\Documents\s.dot");
            StreamWriter writers1 = new StreamWriter(write1);

            string dotprog = dothead + string.Join("", dots) + dotend;
            writers1.WriteLine(dotprog);
            writers1.Flush();
            writers1.Close();
        }

        private static void writeEdges()
        {
            var enm = symtable.GetEnumerator();
            List<string> edges = new List<string>();
            while (enm.MoveNext())
            {
                var key = enm.Current.Key;
                var val = enm.Current.Value;
                var tos = val.Split(new char[] { ',' });
                foreach (var s in tos)
                {
                    var edge = key + "," + s;
                    edges.Add(edge);
                }
            }

            var write = System.IO.File.OpenWrite(@"C:\Users\JLiang\Documents\s.edges");
            StreamWriter writers = new StreamWriter(write);
            foreach (var VARIABLE in edges)
            {
                writers.WriteLine(VARIABLE);
            }
            writers.Flush();
            writers.Close();
        }

    }
}
