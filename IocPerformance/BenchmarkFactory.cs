using System;
using System.Collections.Generic;
using System.Linq;
using IocPerformance.Benchmarks;
using IocPerformance.Benchmarks.Basic;
using IocPerformance.Benchmarks.Prepare;

namespace IocPerformance
{
    internal static class BenchmarkFactory
    {
        public static IEnumerable<IBenchmark> CreateBenchmarks()
        {
            yield return new Singleton_01_Benchmark();
            yield return new Transient_02_Benchmark();
            yield return new Combined_03_Benchmark();
            yield return new Complex_04_Benchmark();
            yield return new PrepareAndRegisterAndSimpleResolve_13_Benchmark();
            yield return new PrepareAndRegister_12_Benchmark();
          
            //var benchmarks = typeof(BenchmarkFactory).Assembly.GetTypes()
            //     .Where(t => t.IsClass && !t.IsAbstract && typeof(IBenchmark).IsAssignableFrom(t))
            //     .Select(t => Activator.CreateInstance(t))
            //     .Cast<IBenchmark>()
            //     .OrderBy(b => b.Order);

            //if (benchmarks.Count() != benchmarks.Select(b => b.Name).Distinct().Count())
            //{
            //    var duplicateNames = benchmarks
            //        .GroupBy(b => b.Name)
            //        .Where(g => g.Count() > 1)
            //        .Select(g => g.Key);

            //    throw new InvalidOperationException(string.Format(
            //        "Benchmarks must have unique names, the following names are used several times: {0}",
            //        string.Join(", ", duplicateNames)));
            //}

            //return benchmarks;
        }
    }
}
