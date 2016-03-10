using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegateNamespace
{
    class Client
    {
        public static void run()
        {
            Simple simple = new Simple();
        
            simple.SartThread();
            simple.delegateInstance();
            simple.outerRef();
        }

        
    }
}
