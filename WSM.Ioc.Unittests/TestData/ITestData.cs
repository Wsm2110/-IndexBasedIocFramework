namespace simpleIOc.Unittests.TestData
{
    public interface ITestData
    {
    }

    public interface ITestDataTwo
    {
    }

    public interface ITestDataTree
    {
    }

    public interface ITestDataFour
    {
    }

    public interface ITestDataFive
    {
    }

    public interface ITestDataSix
    {
    }

    public class TestData : ITestData
    {
        public TestData()
        {
            
        }

    }

    public class TestDataTwo : ITestDataTwo
    {
        public TestDataTwo()
        {
            
        }
    }

    public class TestDataTree : ITestDataTree
    {

        public TestDataTree()
        {
            
        }

    }

    public class TestDataFour : ITestDataFour
    {

    }

    public class TestDataFive : ITestDataFive
    {

    }

    public class TestDataSix : ITestDataSix
    {

    }

    public class Combined
    {
        private readonly ITestData _testdata;
        private readonly ITestDataTwo _testDataTwo;
        private readonly ITestDataTree _testDataTree;

        public Combined(ITestData testdata, ITestDataTwo testDataTwo, ITestDataTree testDataTree)
        {
            _testdata = testdata;
            _testDataTwo = testDataTwo;
            _testDataTree = testDataTree;
        }

    }


}
