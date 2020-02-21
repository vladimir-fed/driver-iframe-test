using System.IO;

using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace ChromeDriverTest
{
	public class DriverTestBase
	{
		public string BaseUrl => "https://driver-iframe-test.herokuapp.com";
		public ChromeDriver Driver { get; private set; }

		[SetUp]
		public void TestInit()
		{
			var service = ChromeDriverService.CreateDefaultService();
			service.LogPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "chromedriver.log");
			service.EnableVerboseLogging = true;

			Driver = new ChromeDriver(service);
		}

		[TearDown]
		public void TestCleanUp()
		{
			Driver.Quit();
		}
	}
}
