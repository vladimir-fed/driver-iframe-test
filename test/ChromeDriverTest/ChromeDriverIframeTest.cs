using NUnit.Framework;
using OpenQA.Selenium;

namespace ChromeDriverTest
{
	[TestFixture]
	public class ChromeDriverIframeTest : DriverTestBase
	{
		[Test]
		public void ValueToReadShouldBe11AfterIframeReloaded()
		{
			Driver.Url = $"{BaseUrl}/frame";
			Driver.SwitchTo().Frame(0);
			var next = Driver.FindElement(by: By.Id("next"));
			next.Click();
			var el = Driver.FindElement(by: By.Id("valueToRead"));

			Assert.AreEqual(el.Text, "11");
		}

		[Test]
		public void ShouldSwitchToFrameWithoutIssues()
		{
			Driver.Url = $"{BaseUrl}/frame";
			var frameElement = Driver.FindElement(By.Id("inlineFrameExample"));
			var refreshButton = Driver.FindElement(By.Id("refreshFrame"));

			for (int i = 0; i < 1000; i++)
			{
				refreshButton.Click();
				for (int j = 0; j < 10; j++)
				{
					Driver.SwitchTo().Frame(frameElement);
					Driver.SwitchTo().DefaultContent();
				}
			}
		}
	}
}
