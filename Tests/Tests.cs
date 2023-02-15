using OpenQA.Selenium;
using System.Threading;
using Xunit;


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
            AU.OnDriver().Navigate().GoToUrl("https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members");
            AU.OnDriver().Quit();
           
        }

    }
public class ModuleC
    {
        [Fact]
        public void Test3()
        {
            
            Utilities AU = new Utilities();
            AU.createDriver();
            AU.OnDriver().Navigate().GoToUrl("https://www.rainforestqa.com/how-rainforest-works");

            PageObjects.Rainforest rainforest = new PageObjects.Rainforest();
            AU.WaitFor().VisibilityOfElement(rainforest.introVideo, 10);
            AU.On(rainforest.pricing).AssertThat("innerText").Equals("Pricing");
            AU.On(rainforest.pricing).Click();
            AU.OnDriver().Quit();
                       
        }

    }