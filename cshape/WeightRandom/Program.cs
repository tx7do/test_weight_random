using System;
using System.Collections.Generic;
using System.Diagnostics;
using NPOI.SS.Formula.Functions;

namespace WeightRandom
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var itemBuffer = new List<double>();
            var weightBuffer = new List<float>();

            const int seed = 56;
            for (var i = 0; i < 32; i++)
            {
                itemBuffer.Add(i);
                weightBuffer.Add((float) Math.Sqrt(i + 1));
            }

            var items = itemBuffer.ToArray();
            var cda = weightBuffer.ToArray();

            RandomMath.BuildCumulativeDistribution(cda);

            var generator = new Linear<double>(items, cda, seed);

            for (var i = 0; i < 100; i++)
            {
                Console.WriteLine(i + ". " + generator.SelectRandomItem());
            }
        }
    }
}