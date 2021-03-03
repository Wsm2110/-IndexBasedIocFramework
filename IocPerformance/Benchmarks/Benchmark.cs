using System.Text.RegularExpressions;
using IocPerformance.Adapters;
using IocPerformance.Classes.AspNet;
using IocPerformance.Classes.Child;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Benchmarks
{
    public abstract class Benchmark : IBenchmark
    {
        public virtual int LoopCount => 500 * 1000;

        public virtual ThreadingCases Threading => ThreadingCases.Single | ThreadingCases.Multi;

        public string Name
        {
            get
            {
                var name = this.GetType().Name.Split('_')[0];
                return Regex.Replace(name, "[A-Z]+", m => " " + m.Value).TrimStart();
            }
        }

        public abstract BenchmarkCategory Category { get; }

        public int Order => int.Parse(this.GetType().Name.Split('_')[1]);

        public virtual bool IsSupportedBy(IContainerAdapter container) => true;

        public abstract void MethodToBenchmark(IContainerAdapter container);

        public abstract void Verify(IContainerAdapter container);

        public override string ToString() => this.Name;

        public virtual void Warmup(IContainerAdapter container)
        {
            this.MethodToBenchmark(container);
            this.ZeroCounters();
        }

        protected void ZeroCounters()
        {
            ScopedCombinedOne.Instances = 0;
            ScopedCombinedTwo.Instances = 0;
            ScopedCombinedThree.Instances = 0;
            ComplexOne.Instances = 0;
            ComplexTwo.Instances = 0;
            ComplexThree.Instances = 0;
       
            ImportGeneric<int>.Instances = 0;
            ImportGeneric<float>.Instances = 0;
            ImportGeneric<object>.Instances = 0;
            ImportMultiple1.Instances = 0;
            ImportMultiple2.Instances = 0;
            ImportMultiple3.Instances = 0;
            ComplexPropertyObject1.Instances = 0;
            ComplexPropertyObject2.Instances = 0;
            ComplexPropertyObject3.Instances = 0;
            Calculator1.Instances = 0;
            Calculator2.Instances = 0;
            Calculator3.Instances = 0;
            CombinedOne.Instances = 0;
            CombinedTwo.Instances = 0;
            CombinedThree.Instances = 0;
            SingletonOne.Instances = 0;
            SingletonTwo.Instances = 0;
            SingletonThree.Instances = 0;
            TransientOne.Instances = 0;
            TransientTwo.Instances = 0;
            TransientThree.Instances = 0;

            TestController1.DisposeCount = 0;
            TestController1.Instances = 0;
            TestController2.DisposeCount = 0;
            TestController2.Instances = 0;
            TestController3.DisposeCount = 0;
            TestController3.Instances = 0;
            ScopedService1.Instances = 0;
            ScopedService2.Instances = 0;
            ScopedService3.Instances = 0;
            ScopedService4.Instances = 0;
            ScopedService5.Instances = 0;
            RepositoryTransient1.Instances = 0;
            RepositoryTransient2.Instances = 0;
            RepositoryTransient3.Instances = 0;
            RepositoryTransient4.Instances = 0;
            RepositoryTransient5.Instances = 0;
        }
    }
}