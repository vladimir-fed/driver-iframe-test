using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromeDriverTest
{
	[TestClass]
	public class ChromeDriverExecutionContextTest
	{
		[TestMethod]
		public void ValueToReadShouldBe1AfterRefresh()
		{
			var service = ChromeDriverService.CreateDefaultService();
			service.LogPath = "chromedriver.log";
			service.EnableVerboseLogging = true;

			var driver = new ChromeDriver(service);

			try
			{
				//driver.Url = "https://driver-iframe-test.herokuapp.com";
				driver.Url = "http://localhost:9999/executioncontext";
				var refresh = driver.FindElement(by: By.Id("refresh"));
				refresh.Click();

				new WebDriverWait(driver, TimeSpan.FromSeconds(3)) { PollingInterval = TimeSpan.FromMilliseconds(10) }
					.Until(d => (bool)driver.ExecuteScript("return document.readyState === 'complete'") && (driver.FindElements(by: By.Id("valueToRead")).FirstOrDefault()?.Enabled ?? false));
				Assert.AreEqual(driver.FindElement(by: By.Id("valueToRead")).Text, "1");
			}
			finally
			{
				driver.Quit();
			}
		}
	}
}
