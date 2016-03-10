using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegateNamespace
{
    using System.Threading;
    using System.Windows.Forms;

    internal delegate void Printer(string s);
    class Simple
    {
        private Button button1;

        private delegate void Delg(int x);

        public Simple()
        {
            button1 = new Button();
        }

        public  void eventHandler()
        {
            button1.Click += delegate(object sender, EventArgs e)
                { MessageBox.Show("hello"); };
        }

        public void createDelegate()
        {
            Delg del = delegate(int k) { k = 0; };
        }

        public void SartThread()
        {
            System.Threading.Thread t1 = new Thread(delegate()
                {
                    Console.WriteLine("Hello");
                    Console.WriteLine("World");
                });

            t1.Start();
        }

        public void outerRef()
        {
            int n = 0;
            Delg cap = delegate(int x) { Console.WriteLine("copy #:{0}", ++x); };
            cap(9);
        }

        public void delegateInstance()
        {
            Printer p = delegate(string j)
                {
                    Console.WriteLine("anonymous printer {0}", j);
                };

            p("001");

            p = new  Printer(Simple.DoPrint);
            p("002");

        }

        protected static void DoPrint(string k)
        {
            Console.WriteLine("Named mehtod printer {0}",k);
        }


    }
}
