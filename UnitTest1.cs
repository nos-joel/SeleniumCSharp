using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using Xunit;

namespace xUnitTest1
{
    public class UnitTest1
    {       

        [Fact]
        public void Test1()
        {
            Utilities AU = new Utilities();
            AU.createDriver();
            IWebDriver driver = AU.getDriver();

            driver.Navigate().GoToUrl("https://endi.com/");
            
            AU.On(By.Name("Clasificados")).AssertThat("innerText").Is("Clasificados");
            AU.On(By.Name("Clasificados")).Click();
            Thread.Sleep(1000);


 //           By.Name("Clasificados");
   //         IWebElement el = Utilities.findElement(driver, );
            //string text = el.Text;
            
            //el.Click();
            
            //Assert.True(text.Equals("Clasificados", System.StringComparison.Ordinal));
            driver.Quit();
        }
    }
    public class UnitTest2
    {
        [Fact]
        public void Test1()
        {
            //IWebDriver driver = new ChromeDriver();
            Utilities AU = new Utilities();
            AU.createDriver();
            IWebDriver driver = AU.getDriver();

            driver.Navigate().GoToUrl("https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members");

            //AU.On(By.Name("Clasificados")).AssertThat("text").Is("Clasificados");
            //AU.On(By.Name("Clasificados")).Click();

            driver.Quit();
            Assert.True(true);
        }

    }
    public class UnitTest3
    {
        [Fact]
        public void Test1()
        {
            //IWebDriver driver = new ChromeDriver();
            Utilities AU = new Utilities();
            AU.createDriver();
            IWebDriver driver = AU.getDriver();

            driver.Navigate().GoToUrl("https://www.rainforestqa.com/how-rainforest-works");

            AU.On(By.XPath("//a[text()='Pricing']")).AssertThat("innerText").Is("Pricing");
            //AU.On(By.XPath("//a[text()='Pricing']")).AssertThat("text").EstoEs("as");//.Is("Pricing");
            AU.On(By.XPath("//a[text()='Pricing']")).Click();

            driver.Quit();
            

            
        }

    }
}