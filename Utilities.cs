using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;


   
/// <summary>
/// This class holds most actions as creation of the driver, driver getter, and common selenium actions to
/// perform on an object.
/// </summary>
public class Utilities
{

    public IWebDriver driver = null;
        
    OnActions onactions = new OnActions();
    WaitForActions waitforactions = new WaitForActions();

    /// <summary>
    /// Method to create the desired browser driver. The driver is configured on the Configurations class
    /// </summary>
    public void createDriver()
    {
        switch (Configurations.driver_name)
        {
            case "CHROME":
                driver = new ChromeDriver();
                break;

            case "FIREFOX":
                driver = new FirefoxDriver();               
                break;

            case "EDGE":
                EdgeOptions options = new EdgeOptions();
                    options.AddArgument("start-maximized");
                    options.AddArgument("--disable-features=msHubApps");

                driver = new EdgeDriver(options);
                break;

            default:
                driver = new ChromeDriver();
                break;    
        }

        waitforactions.Driver = driver;   
        driver.Manage().Window.Minimize();
    }

    /// <summary>
    /// getDriver fuctions returns the driver object of the configured Browser 
    /// </summary>
    /// <returns>driver</returns>
    public IWebDriver getDriver()
    {
        return driver;
    }
        
    /// <summary>
    /// WaitFor method that returns available chained actions 
    /// </summary>
    /// <returns>WaitForActions class</returns>
    public WaitForActions WaitFor()
    {
        return waitforactions;
    }
       
    /// <summary>
    /// Function to pass on the element object of the desired element to interact with
    /// </summary>
    /// <param name="IWebElement element"></param>
    /// <returns>OnActions class</returns>
    public OnActions On(IWebElement element)
    {
        onactions.element = element;
        return onactions;
    }

    /// <summary>
    /// Function to pass on the selector of the desired object to interact with
    /// </summary>
    /// <param name="By selector"></param>
    /// <returns>OnActions class</returns>
    public OnActions On(By selector) 
    {
        try
        {
            IWebElement element = driver.FindElement(selector);
            onactions.element = element;
        }
        catch (NoSuchElementException ex) { 
            //Needs completion
        }
        
        return onactions;
    }

    /// <summary>
    /// OnDriver method returns the driver's object.
    /// </summary>
    /// <returns>IWebDriver driver</returns>
    public IWebDriver OnDriver()
    {
        return driver;
    }

       
} /* Utilities END */

/// <summary>
/// WaitForActions class
/// </summary>
public class WaitForActions
{
    private IWebDriver driver;

    public IWebDriver Driver
    { 
        get { return driver; }
        set { driver = value; }
    }
        
    /// <summary>
    /// Method to wait for visiblity of element
    /// </summary>
    /// <param name="By selector"></param>
    /// <param name="max_wait_time"></param>
    public void VisibilityOfElement(By selector, double max_wait_time)
    {
        WebDriverWait wdw = new WebDriverWait(driver, TimeSpan.FromSeconds(max_wait_time));
        wdw.Until(d=>d.FindElement(selector));
    }
 }

/// <summary>
/// The AssertOptions class is used to define the available options when performing an Assert over an object
/// </summary>
public class AssertOptions
{
    public string current_value;

    /// <summary>
    /// Assert option to validate whether an object's property exactly matches the expected_value
    /// </summary>
    public void Equals(string expected_value)
    {
        // Include private variable for Assert Contidtion (like Is,Contains). This would help
        // include more validations in  case user leave something incomplete(AssertThat();) leaving the statement incomplete

        Assert.Equal(expected_value, current_value);
    }

    /// <summary>
    /// Assert option to validate whether an object's property partially matches the expected_value
    /// </summary>
    public void Contains(string expected_value)
    {
        Assert.Contains(current_value, expected_value);
    }
}

/// <summary>
/// OnActions class. It contains the defined list of available actions to perform over an element
/// </summary>
public class OnActions
{
    public IWebElement element;
    AssertOptions assertoptions = new AssertOptions();

    /// <summary>
    /// Perform a Click over an object
    /// </summary>
    public void Click()
    {
        element.Click();
    }

    /// <summary>
    /// Perform SendKeys
    /// </summary>
    /// <param name="input_string"></param>
    public void Input(string input_string)
    {
        element.Clear(); //Clear input first
        element.SendKeys(input_string);
    }

    /// <summary>
    /// Define that an Assert with be performed on a object
    /// </summary>
    /// <param name="object's attribute_name"></param>
    /// <returns>AssertOptions</returns>
    public AssertOptions AssertThat(string attribute_name)
    {
        
        string current_value = element.GetAttribute(attribute_name);
            
        assertoptions.current_value = current_value;
            
        return assertoptions;
    }

    /// <summary>
    /// Select dropdown by value
    /// </summary>
    /// <param name="value"></param>
    public void SelectByValue(string value)
    {
        SelectElement select = new SelectElement(element);
        select.SelectByValue(value);
    }

    /// <summary>
    /// Select dropdown by index
    /// </summary>
    /// <param name="value"></param>
    public void SelectByIndex(int value)
    {
        SelectElement select = new SelectElement(element);
        select.SelectByIndex(value);
    }

    /// <summary>
    /// Select dropdown by text
    /// </summary>
    /// <param name="value"></param>
    public void SelectByText(string value)
    {
        SelectElement select = new SelectElement(element);
        select.SelectByText(value);
    }
}