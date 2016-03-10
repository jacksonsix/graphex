using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walker
{
    public  class Graph
    {
        public Dictionary<string, Node> nodes;

        public Dictionary<string, Edge> edges; 

        public Graph()
        {
            nodes = new Dictionary<string, Node>();
            edges = new Dictionary<string, Edge>();
        }

        public Node getNodeById(string nodeId)
        {
            Node node = null;
            bool success = nodes.TryGetValue(nodeId,out node);
            return node;
        }

        public Edge getEdgeById(string edgeId)
        {
            Edge edge = null;
            bool suc = edges.TryGetValue(edgeId, out edge);
            return edge;
        }

        public void readin()
        {
            var lines = System.IO.File.ReadAllLines(@"C:\Users\JLiang\Documents\s.edges");
            for (int i = 0; i < lines.Length; i++)
            {
                var segs = lines[i].Split(new char[] {','});
                string fromid = segs[0];
                string toid = segs[1];

                var from = this.getNodeById(fromid);
                if (from == null)
                {
                    from  = new Node();
                    from.Id = fromid;
                    this.nodes.Add(fromid,from);
                }

                var to = this.getNodeById(toid);
                if (to == null)
                {
                    to = new Node();
                    to.Id = toid;
                    this.nodes.Add(toid, to);
                }

                string edgeid = fromid + "," + toid;
                var edge = this.getEdgeById(edgeid);
                if (edge == null)
                {
                    edge = new Edge();
                    edge.from = from;
                    edge.to = to;
                    this.edges.Add(edgeid,edge);
                }

                // update relation of node
                from.downs.Add(edge);
                to.ups.Add(edge);
            }
        }
    }
}
