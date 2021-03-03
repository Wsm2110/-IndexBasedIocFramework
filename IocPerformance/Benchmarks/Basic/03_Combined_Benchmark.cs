using System;
using IocPerformance.Adapters;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Benchmarks.Basic
{
    public class Combined_03_Benchmark : Benchmark
    {
        public override BenchmarkCategory Category => BenchmarkCategory.Basic;

        public override bool IsSupportedBy(IContainerAdapter container) => container.SupportsCombined;

        //private ISingletonOne singletonOne = new SingletonOne();
        //private ITransientOne transientOne => new TransientOne();

        //private ISingletonTwo singletonTwo = new SingletonTwo();
        //private ITransientTwo transientTwo => new TransientTwo();

        //private ISingletonThree singletonThree = new SingletonThree();
        //private ITransientThree transientThree => new TransientThree();

        //private CombinedOne combinedOne => new CombinedOne(singletonOne, transientOne);
        //private CombinedTwo combinedTwo => new CombinedTwo(singletonTwo, transientTwo);
        //private CombinedThree combinedThree => new CombinedThree(singletonThree, transientThree);

        public override void MethodToBenchmark(IContainerAdapter container)
        {
            var combined1 = (ICombinedOne)container.Resolve(Index.GetCombinedOne);
            var combined2 = (ICombinedTwo)container.Resolve(Index.GetCombinedTwo);
            var combined3 = (ICombinedThree)container.Resolve(Index.GetCombinedThCombinedThree);
        }

        public override void Verify(Adapters.IContainerAdapter container)
        {
            if (!container.SupportsCombined)
                return;

            if (CombinedOne.Instances != this.LoopCount
                || CombinedTwo.Instances != this.LoopCount
                || CombinedThree.Instances != this.LoopCount)
            {
                throw new Exception(string.Format("Combined count must be {0}", this.LoopCount));
            }

            if (TransientOne.Instances != this.LoopCount
                || TransientTwo.Instances != this.LoopCount
                || TransientThree.Instances != this.LoopCount)
            {
                throw new Exception(string.Format("Transient count must be {0}", this.LoopCount));
            }

            if (SingletonOne.Instances > 1 || SingletonTwo.Instances > 1 || SingletonTwo.Instances > 1)
            {
                throw new Exception("Singleton instance count must be 1. Container: " + container.Name);
            }
        }
    }
}