using System;
using IocPerformance.Adapters;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Benchmarks.Basic
{
    public class Transient_02_Benchmark : Benchmark
    {
        public override BenchmarkCategory Category => BenchmarkCategory.Basic;

        public override bool IsSupportedBy(IContainerAdapter container) => container.SupportsTransient;

        //private ITransientOne transientOne => new TransientOne();
        //private ITransientTwo transientTwo => new TransientTwo();
        //private ITransientThree transientThree => new TransientThree();

        public override void MethodToBenchmark(IContainerAdapter container)
        {
            var transient1 = (ITransientOne)container.Resolve(Index.GetTransientOne);
            var transient2 = (ITransientTwo)container.Resolve(Index.GetTransientTwo);
            var transient3 = (ITransientThree)container.Resolve(Index.GetTransientThree);
        }

        public override void Verify(Adapters.IContainerAdapter container)
        {
            if (!container.SupportsTransient)
                return;

            if (TransientOne.Instances != this.LoopCount
                || TransientTwo.Instances != this.LoopCount
                || TransientThree.Instances != this.LoopCount)
            {
                throw new Exception(string.Format("Transient count must be {0}", this.LoopCount));
            }
        }
    }
}