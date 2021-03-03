using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Standard;
using System;
using SimpleIoc;
using SimpleIoc.Contracts;

namespace IocPerformance.Adapters
{
    public class MadIocAdapter : ContainerAdapterBase
    {
        SimpleIoc.Container _container;

        public override string PackageName => "Wsm.IOC";

        public override string Name => "ä";

        public override string Version => "1";

        public override string Url => "";

        public override void PrepareBasic()
        {
            _container = new Container();

            RegisterDummies(_container);
            RegisterStandard(_container);
            RegisterComplexObject(_container);

            _container.Build();
        }

        public override object Resolve(Type type)
        {
            return null;
        }

        public override object Resolve(int type)
        {
            return _container.Resolve(type);
        }

        private static void RegisterDummies(Container container)
        {
            container.Register<IDummyOne, DummyOne>(Index.GetDummyOne);
            container.Register<IDummyTwo, DummyTwo>(Index.GetDummyTwo);
            container.Register<IDummyThree, DummyThree>(Index.GetDummyTree);
            container.Register<IDummyFour, DummyFour>(Index.GetDummyFour);
            container.Register<IDummyFive, DummyFive>(Index.GetDummyFive);
            container.Register<IDummySix, DummySix>(Index.GetDummySix);
            container.Register<IDummySeven, DummySeven>(Index.GetDummySeven);
            container.Register<IDummyEight, DummyEight>(Index.GetDummyEight);
            container.Register<IDummyNine, DummyNine>(Index.GetDummyNine);
            container.Register<IDummyTen, DummyTen>(Index.GetDummyTen);
        }

        private static void RegisterStandard(Container container)
        {
            container.Register<ISingletonOne, SingletonOne>(Lifetime.Singleton, Index.GetSingletonOne);
            container.Register<ISingletonTwo, SingletonTwo>(Lifetime.Singleton, Index.GetSingletonTwo);
            container.Register<ISingletonThree, SingletonThree>(Lifetime.Singleton, Index.GetSingletonThree);

            container.Register<ITransientOne, TransientOne>(Index.GetTransientOne);
            container.Register<ITransientTwo, TransientTwo>(Index.GetTransientTwo);
            container.Register<ITransientThree, TransientThree>(Index.GetTransientThree);

            container.Register<ICombinedOne, CombinedOne>(Index.GetCombinedOne);
            container.Register<ICombinedTwo, CombinedTwo>(Index.GetCombinedTwo);
            container.Register<ICombinedThree, CombinedThree>(Index.GetCombinedThCombinedThree);
        }

        private static void RegisterComplexObject(Container container)
        {
            container.Register<IFirstService, FirstService>(Lifetime.Singleton, Index.GetFirstService);
            container.Register<ISecondService, SecondService>(Lifetime.Singleton, Index.GetSecondService);
            container.Register<IThirdService, ThirdService>(Lifetime.Singleton, Index.GetThirdService);

            container.Register<ISubObjectOne, SubObjectOne>(Index.GetSubObjectOne);
            container.Register<ISubObjectTwo, SubObjectTwo>(Index.GetSubObjectTwo);
            container.Register<ISubObjectThree, SubObjectThree>(Index.GetSubObjectThree);

            container.Register<IComplexOne, ComplexOne>(Index.GetComplexOne);
            container.Register<IComplexTwo, ComplexTwo>(Index.GetComplexTwo);
            container.Register<IComplexThree, ComplexThree>(Index.GetComplexThree);
        }

        public override void Dispose()
        {

        }
    }
}
