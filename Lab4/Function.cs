using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Function
    {
        private Func<double, double> myFunc;
        private Func<double, double> df;
        private Func<double, double> ddf;

        public double eps { get; set; }

        public Function(Func<double, double> func)
        {
            myFunc = func;
            eps = 1e-5;
        }

        public Function(Func<double, double> func, Func<double, double> df, Func<double, double> ddf)
        {
            this.myFunc = func;
            this.df = df;
            this.ddf = ddf;
            eps = 1e-5;
        }

        public Function(Function func)
        {
            myFunc = func.myFunc;
            df = func.df;
            ddf = func.ddf;
            eps = func.eps;
        }

        public void SetFunc(Func<double, double> func) => myFunc = func;

        public void SetDf(Func<double, double> df) => this.df = df;
        public void SetDdf(Func<double, double> ddf) => this.ddf = ddf;

        public double Df(double x)
        {
            if (this.df == null)
                return (myFunc(x + eps) - myFunc(x - eps)) / (2 * eps);
            else
                return this.df(x);
        }
        public double Ddf(double x)
        {
            if (this.ddf == null)
                return (Df(x + eps) - Df(x - eps)) / (2 * eps);
            else
                return this.ddf(x);
        }
        public double Value(double x) => myFunc(x);

        public static double MaximumInTheInterval(Func<double, double> func, double begin, double end, double eps = 1e-2)
        {
            double max = func(begin);
            while (begin < end)
            {
                max = Math.Max(max, func(begin));
                begin += eps;
            }
            return max;
        }

        public static double MinimumInTheInterval(Func<double, double> func, double begin, double end, double eps = 1e-3)
        {
            double min = func(begin);
            while (begin < end)
            {
                min = Math.Min(min, func(begin));
                begin += eps;
            }
            return min;
        }
    }
}
