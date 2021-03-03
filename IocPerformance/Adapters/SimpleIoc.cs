using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Adapters
{
    public class SimpleIoc : ContainerAdapterBase
    {
        private Container container;
        public override string PackageName => "Simple IOC";

        public override string Version => "1"; 

        public override string Url => ""; 

        public override void Dispose()
        {
      
        }

        public override void PrepareBasic()
        {
            container = new Container();

           RegisterDummies(container);
            RegisterStandard(container);
         //  RegisterComplexObject(container);
            
            container.Compile();
        }

        public override object Resolve(Type type)
        {
            return container.Resolve(type);
        }    

        private static void RegisterDummies(Container container)
        {
            container.Register<IDummyOne>(() => new DummyOne());
            container.Register<IDummyTwo>(() => new DummyTwo());
            container.Register<IDummyThree>(() => new DummyThree());
            container.Register<IDummyFour>(() => new DummyFour());
            container.Register<IDummyFive>(() => new DummyFive());
            container.Register<IDummySix>(() => new DummySix());
            container.Register<IDummySeven>(() => new DummySeven());
            container.Register<IDummyEight>(() => new DummyEight());
            container.Register<IDummyNine>(() => new DummyNine());
            container.Register<IDummyTen>(() => new DummyTen());
        }

        private static void RegisterStandard(Container container)
        {
            container.Register<ISingleton1>(() => new Singleton1(), entry => entry.Singleton = true);
            container.Register<ISingleton2>(() => new Singleton2(), entry => entry.Singleton = true);
            container.Register<ISingleton3>(() => new Singleton3(), entry => entry.Singleton = true);

            container.Register<ITransient1>(() => new Transient1());
            container.Register<ITransient2>(() => new Transient2());
            container.Register<ITransient3>(() => new Transient3());

            container.Register<ICombined1, Combined1>();
            container.Register<ICombined2, Combined2>();
            container.Register<ICombined3, Combined3>();
        }

        private static void RegisterComplexObject(Container container)
        {
            container.Register<IFirstService>(() => new FirstService(), entry => entry.Singleton = true);
            container.Register<ISecondService>(() => new SecondService(), entry => entry.Singleton = true);
            container.Register<IThirdService>(() => new ThirdService(), entry => entry.Singleton = true);

            container.Register<ISubObjectOne, SubObjectOne>();
            container.Register<ISubObjectTwo, SubObjectTwo>();
            container.Register<ISubObjectThree, SubObjectThree>();

            container.Register<IComplex1, Complex1>();
            container.Register<IComplex2, Complex2>();
            container.Register<IComplex3, Complex3>();
        }

        private static void RegisterMultiple(Container container)
        {
            container.Register<ISimpleAdapter>(() => new SimpleAdapterOne());
            container.Register<ISimpleAdapter>(() => new SimpleAdapterTwo());
            container.Register<ISimpleAdapter>(() => new SimpleAdapterThree());
            container.Register<ISimpleAdapter>(() => new SimpleAdapterFour());
            container.Register<ISimpleAdapter>(() => new SimpleAdapterFive());
        }
    }
}
