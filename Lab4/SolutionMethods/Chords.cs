using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Chords : SolutionMethod
    {
        public Chords(Func<double, double> func) : base(func) { }
        public Chords(Function func) : base(func) { }

        public override double GetSolution(double begin, double end, double eps)
        {
            double xNew = 0, x = 0, c = 0;
            double m = Function.MinimumInTheInterval(function.Df, begin, end);
            double M = Function.MaximumInTheInterval(function.Df, begin, end);

            if (function.Df((begin + end) / 2) < 0)
            {
                c = end;
                xNew = begin;
            }
            else
            {
                c = begin;
                xNew = end;
            }

            do
            {
                x = xNew;
                xNew = x - function.Value(x) * (c - x) / (function.Value(c) - function.Value(x));
            } while (Math.Abs(xNew - x) < (eps * m) / (M - m));

            return xNew;
        }
    }
}
