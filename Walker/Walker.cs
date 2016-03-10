using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walker
{
    public class Walker
    {
        private Graph _graph;
        public Walker(Graph graph)
        {
            this._graph = graph;
        }

        public void DFSWalk()
        {

        }

        public void BFSWalk()
        {
            Queue<Node> que = new Queue<Node>();
            var allnodes = this._graph.nodes.Select(s => s.Value).ToArray();
            int[] flag = new int[allnodes.Count()];
            for (int i = 0; i < allnodes.Length;i++ )
            {
                var node = allnodes[i];
                var downs = node.downs;
                foreach (var down in downs)
                {
                    que.Enqueue(down.to);
                }

                var cur = que.Dequeue();

            }
        }

        public void GenericWalk()
        {

        }
    }
}
