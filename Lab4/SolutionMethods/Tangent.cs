using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab4
{
    internal class Tangent : SolutionMethod
    {
        public Tangent(Func<double, double> func) : base(func) { }
        public Tangent(Function func) : base(func) { }

        public override double GetSolution(double begin, double end, double eps)
        {
            double m = Function.MinimumInTheInterval(function.Df, begin, end);
            double M = Function.MaximumInTheInterval(function.Ddf, begin, end);
            double x0, x;
            if (function.Ddf(begin) * function.Value(begin) > 0)
                x0 = begin;
            else
                x0 = end;

            x = x0 - function.Value(x0) / function.Df(x0);
            while (Math.Abs(x - x0) >= Math.Sqrt(2 * m * eps / M))
            {
                
                x = x0 - function.Value(x0) / function.Df(x0);
                if (Math.Abs(x - x0) >= Math.Sqrt(2 * m * eps / M))
                    x0 = x;

            } 
            return x;
        }
    }
}
