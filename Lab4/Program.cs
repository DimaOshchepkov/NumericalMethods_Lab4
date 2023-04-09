using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> MyFunc = x => Math.Log(x) - 7 / (2 * x + 6);
            Func<double, double> df = x => 7 / (2 * (x + 3) * (x + 3)) + 1 / x;
            Func<double, double> ddf = x => -1 / (x * x) - 7 / (Math.Pow(x + 3, 3));
            Func<double, double> mapping = x => (7 - 6 * Math.Log(x)) /
                                        (2 * Math.Log(x));

            Function f = new Function(MyFunc, df, ddf);
            Function f2 = new Function(MyFunc);

            SolutionMethod dichotomy = new Dichotomy(f);
            double solution = dichotomy.GetSolution(1.5, 2.5, 1e-4);
            Console.WriteLine(solution);

            SolutionMethod chords = new Chords(f);
            solution = chords.GetSolution(1.5, 2.5, 1e-4);
            Console.WriteLine(solution);

            SolutionMethod simpleIteration = new SimpleIterations(f, mapping);
            solution = simpleIteration.GetSolution(1.5, 2.5, 1e-4);
            Console.WriteLine(solution);

            SolutionMethod tangent = new Tangent(f);
            solution = tangent.GetSolution(1.5, 2.5, 1e-4);
            Console.WriteLine(solution);


            SolutionMethod dichotomy2 = new Dichotomy(f2);
            double solution2 = dichotomy2.GetSolution(1.5, 2.5, 1e-4);
            Console.WriteLine(solution2);

            SolutionMethod chords2 = new Chords(f2);
            solution2 = chords2.GetSolution(1.5, 2.5, 1e-4);
            Console.WriteLine(solution2);

            SolutionMethod simpleIteration2 = new SimpleIterations(f2, mapping);
            solution2 = simpleIteration2.GetSolution(1.5, 2.5, 1e-4);
            Console.WriteLine(solution2);

            SolutionMethod tangent2 = new Tangent(f2);
            solution2 = tangent2.GetSolution(1.5, 2.5, 1e-4);
            Console.WriteLine(solution2);

            Console.ReadKey();
        }
    }
}
