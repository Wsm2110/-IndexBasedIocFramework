using System;
using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Complex
{
    public interface IComplexOne
    {
    }

    public interface IComplexTwo
    {
    }

    public interface IComplexThree
    {
    }

 
    public class ComplexOne : IComplexOne
    {
        protected static int counter;

        
        
        
        public ComplexOne(
            IFirstService firstService,
            ISecondService secondService,
            IThirdService thirdService,
            ISubObjectOne subObjectOne,
            ISubObjectTwo subObjectTwo,
            ISubObjectThree subObjectThree)
        {
            if (firstService == null)
            {
                throw new ArgumentNullException(nameof(firstService));
            }

            if (secondService == null)
            {
                throw new ArgumentNullException(nameof(secondService));
            }

            if (thirdService == null)
            {
                throw new ArgumentNullException(nameof(thirdService));
            }

            if (subObjectOne == null)
            {
                throw new ArgumentNullException(nameof(subObjectOne));
            }

            if (subObjectTwo == null)
            {
                throw new ArgumentNullException(nameof(subObjectTwo));
            }

            if (subObjectThree == null)
            {
                throw new ArgumentNullException(nameof(subObjectThree));
            }

            System.Threading.Interlocked.Increment(ref counter);
        }

        protected ComplexOne()
        {
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }
    }


    public class ComplexTwo : IComplexTwo
    {
        protected static int counter;

        
        
        
        public ComplexTwo(
            IFirstService firstService,
            ISecondService secondService,
            IThirdService thirdService,
            ISubObjectOne subObjectOne,
            ISubObjectTwo subObjectTwo,
            ISubObjectThree subObjectThree)
        {
            if (firstService == null)
            {
                throw new ArgumentNullException(nameof(firstService));
            }

            if (secondService == null)
            {
                throw new ArgumentNullException(nameof(secondService));
            }

            if (thirdService == null)
            {
                throw new ArgumentNullException(nameof(thirdService));
            }

            if (subObjectOne == null)
            {
                throw new ArgumentNullException(nameof(subObjectOne));
            }

            if (subObjectTwo == null)
            {
                throw new ArgumentNullException(nameof(subObjectTwo));
            }

            if (subObjectThree == null)
            {
                throw new ArgumentNullException(nameof(subObjectThree));
            }

            System.Threading.Interlocked.Increment(ref counter);
        }

        protected ComplexTwo()
        {
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }
    }


    public class ComplexThree : IComplexThree
    {
        protected static int counter;

        
        
        
        public ComplexThree(
            IFirstService firstService,
            ISecondService secondService,
            IThirdService thirdService,
            ISubObjectOne subObjectOne,
            ISubObjectTwo subObjectTwo,
            ISubObjectThree subObjectThree)
        {
            if (firstService == null)
            {
                throw new ArgumentNullException(nameof(firstService));
            }

            if (secondService == null)
            {
                throw new ArgumentNullException(nameof(secondService));
            }

            if (thirdService == null)
            {
                throw new ArgumentNullException(nameof(thirdService));
            }

            if (subObjectOne == null)
            {
                throw new ArgumentNullException(nameof(subObjectOne));
            }

            if (subObjectTwo == null)
            {
                throw new ArgumentNullException(nameof(subObjectTwo));
            }

            if (subObjectThree == null)
            {
                throw new ArgumentNullException(nameof(subObjectThree));
            }

            System.Threading.Interlocked.Increment(ref counter);
        }

        protected ComplexThree()
        {
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }
    }
}
