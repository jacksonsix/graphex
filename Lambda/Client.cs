using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    class Client
    {
        public static void run()
        {

            Simple.Example1();
            Simple.Example2();
            Simple.ControlsEvents();
            Simple.Example3();
            Simple.ExampleQuery();
            Simple.ScopeLambda(12);
            AsyncForm form = new AsyncForm();

        }
    }
}
