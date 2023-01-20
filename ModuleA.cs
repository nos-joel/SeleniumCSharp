using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using Xunit;

//namespace xUnitTest1
//{

public class ModuleA
    {       
        [Fact]
        public void Test1()
        {
            Utilities AU = new Utilities();
            AU.createDriver();
            IWebDriver driver = AU.getDriver();

            driver.Navigate().GoToUrl("https://endi.com/");
          
            PageObjects.Endi endi = new PageObjects.Endi();

            AU.On(endi.search).Input("holas");
            AU.On(endi.clasificados).AssertThat("innerText").Equals("Clasificados");
            
            AU.On(endi.clasificados).Click();
        
            Thread.Sleep(1000);
            driver.Quit();
        }
    }

    public class ModuleB
    {
        [Fact]
        public void Test2()
        {
            
            Utilities AU = new Utilities();
            AU.createDriver();
            IWebDriver driver = AU.getDriver();
       
            driver.Navigate().GoToUrl("https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members");
            driver.Quit();
           
        }

    }
    public class ModuleC
    {
        [Fact]
        public void Test3()
        {
            
            Utilities AU = new Utilities();
            AU.createDriver();
            IWebDriver driver = AU.getDriver();

            driver.Navigate().GoToUrl("https://www.rainforestqa.com/how-rainforest-works");

            PageObjects.Rainforest rainforest = new PageObjects.Rainforest();
            AU.WaitFor().VisibilityOfElement(By.XPath("//video"), 10);
            AU.On(rainforest.pricing).AssertThat("innerText").Equals("Pricing");
            AU.On(rainforest.pricing).Click();
            driver.Quit();
                       
        }

    }
//}