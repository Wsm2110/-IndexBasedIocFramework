using System;
using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Standard
{
    public interface ITransientOne
    {
        void DoSomething();
    }

    public interface ITransientTwo
    {
        void DoSomething();
    }

    public interface ITransientThree
    {
        void DoSomething();
    }
    
    public class TransientOne : ITransientOne
    {
        private static int counter;


        public TransientOne()
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
            Console.WriteLine("World");
        }
    }

    public class TransientTwo : ITransientTwo
    {
        private static int counter;

        
        public TransientTwo()
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
            Console.WriteLine("World");
        }
    }

    public class TransientThree : ITransientThree
    {
        private static int counter;

        public TransientThree()
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
            Console.WriteLine("World");
        }
    }
}
