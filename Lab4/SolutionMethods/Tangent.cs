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
            double E1 = Math.Sqrt(Math.Abs(2 * m * eps / M));
            double x0, x;
            if (function.Ddf(begin) * function.Value(begin) > 0)
                x0 = begin;
            else
                x0 = end;

            int coutnIter = 0;

            string format = "{0,12} {1,23} {2,23} {3,23} {4,23} {5,23}";
            string title = String.Format(format, "№ итерации i", "x_i", "f(x_i)",
                                            "x_i+1", "delta", "Достигнута ли точность");
            string info;
            x = x0 - function.Value(x0) / function.Df(x0);
            while (Math.Abs(x - x0) >= E1)
            {
                info = String.Format(format, coutnIter, x0, function.Value(x),
                                            x, Math.Abs(x - x0), "No");
                Console.WriteLine(info);
                x0 = x;
                x = x0 - function.Value(x0) / function.Df(x0);
            }
            
            info = String.Format(format, coutnIter, x0, function.Value(x),
                                            x, Math.Abs(x - x0), "Yes");
            Console.WriteLine(info);

            return x;
        }
    }
}
