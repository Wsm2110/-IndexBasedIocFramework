using System;
using IocPerformance.Adapters;
using IocPerformance.Classes.Complex;

namespace IocPerformance.Benchmarks.Basic
{
    public class Complex_04_Benchmark : Benchmark
    {
        public override BenchmarkCategory Category => BenchmarkCategory.Basic;

        //private FirstService firstService = new FirstService();
        //private SecondService secondservice = new SecondService();
        //private ThirdService thirdService = new ThirdService();

        //private SubObjectOne ObjectOne => new SubObjectOne(firstService);
        //private SubObjectTwo ObjectTwo => new SubObjectTwo(secondservice);

        //private SubObjectThree ObjectThree => new SubObjectThree(thirdService);

        //private ComplexOne one => new ComplexOne(firstService, secondservice, thirdService, ObjectOne, ObjectTwo, ObjectThree);
        //private ComplexTwo two => new ComplexTwo(firstService, secondservice, thirdService, ObjectOne, ObjectTwo, ObjectThree);
        //private ComplexThree three => new ComplexThree(firstService, secondservice, thirdService, ObjectOne, ObjectTwo, ObjectThree);



        public override void MethodToBenchmark(IContainerAdapter container)
        {
            var complex1 = (IComplexOne)container.Resolve(Index.GetComplexOne);
            var complex2 = (IComplexTwo)container.Resolve(Index.GetComplexTwo);
            var complex3 = (IComplexThree)container.Resolve(Index.GetComplexThree);
        }

        public override void Verify(Adapters.IContainerAdapter container)
        {
            if (ComplexOne.Instances != this.LoopCount
                || ComplexTwo.Instances != this.LoopCount
                || ComplexThree.Instances != this.LoopCount)
            {
                throw new Exception(string.Format("Complex count must be {0}", this.LoopCount));
            }
        }
    }
}