using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTrees
{
    using System.Linq.Expressions;

    class ModifyET
    {
        public static void run()
        {
            Expression<Func<string, bool>> expr = name => name.Length > 10 && name.StartsWith("G");
            Console.WriteLine(expr);

            AndAlsoModifier treeModifier = new AndAlsoModifier();
            Expression modifiedExpr = treeModifier.Mofidy((Expression)expr);
            Console.WriteLine(modifiedExpr);

        }
    }

    public class AndAlsoModifier : ExpressionVisitor
    {
        public Expression Mofidy(Expression expression)
        {
            return Visit(expression);
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (node.NodeType == ExpressionType.AndAlso)
            {
                Expression left = this.Visit(node.Left);
                Expression right = this.Visit(node.Right);
                return Expression.MakeBinary(ExpressionType.OrElse, left, right, node.IsLiftedToNull, node.Method);
            }
            return base.VisitBinary(node);
        }
    }
}
