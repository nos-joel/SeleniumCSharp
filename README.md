# SeleniumCSharp

A base xUnit and Selenium C# project for web testing. It was inspired by RestAssured.

## Installation
(Assuming you already have Visual Studio installed)

* Clone project (https://github.com/nos-joel/SeleniumCSharp.git)
* Once in Visual Studio: File > Open > Select project name

## Example

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

# Usage

**1.** Initialize the Utilities class. No arguments are needed during initialization.
```cs
Utilities u = new Utilities();
```

**2.** Create the driver. Note: the driver type is created based on a global property.
```cs
u.createDriver();
```

**3.** Two options are available when it comes to using the driver object.

a. You could retrieve the driver object by
```cs
IWebDriver driver = u.getDriver();
```
### or 
b. Use the OnDriver method 
```cs
u.OnDriver().findElementBy...
```

**4.** Use any of the available methods below.

## Available Methods

 **OnDriver**

This methods is basically a getter of the browser's driver. This allows a seamless integration with this framework's sintaxis.

```cs
OnDriver()
```

*Example*
```cs
u.OnDriver().Navigate().GoToUrl(url);
```
**On**

This method will be used for most of the actions performed on an object like *click*, *sendKeys* and *select*. This method requires an input, either a selector (*By*) or an object (*IWebElement*).

```cs
On()
```
*Example*

```cs
On(By.Id("id")).Click();
```
```cs
IWebElement element = u.OnDriver().findElement(By.Id("id"));
u.On(element).Click();
```

Available **On** Actions

*Click*
```cs
u.On(selector).Click();
```
*Input*
```cs
u.On(selector).Input("input text"); // SendKeys
```
*SelectByValue*
```cs
u.On(selector).SelectByValue(value);
```
*SelectByIndex*
```cs
u.On(selector).SelectByIndex(value);
```
*SelectByText*
```cs
u.On(selector).SelectByText(value);
```
*AssertThat*
```cs
u.On(selector).AssertThat(args);
```

**AssertThat**

This method is used when performing assertions over an object.

*Equals*

```cs
u.On(selector).AssertThat(attribute-name).Equals(expected-value);
```
*Contains*

```cs
u.On(selector).AssertThat(attribute-name).Contains(expected-value);
```


**Wait**

Wait for visibility of element.

```cs
u.WaitFor().VisibilityOfElement(By locator,  int wait-time);
```
*Example*

```cs
u.WaitFor().VisibilityOfElement(By.Id("id"), 5);
```
