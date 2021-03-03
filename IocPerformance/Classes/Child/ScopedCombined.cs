using System;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Classes.Child
{
    public class ScopedCombinedOne : ICombinedOne
    {
        private static int counter;

        public ScopedCombinedOne(ITransientOne transient, ISingletonOne singleton)
        {
            if (transient == null)
            {
                throw new ArgumentNullException(nameof(transient));
            }

            if (singleton == null)
            {
                throw new ArgumentNullException(nameof(singleton));
            }

            if (!(transient is ScopedTransient))
            {
                throw new ArgumentException("transient should be of type ScopedTransient");
            }

            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        public void DoSomething()
        {
            Console.WriteLine("Combined");
        }
    }

    public class ScopedCombinedTwo : ICombinedTwo
    {
        private static int counter;

        public ScopedCombinedTwo(ITransientOne transient, ISingletonOne singleton)
        {
            if (transient == null)
            {
                throw new ArgumentNullException(nameof(transient));
            }

            if (singleton == null)
            {
                throw new ArgumentNullException(nameof(singleton));
            }

            if (!(transient is ScopedTransient))
            {
                throw new ArgumentException("transient should be of type ScopedTransient");
            }

            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        public void DoSomething()
        {
            Console.WriteLine("Combined");
        }
    }

    public class ScopedCombinedThree : ICombinedThree
    {
        private static int counter;

        public ScopedCombinedThree(ITransientOne transient, ISingletonOne singleton)
        {
            if (transient == null)
            {
                throw new ArgumentNullException(nameof(transient));
            }

            if (singleton == null)
            {
                throw new ArgumentNullException(nameof(singleton));
            }

            if (!(transient is ScopedTransient))
            {
                throw new ArgumentException("transient should be of type ScopedTransient");
            }

            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        public void DoSomething()
        {
            Console.WriteLine("Combined");
        }
    }
}
