# SeleniumCSharp

A base xUnit and Selenium C# project for web testing. It was inspired by RestAssured.

## Installation
(Assuming you already have Visual Studio installed)

* Clone project (https://github.com/nos-joel/SeleniumCSharp.git)
* Once in Visual Studio: File > Open > Select project name

## Usage

As a start, you may head to the file
```cs
Tests.cs
```

```cs
public class ModuleA
    {       
        [Fact]
        public void Test1()
        {
            Utilities AU = new Utilities();         // Instantiate the Utilities class. You may choose another name instead of AU
            AU.createDriver();                      // Create the driver
            IWebDriver driver = AU.getDriver();     // driver getter

            driver.Navigate().GoToUrl("https://YourURL.com");
          
            PageObjects.YourPageName ypn = new PageObjects.YourPageName(); // Instantiate the Page class of your need

            AU.On(ypn.InputSearch).Input("Hello");
            AU.On(ypn.SearchButton).Click();
            AU.On(ypn.SearchResultsLabel).AssertThat("innerText").Equals("No results were found!");

            driver.Quit();
        }
    }
```
