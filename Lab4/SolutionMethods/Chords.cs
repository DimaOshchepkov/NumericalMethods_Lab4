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
            double E1 = (eps * m) / (M - m);

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

            int coutnIter = 0;

            string format = "{0,12} {1,23} {2,23} {3,23} {4,23} {5,23}";
            string title = String.Format(format, "№ итерации i", "x_i", "f(x_i)",
                                            "x_i+1", "delta", "Достигнута ли точность");
            string info;
            Console.WriteLine(title);
            do
            {
                info = String.Format(format, coutnIter, x, function.Value(xNew),
                                            xNew, Math.Abs(xNew - x), "No");
                Console.WriteLine(info);

                x = xNew;
                xNew = x - function.Value(x) * (c - x) / (function.Value(c) - function.Value(x));
                coutnIter++;
            } while (Math.Abs(xNew - x) >= E1);

            info = String.Format(format, coutnIter, x, function.Value(xNew),
                                            xNew, Math.Abs(xNew - x), "Yes");
            Console.WriteLine(info);

            return xNew;
        }
    }
}
