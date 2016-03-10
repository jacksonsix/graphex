using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTrees
{
    using System.Diagnostics;
    using System.Linq.Expressions;

    class Simple
    {
        public static void Exp1()
        {
            Expression<Func<int, int>> exper = (x) => x + 1;
            var del = exper.Compile();
            Console.WriteLine(del(5));
        }

        public static long Measure(Action action)
        {
            System.Diagnostics.Stopwatch sw = new Stopwatch();
            sw.Start();
            action();
            sw.Stop();
            return sw.ElapsedMilliseconds;

        }

        public static void someMethod()
        {

            for (int i = 0; i < 500000; i++)
            {
                var s = i * 2;
            }
           
        }

        public static void someMethod2(out int outp)
        {
            outp = 0;
            for (int i = 0; i < 500; i++)
            {
                outp = i * 2;
            }
           
        }

        public static void Exp2()
        {

            var timeTaken = Measure(someMethod);

            //var timetaken = Measure(() => returnValue = someMethod(out int outp));

        }
    }
}
