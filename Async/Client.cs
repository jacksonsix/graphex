using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async
{
    class Client
    {
        public static void run()
        {
            myTask.task1();
            myTask.taskFactory();
            myTask.taskwait();
            myTask.taskwaitAny();
            myTask.taskdebugger();
        }
    }
}
