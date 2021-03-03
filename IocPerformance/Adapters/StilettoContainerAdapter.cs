﻿// Ignored. Reason: Uses Fody which makes build process unstable
using System;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using Stiletto;

namespace IocPerformance.Adapters
{
    public class StilettoContainerAdapter : ContainerAdapterBase
    {
        private Container container;

        public override string PackageName => "Stiletto";

        public override string Url => "http://stiletto.bendb.com";

        public override bool SupportsPropertyInjection => true;

        public override void Prepare()
        {
            this.container = Container.Create(typeof(StilettoModule));
        }

        public override void PrepareBasic()
        {
            this.container = Container.Create(typeof(StilettoBasicModule));
        }

        public override object Resolve(Type type)
        {
            // Because Resolve(Type) is non-generic, we can't rely on efficient dispatch from the
            // container.  Resolvable types are hard-coded in the [Module] attribute anyways, so
            // there's minimal harm in reproducing that here.
            if (type == typeof(ITransient1))
            {
                return this.container.Get<ITransient1>();
            }

            if (type == typeof(ISingleton1))
            {
                return this.container.Get<ISingleton1>();
            }

            if (type == typeof(ICombined1))
            {
                return this.container.Get<ICombined1>();
            }

            if (type == typeof(IComplex1))
            {
                return this.container.Get<IComplex1>();
            }

            if (type == typeof(IComplexPropertyObject1))
            {
                return this.container.Get<IComplexPropertyObject1>();
            }

            // This is an unexpected type, and should have been configured.
            throw new Stiletto.Internal.BindingException("Non-injectable type requested: " + type.FullName);
        }

        public override void Dispose()
        {
            this.container = null;
        }

        [Module(
            Injects = new[] {
                typeof(ITransient1),
                typeof(ISingleton1),
                typeof(ICombined1),
                typeof(IComplex1),
            },

            IncludedModules = new[] { typeof(ProvideComplexDependenciesBasic) },

            // Because no concrete objects have ICombined, IComplex, and IComplexPropertyObject
            // injected, the compiler will complain about dead code unless we set IsLibrary to true.
            IsLibrary = true)]
        public class StilettoBasicModule
        {
            [Provides]
            public ITransient1 ProvideTransient(Transient1 transient) => transient;

            [Provides]
            public ISingleton1 ProvideSingleton(Singleton1 singleton) => singleton;

            [Provides]
            public ICombined1 ProvideCombined(Combined1 combined) => combined;

            [Provides]
            public IComplex1 ProvideComplex(Complex1 complex) => complex;
        }

        [Module(IsComplete = false)]
        public class ProvideComplexDependenciesBasic
        {
            [Provides]
            public IFirstService ProvideFirstService(FirstService service) => service;

            [Provides]
            public ISecondService ProvideSecondService(SecondService service) => service;

            [Provides]
            public IThirdService ProvideThirdService(ThirdService service) => service;

            [Provides]
            public ISubObjectOne ProvideSubObjectOne(SubObjectOne obj) => obj;

            [Provides]
            public ISubObjectTwo ProvideSubObjectTwo(SubObjectTwo obj) => obj;

            [Provides]
            public ISubObjectThree ProvidSubObjectThree(SubObjectThree obj) => obj;
        }

        [Module(
            Injects = new[] {
                typeof(ITransient1),
                typeof(ISingleton1),
                typeof(ICombined1),
                typeof(IComplex1),
                typeof(IComplexPropertyObject1),
            },

            IncludedModules = new[] { typeof(ProvideComplexDependencies) },

            // Because no concrete objects have ICombined, IComplex, and IComplexPropertyObject
            // injected, the compiler will complain about dead code unless we set IsLibrary to true.
            IsLibrary = true)]
        public class StilettoModule
        {
            [Provides]
            public ITransient1 ProvideTransient(Transient1 transient) => transient;

            [Provides]
            public ISingleton1 ProvideSingleton(Singleton1 singleton) => singleton;

            [Provides]
            public ICombined1 ProvideCombined(Combined1 combined) => combined;

            [Provides]
            public IComplex1 ProvideComplex(Complex1 complex) => complex;

            [Provides]
            public IComplexPropertyObject1 ProvideComplexPropertyObject(ComplexPropertyObject1 complex) => complex;
        }

        [Module(IsComplete = false)]
        public class ProvideComplexDependencies
        {
            [Provides]
            public IFirstService ProvideFirstService(FirstService service) => service;

            [Provides]
            public ISecondService ProvideSecondService(SecondService service) => service;

            [Provides]
            public IThirdService ProvideThirdService(ThirdService service) => service;

            [Provides]
            public ISubObjectOne ProvideSubObjectOne(SubObjectOne obj) => obj;

            [Provides]
            public ISubObjectTwo ProvideSubObjectTwo(SubObjectTwo obj) => obj;

            [Provides]
            public ISubObjectThree ProvidSubObjectThree(SubObjectThree obj) => obj;

            [Provides]
            public IServiceA ProvideServiceA(ServiceA service) => service;

            [Provides]
            public IServiceB ProvideServiceB(ServiceB service) => service;

            [Provides]
            public IServiceC ProvideServiceC(ServiceC service) => service;

            [Provides]
            public ISubObjectA ProvideSubObjectA(SubObjectA obj) => obj;

            [Provides]
            public ISubObjectB ProvideSubObjectB(SubObjectB obj) => obj;

            [Provides]
            public ISubObjectC ProvidSubObjectC(SubObjectC obj) => obj;
        }
    }
}
