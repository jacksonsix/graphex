using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    using System.Linq.Expressions;
    using System.Windows.Forms;

    public class Simple
    {
        delegate int del(int i);

        private delegate void TestDelegate(string s);

        private delegate bool delbool();

        public static void Example1()
        {
            //lambda
            var evens = Enumerable.Range(1, 100).Where(x => (x % 2) == 0).ToList();

            // anonymous delegate
            var even = Enumerable.Range(1, 100).Where(delegate(int x) { return x % 2 == 0; }).ToList();
        }

        public static void Example2()
        {
            List<string> people = new List<string>();
            people.AddRange(
                new string[] {"alex","brain","Joe"});

            // lambda
            string person = people.Find(p => p.Contains("Joe"));

            // anonymous delegate
            string person1 = people.Find(
                    (x) => FindPerson("Joe",people)
                   );


        }

        private static bool FindPerson(string nameContains, List<string> persons)
        {
            foreach (var person in persons)
            {
                if (person.Contains(nameContains))
                {
                    return true;
                }
              
            }
            return false;
        }

        public static void ControlsEvents()
        {

            ComboBox combo = new ComboBox();
            Label label = new Label();

            combo.SelectedIndexChanged += (sender, eventArgs) => { label.Text = combo.SelectedValue.ToString(); };

        }


        public static void Example3()
        {

            del myDelegate = x => x * x;
            int j = myDelegate(5);

            Expression<del> myET = x => x * x;

            //Statement lambdas

            TestDelegate myDel = n => { string s = n + " " + "World"; 
                                         Console.WriteLine(s);
                                       };

            myDel("Hello");

        }

        public static void ExampleQuery()
        {
            Func<int, bool> myFunc = x => x == 5;
            bool result = myFunc(4);

            int[] numbers = { 5,4,3,7,5,9 };
            int oddNumbers = numbers.Count(n => n % 2 == 1);

            var firstNumberslessthan6 = numbers.TakeWhile(n=> n< 6);

            var firstLargerthanIndexNumbers = numbers.TakeWhile((n,index) => n >= index);
        }

        public static void ScopeLambda(int input)
        {
            int j = 45;
            delbool mybool = () =>
                {
                    j = 10;
                    return j > input;
                };

            bool result = mybool();
        }

       
    }
}
