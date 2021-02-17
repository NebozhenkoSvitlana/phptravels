using NUnit.Framework;
using System;

namespace AutoTest.Suite
{
    public class TestBase
    {
        protected AppManager AppManager;

        protected Navigator Navigator => AppManager.Navigator;
        protected PageManager Pages => AppManager.PageManager;

        [OneTimeSetUp]
        public virtual void OneTimeSetUp()
        {
            AppManager = new AppManager();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            AppManager.Dispose();
        }
    }
}
