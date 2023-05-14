namespace VtigerWebApplicationMSTestUnit
{
    [TestClass]
    public class UnitTest1

    {
        public TestContext testContext;

         public TestContext Test
        {
            get {return testContext; }
            set { testContext = value; }
        }


        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine(testContext.Properties["DEMOQA"].ToString());
        }
    }
}