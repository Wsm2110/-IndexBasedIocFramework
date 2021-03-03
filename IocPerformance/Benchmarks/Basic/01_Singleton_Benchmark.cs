using System;
using IocPerformance.Adapters;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Benchmarks.Basic
{
    public class Singleton_01_Benchmark : Benchmark
    {
        public override BenchmarkCategory Category => BenchmarkCategory.Basic;

        //private ISingletonOne singletonOne = new SingletonOne();

        //private ISingletonTwo singletonTwo = new SingletonTwo();

        //private ISingletonThree singletonThree = new SingletonThree();

        public override void MethodToBenchmark(IContainerAdapter container)
        {
            var singleton1 = (ISingletonOne) container.Resolve(Index.GetSingletonOne);
            var singleton2 = (ISingletonTwo)container.Resolve(Index.GetSingletonTwo);
            var singleton3 = (ISingletonThree)container.Resolve(Index.GetSingletonThree);
        }

        public override void Verify(Adapters.IContainerAdapter container)
        {
            if (SingletonOne.Instances > 1 || SingletonTwo.Instances > 1 || SingletonTwo.Instances > 1)
            {
                throw new Exception("Singleton instance count must be 1. Container: " + container.Name);
            }
        }
    }
}