using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    abstract internal class SolutionMethod
    {
        protected Function function;

        protected SolutionMethod(Func<double, double> func)
        {
            function = new Function(func);
        }
        protected SolutionMethod(Function function)
        {
            this.function = function;
        }

        public abstract double GetSolution(double begin, double end, double eps);
    }
}
