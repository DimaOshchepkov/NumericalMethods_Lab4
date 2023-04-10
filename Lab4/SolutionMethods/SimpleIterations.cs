using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class SimpleIterations : SolutionMethod
    {
        Function mapping;
        public SimpleIterations(Function func, Func<double, double> mapping) : base(func)
        {
            this.mapping = new Function(mapping);
        }

        public SimpleIterations(Function func, Function mapping) : base(func)
        {
            this.mapping = new Function(mapping);
        }

        public void SetMapping(Func<double, double> mapping) => this.mapping = new Function(mapping);
        public void SetMapping(Function mapping) => this.mapping = new Function(mapping);


        public override double GetSolution(double begin, double end, double eps)
        {
            double q = Function.MaximumInTheInterval(mapping.Df, begin, end);
            double E1 = eps * (1 - q) / q;

            if (q >= 0)
                throw new ArgumentException("В качестве аргумента передано не сжимающее отображение");

            int coutnIter = 0;

            string format = "{0,12} {1,23} {2,23} {3,23} {4,23} {5,23}";
            string title = String.Format(format, "№ итерации i", "x_i", "f(x_i)",
                                            "x_i+1", "delta",
                                            "Достигнута ли точность");

            Console.WriteLine(title);

            double x0 = (begin + end) / 2;
            double x = x0;
            string info;
            do
            {

                info = String.Format(format, coutnIter, x0, function.Value(x),
                                            x, Math.Abs(x - x0), "No");
                Console.WriteLine(info);

                x0 = x;
                x = mapping.Value(x0);
            } while (Math.Abs(x - x0) >= E1);

            info = String.Format(format, coutnIter, x0, function.Value(x),
                                            x, Math.Abs(x - x0), "Yes");
            Console.WriteLine(info);

            return x;
        }
    }
}
