using System;
using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Standard
{
    public interface ICombinedOne
    {
        void DoSomething();
    }

    public interface ICombinedTwo
    {
        void DoSomething();
    }

    public interface ICombinedThree
    {
        void DoSomething();
    }

    public class CombinedOne : ICombinedOne
    {
        protected static int counter;

        protected CombinedOne()
        {
        }


        public CombinedOne(ISingletonOne singletonOne, ITransientOne transientOne)
        {
            if (singletonOne == null)
            {
                throw new ArgumentNullException(nameof(singletonOne));
            }

            if (transientOne == null)
            {
                throw new ArgumentNullException(nameof(transientOne));
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

    public class CombinedTwo : ICombinedTwo
    {
        protected static int counter;

        protected CombinedTwo()
        {
        }



        public CombinedTwo(ISingletonTwo singletonTwo, ITransientTwo transientTwo)
        {
            if (singletonTwo == null)
            {
                throw new ArgumentNullException(nameof(singletonTwo));
            }

            if (transientTwo == null)
            {
                throw new ArgumentNullException(nameof(transientTwo));
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

    public class CombinedThree : ICombinedThree
    {
        protected static int counter;

        protected CombinedThree()
        {
        }

        public CombinedThree(ISingletonThree singletonThree, ITransientThree transientThree)
        {
            if (singletonThree == null)
            {
                throw new ArgumentNullException(nameof(singletonThree));
            }

            if (transientThree == null)
            {
                throw new ArgumentNullException(nameof(transientThree));
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
