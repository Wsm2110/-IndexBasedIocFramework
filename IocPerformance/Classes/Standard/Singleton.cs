using System;
using System.ComponentModel.Composition;


namespace IocPerformance.Classes.Standard
{
    public interface ISingletonOne
    {
        void DoSomething();
    }

    public interface ISingletonTwo
    {
        void DoSomething();
    }

    public interface ISingletonThree
    {
        void DoSomething();
    }
    
    public class SingletonOne : ISingletonOne
    {
        private static int counter;
        
        public SingletonOne()
        {
            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        public void DoSomething()
        {
            Console.WriteLine("Hello");
        }
    }


    public class SingletonTwo : ISingletonTwo
    {
        private static int counter;

        public SingletonTwo()
        {
            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        public void DoSomething()
        {
            Console.WriteLine("Hello");
        }
    }
    
    public class SingletonThree : ISingletonThree
    {
        private static int counter;

        public SingletonThree()
        {
            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        public void DoSomething()
        {
            Console.WriteLine("Hello");
        }
    }
}
