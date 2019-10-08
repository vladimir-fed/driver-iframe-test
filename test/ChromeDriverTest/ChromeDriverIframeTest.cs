using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ChromeDriverTest
{
	[TestClass]
	public class ChromeDriverIframeTest
	{
		[TestMethod]
		public void ValueToReadShouldBe11AfterIframeReloaded()
		{
			var driver = new ChromeDriver();

			try
			{
				driver.Url = "https://driver-iframe-test.herokuapp.com";
				driver.SwitchTo().Frame(0);
				var next = driver.FindElement(by: By.Id("next"));
				next.Click();
				var el = driver.FindElement(by: By.Id("valueToRead"));

				Assert.AreEqual(el.Text, "11");
			} finally {
				driver.Quit();
			}
		}
	}
}
