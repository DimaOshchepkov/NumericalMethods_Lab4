using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Dichotomy : SolutionMethod
    {

        public Dichotomy(Func<double, double> func) : base(func) {}
        public Dichotomy(Function func) : base(func) { }
        public override double GetSolution(double begin, double end, double eps)
        {
            //double b_nMinusa_n = end - begin;
            double c = 0;
            while (Math.Abs(end - begin) >= eps && begin != end)
            {
                c = (begin + end) / 2;
                if (function.Value(begin) * function.Value(c) < 0)
                    end = c;
                else
                    begin = c;
            }
            return c;

        }
    }
}
