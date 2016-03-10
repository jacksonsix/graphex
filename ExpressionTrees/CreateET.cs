using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTrees
{
    using System.Linq.Expressions;

    internal class CreateET
    {
        // create from expression lambda
        public static void createFromLambda()
        {
            Expression<Func<int,bool>> lam = num  => num < 5;
        }

        public static void createFromAPI()
        {

            ParameterExpression numPara = Expression.Parameter(typeof(int), "num");
            ConstantExpression five = Expression.Constant(5, typeof(int));
            BinaryExpression numLessThanFive = Expression.LessThan(numPara, five);
            Expression<Func<int, bool>> lambda1 = Expression.Lambda<Func<int,bool>>(numLessThanFive,new ParameterExpression[]{numPara});



        }

        public static void createFromApi2()
        {
            ParameterExpression value = Expression.Parameter(typeof(int),"value");
            ParameterExpression result = Expression.Parameter(typeof(int), "result");

            LabelTarget label = Expression.Label(typeof(int));
            BlockExpression block = Expression.Block(
                // adding local variable
                new[] {result},
                Expression.Assign(result,Expression.Constant(1)),

                Expression.Loop(Expression.IfThenElse(
                    Expression.GreaterThan(value,Expression.Constant(1)),
                    Expression.MultiplyAssign(result,Expression.PostDecrementAssign(value)),
                    Expression.Break(label, result)),
                    label));


            int factorial = Expression.Lambda<Func<int, int>>(block, value).Compile()(5);

            Console.WriteLine(factorial);

        }

        public static void ParsingET()
        {
            Expression<Func<int, bool>> exprTree = num => num < 5;
            ParameterExpression param = (ParameterExpression)exprTree.Parameters[0];
            BinaryExpression operation = (BinaryExpression)exprTree.Body;
            ParameterExpression left = (ParameterExpression)operation.Left;
            ConstantExpression right = (ConstantExpression)operation.Right;

            Console.WriteLine("Deocmposed expersion : {0} => {1}{2}{3}",
                param.Name,left.Name,operation.NodeType,right.Value);

        }

        public static void ComplileET()
        {
            Expression<Func<int, bool>> expr = num => num < 5;

            Func<int, bool> result = expr.Compile();

            Console.WriteLine(result(4));

            //
            Console.WriteLine(expr.Compile()(7));
        }
    }
}
