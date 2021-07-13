using Gerenciador.Processos.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Gerenciador.Processos.Tests
{
    [TestClass]
    public class TestCases
    {
        private readonly ITestCasesService _testCasesService;

        public TestCases(ITestCasesService testCasesService)
        {
            _testCasesService = testCasesService;
        }

        [TestMethod]
        public async Task Test1()
        {
            var result = await _testCasesService.ExecuteTest1Async(default);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Test2()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Test3()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Test4()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Test5()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Test6()
        {
            Assert.IsTrue(true);
        }
    }
}