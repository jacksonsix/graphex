using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTrees
{
    using System.Linq.Expressions;

    class buildQueryFromET
    {
        //companies.Where(comparny => company.ToLower() == "cobo winery" || company.Length > 16).OrderBy(company => company)

        public static void buildQuery()
        {
            string[] compnies = { "Consolidated Messenger", "Alpine Ski House", "Southridge Video", "City Power & Light",
                                   "Coho Winery", "Wide World Importers", "Graphic Design Institute", "Adventure Works",
                                   "Humongous Insurance", "Woodgrove Bank", "Margie's Travel", "Northwind Traders",
                                   "Blue Yonder Airlines", "Trey Research", "The Phone Company",
                                   "Wingtip Toys", "Lucerne Publishing", "Fourth Coffee" };
            IQueryable<string> queryableData = compnies.AsQueryable<string>();

            ParameterExpression pe = Expression.Parameter(typeof(string), "company");
            Expression left = Expression.Call(pe, typeof(string).GetMethod("ToLower", System.Type.EmptyTypes));
            Expression right = Expression.Constant("cobo winery");
            Expression e1 = Expression.Equal(left, right);

            left = Expression.Property(pe, typeof(string).GetProperty("Length"));
            right = Expression.Constant(16, typeof(int));
            Expression e2 = Expression.GreaterThan(left, right);

            //combine
            Expression predicateBody = Expression.OrElse(e1, e2);

            MethodCallExpression wherecallExpre = Expression.Call(
                typeof(Queryable),
                "Where",
                new Type[]{queryableData.ElementType},
                queryableData.Expression,
                Expression.Lambda<Func<string,bool>>(predicateBody,new ParameterExpression[]{pe}));
            // End where

            MethodCallExpression oderby = Expression.Call(
                typeof(Queryable),
                "OrderBy",
                new Type[] {queryableData.ElementType,queryableData.ElementType},
                wherecallExpre,
                Expression.Lambda<Func<string,string>>(pe,new ParameterExpression[]{pe})
                );
            //End OrderBy

            IQueryable<string> results = queryableData.Provider.CreateQuery<string>(oderby);

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}
