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

            if (q >= 0)
                throw new ArgumentException("В качестве аргумента передано не сжимающее отображение");

            double x0 = (begin + end) / 2;
            double x = x0;
            do
            {
                x0 = x;
                x = mapping.Value(x0);
            } while (Math.Abs(x - x0) < eps * (1 - q) / q);

            return x;
        }
    }
}
