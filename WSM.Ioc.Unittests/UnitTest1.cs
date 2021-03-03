using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using simpleIOc.Unittests.TestData;
using SimpleIoc.Contracts;
using Container = SimpleIoc.Container;

namespace simpleIOc.Unittests
{

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestConstructiorCreation()
        {
            var ci = typeof(Combined).GetConstructors().FirstOrDefault();
            var parameters = ci.GetParameters();

            var paramExp = new List<Expression>
            {
                Expression.Parameter(typeof(TestData.TestData)),
                Expression.Parameter(typeof(TestData.TestDataTwo)),
                Expression.Parameter(typeof(TestData.TestDataTree))
            };

            var x = Expression.New(ci, paramExp);
            var creator = (Func<object>)Expression.Lambda(x).Compile();


            Expression<Func<object>> a = () => creator;
        }

        [TestMethod]
        public void AssertBenchMarkResolveSingletonMultithreaded()
        {
            var watch = new Stopwatch();

            //This testcase is an indicator if resolving is getting slower -> resolving this obj
            var container = new Container();
            container.Register(typeof(ITestData), typeof(TestData.TestData), Lifetime.Singleton, Index.GetTestData);
            container.Register(typeof(ITestDataTwo), typeof(TestDataTwo), Lifetime.Singleton, Index.GetTestDataTwo);
            container.Register(typeof(ITestDataTree), typeof(TestDataTree), Lifetime.Singleton, Index.GetTestDataTree);

            container.Build();

            var loopcount = 500000 / 2;
            Exception exception = null;

            var thread1 = new Thread(() =>
            {
                try
                {
                    for (var j = 0; j < loopcount; j++)
                    {
                        var a = (TestData.TestData)container.Resolve(Index.GetTestData);
                        var b = (TestDataTwo)container.Resolve(Index.GetTestDataTwo);
                        var c = (TestDataTree)container.Resolve(Index.GetTestDataTree);

                        if (exception != null)
                        {
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {


                    exception = ex;
                }
            });


            var thread2 = new Thread(() =>
            {
                try
                {
                    for (var j = 0; j < loopcount; j++)
                    {
                        var c = (TestDataTree)container.Resolve(Index.GetTestDataTree);
                        var a = (TestData.TestData)container.Resolve(Index.GetTestData);
                        var b = (TestDataTwo)container.Resolve(Index.GetTestDataTwo);

                        if (exception != null)
                        {
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {


                    exception = ex;
                }
            });

            var x = new List<Thread>
            {
                thread1, thread2
            };

            watch.Start();

            foreach (var thread in x)
            {
                thread.Start();
            }

            foreach (var thread in x)
            {
                thread.Join();
            }

            watch.Stop();

            var time = watch.ElapsedMilliseconds;
        }

        [TestMethod]
        public void AssertBenchMarkResolveSingletonByGeneric()
        {
            //This testcase is an indicator if resolving is getting slower -> resolving this obj
            var container = new Container();
            container.Register(typeof(ITestData), typeof(TestData.TestData), Lifetime.Singleton, Index.GetTestData);
            container.Register(typeof(ITestDataTwo), typeof(TestDataTwo), Lifetime.Singleton, Index.GetTestDataTwo);
            container.Register(typeof(ITestDataTree), typeof(TestDataTree), Lifetime.Singleton, Index.GetTestDataTree);

            if (File.Exists(@"D:\Elias\Logging\LogFile\BenchmarkContainer.txt"))
            {
                File.Delete(@"D:\Elias\Logging\LogFile\BenchmarkContainer.txt");
            }

            for (int ii = 0; ii < 100; ii++)
            {

                var time = Time(() =>
                {
                    for (var i = 0; i < 500000; i++)
                    {
                        var a = container.Resolve<ITestData>(Index.GetTestData);
                        var b = container.Resolve<ITestDataTwo>(Index.GetTestDataTwo);
                        var c = container.Resolve<ITestDataTree>(Index.GetTestDataTree);
                    }
                });

                using (var file = File.AppendText(@"D:\BenchmarkContainer.txt"))
                {
                    file.WriteLine($"{ time.Milliseconds}");
                }
                //time -> resolving 500k singleton objects in 23ms(best) in release mode
                //https://danielpalme.github.io/IocPerformance/

            }
        }

        [TestMethod]
        public void AssertCombinedTypes()
        {
            var container = new Container();

            container.Register(typeof(ITestData), typeof(TestData.TestData), Lifetime.Singleton, Index.GetTestData);
            container.Register(typeof(ITestDataTwo), typeof(TestDataTwo), Lifetime.Singleton, Index.GetTestDataTwo);
            container.Register(typeof(ITestDataTree), typeof(TestDataTree), Lifetime.Singleton, Index.GetTestDataTree);

            container.Register<Combined>(Lifetime.Singleton, Index.GetCombined);
            container.Build();


            var testdata = container.Resolve(Index.GetTestData);


            var combined = container.Resolve(Index.GetCombined);

            Assert.IsTrue(combined != null);

            var combined2 = container.Resolve(Index.GetCombined);
            Assert.IsTrue(combined2 != null);
        }

        [TestMethod]
        public void AssertBenchMarkResolveSingletonByObject()
        {
            //This testcase is an indicator if resolving is getting slower -> resolving this obj
            var container = new Container();
            container.Register(typeof(ITestData), typeof(TestData.TestData), Lifetime.Singleton, Index.GetTestData);
            container.Register(typeof(ITestDataTwo), typeof(TestDataTwo), Lifetime.Singleton, Index.GetTestDataTwo);
            container.Register(typeof(ITestDataTree), typeof(TestDataTree), Lifetime.Singleton, Index.GetTestDataTree);

            if (File.Exists(@"D:\Elias\Logging\LogFile\BenchmarkContainer.txt"))
            {
                File.Delete(@"D:\Elias\Logging\LogFile\BenchmarkContainer.txt");
            }

            for (int ii = 0; ii < 100; ii++)
            {
                var time = Time(() =>
                {
                    for (var i = 0; i < 500000; i++)
                    {
                        var a = container.Resolve(Index.GetTestData);
                        var b = container.Resolve(Index.GetTestDataTwo);
                        var c = container.Resolve(Index.GetTestDataTree);
                    }
                });

                using (var file = File.AppendText(@"D:\BenchmarkContainer.txt"))
                {
                    file.WriteLine($"{ time.Milliseconds}");
                }
                //time -> resolving 500k singleton objects in 23ms(best) in release mode
                //https://danielpalme.github.io/IocPerformance/
            }
        }

        private static TimeSpan Time(Action toTime)
        {
            var timer = Stopwatch.StartNew();
            toTime();
            timer.Stop();
            return timer.Elapsed;
        }

    }
}
