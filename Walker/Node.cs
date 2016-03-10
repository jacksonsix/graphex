using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walker
{
    public class Node
    {
        public string Id;

        public IList<Edge> ups;
        public IList<Edge> downs;
        public Node()
        {
            this.ups = new List<Edge>();
            this.downs = new List<Edge>();
        }
    }
}
