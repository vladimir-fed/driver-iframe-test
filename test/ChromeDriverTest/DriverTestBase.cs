using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace ChromeDriverTest
{
	public class DriverTestBase
	{
		public string BaseUrl => "https://driver-iframe-test.herokuapp.com";
		public ChromeDriver Driver { get; private set; }

		[TestInitialize]
		public void TestInit()
		{
			var service = ChromeDriverService.CreateDefaultService();
			service.LogPath = "chromedriver.log";
			service.EnableVerboseLogging = true;

			Driver = new ChromeDriver(service);
		}

		[TestCleanup]
		public void TestCleanUp()
		{
			Driver.Quit();
		}
	}
}
