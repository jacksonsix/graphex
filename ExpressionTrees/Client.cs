using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTrees
{
    class Client
    {
        public static void run()
        {
            Simple.Exp1();
            Simple.Exp2();

            CreateET.createFromAPI();
            CreateET.createFromApi2();
            CreateET.createFromLambda();
            CreateET.ParsingET();
            CreateET.ComplileET();
            
            buildQueryFromET.buildQuery();
            ModifyET.run();
        }
    }
}
