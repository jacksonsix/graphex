using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async
{
    using System.Threading;

    class myTask
    {
        public static void task1()
        {

            Task t = Task.Run(
                () =>
                    { int ctr = 0;
                        Console.WriteLine(ctr);
                    });

            t.Wait();
        }

        public static void taskFactory()
        {
            Task t = Task.Factory.StartNew(
                () =>
                    {
                        int ctr = 0;
                        Console.WriteLine(ctr);
                    });
            t.Wait();

        }

        public static void taskwait()
        {
            Task task = Task.Run(() => Thread.Sleep(1000));

            Console.WriteLine("task status {0}",task.Status);
            try
            {
                task.Wait();
                Console.WriteLine("task status {0}", task.Status);
            }
            catch (Exception)
            {Console.WriteLine("exception");
            }

        }

        public static void taskwaitAny()
        {
            var tasks = new Task[5];
            var rand = new Random();
            for (int i = 0; i < 5; i++) tasks[i] = Task.Run(() => Thread.Sleep(rand.Next(500,3000)));

            try
            {
                int index = Task.WaitAny(tasks);
                Console.WriteLine("task {0} first finished",index);
                foreach (var task in tasks)
                {
                    Console.WriteLine("task {0} status {1}",task.Id,task.Status);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("exception");
            }
        }

        public static void taskdebugger()
        {
            Action<object> action = (object obj) =>
                {
                    Console.WriteLine("task = {0},obj ={1},Thread={2}",Task.CurrentId,obj,Thread.CurrentThread.ManagedThreadId);

                };
            //create the task but do not start
            Task t1 = new Task(action,"alpha");

            Task t2 = Task.Factory.StartNew(action, "beta");
            t2.Wait();

            t1.Start();
            Console.WriteLine("t1 has started");

            t1.Wait();

            string taskData = "delta";
            Task t3 = Task.Run(() =>
                {
                    Console.WriteLine("task = {0}, obj = {1},thread={2}",Task.CurrentId,taskData,Thread.CurrentThread.ManagedThreadId);
                });
            t3.Wait();

            Task t4 = new Task(action,"gamma");
            t4.RunSynchronously();
            t4.Wait();
        }
    }
}
