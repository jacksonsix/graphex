using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Generic
{
    class AbastrctGeneric
    {
    }

    //public class Calculator<T>
    //{
    //    public T Add(T arg1, T arg2)
    //    {
    //        return arg1 + arg2;//Does not compile 
    //    }
    //    //Rest of the methods 
    //}

    //Nonetheless, you can compensate using abstract methods (or preferably interfaces) by defining generic operations. Since an abstract method cannot have any code in it, you can specify the generic operations at the base class level, and provide a concrete type and implementation at the subclass level:
    //public abstract class BaseCalculator<T>
    //{
    //   public abstract T Add(T arg1,T arg2);
    //   public abstract T Subtract(T arg1,T arg2);
    //   public abstract T Divide(T arg1,T arg2);
    //   public abstract T Multiply(T arg1,T arg2);
    //}
    //public class MyCalculator : BaseCalculator<int>
    //{
    //   public override int Add(int arg1, int arg2)
    //   {
    //      return arg1 + arg2;
    //   }
    //   //Rest of the methods 
    //} 

   // A generic interface will yield a somewhat cleaner solution as well:
    public interface ICalculator<T>
    {
       T Add(T arg1,T arg2);
       //Rest of the methods 
    }
    public class MyCalculator : ICalculator<int>
    {
       public int Add(int arg1, int arg2)
       {
          return arg1 + arg2;
       }
       //Rest of the methods 
    }

}
