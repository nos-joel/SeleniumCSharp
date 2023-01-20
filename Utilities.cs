using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

//namespace xUnitTest1
//{
    public static class StepProps {
        public static IWebElement element;// = null;
        public static IWebDriver driver;
        public static string action = "";
        public static string attribute_name = "";
        public static string expected_value = "";
        public static string current_value = "";
    }

    public class Utilities
    {
        //private IWebElement p_element = null;
        //string p_action = "";
        //private string p_attribute_name = "";
        //private string p_expected_value = "";
        //private string p_current_value = "";
        public IWebDriver driver = null;
        
        AssertOptions assertoptions = new AssertOptions();
        OnActions onactions = new OnActions();
        ForActions foractions = new ForActions();

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

            StepProps.driver = driver;    
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
        
        public ForActions WaitFor()
        {
            return foractions;
        }
       
        /// <summary>
        /// Function to pass on the element object of the desired element to interact with
        /// </summary>
        /// <param name="IWebElement element"></param>
        public OnActions On(IWebElement element)
        {
            
            StepProps.element = element;

            return onactions;
        }

        /// <summary>
        /// Function to pass on the selector of the desired object to interact with
        /// </summary>
        /// <param name="By selector"></param>
        public OnActions On(By selector) //IWebDriver driver, 
        {
            try
            {
                IWebElement element = driver.FindElement(selector);
                StepProps.element = element;
            }
            catch (NoSuchElementException ex) { 
                StepProps.element = null;
            }

            return onactions;
        }

        public IWebDriver On(IWebDriver driver)
        {
            return driver;
        }
       
    } /* Utilities END */

    public class ForActions
    {
        public void VisibilityOfElement(By selector, double max_wait_time)
        {
         
            IWebElement el = new WebDriverWait(StepProps.driver, TimeSpan.FromSeconds(max_wait_time))
            .Until(d=>d.FindElement(selector));
        }
    }

    /// <summary>
    /// The AssertOptions class is used to define the available options when performing an Assert over an object
    /// </summary>
    public class AssertOptions
    {

        /// <summary>
        /// Assert option to validate whether an object's property exactly matches the expected_value
        /// </summary>
        public void Equals(string expected_value)
        {
            // Include private variable for Assert Contidtion (like Is,Contains). This would help
            // include more validations in  case user leave something incomplete(AssertThat();) leaving the statement incomplete
                       
            Assert.Equal(expected_value, StepProps.current_value);
        }

        /// <summary>
        /// Assert option to validate whether an object's property partially matches the expected_value
        /// </summary>
        public void Contains(string expected_value)
        {
            Assert.Contains(expected_value, StepProps.current_value);
        }
    }

        /// <summary>
        /// Defined list of available actions to perform over an element
        /// </summary>
    public class OnActions
    {
        AssertOptions assertoptions = new AssertOptions();

        /// <summary>
        /// Perform a Click over an object
        /// </summary>
        public void Click()
        {
            StepProps.action = "click";
            StepProps.element.Click();

        }

        public void Input(string input_string)
        {
            StepProps.action = "input";
            StepProps.element.Clear();
            StepProps.element.SendKeys(input_string);
        }

        /// <summary>
        /// Define that an Assert with be performed on a object
        /// </summary>
        /// <param name="object attribute_name"></param>
        /// <returns></returns>
        public AssertOptions AssertThat(string attribute_name)
        {
        
            StepProps.action = "assert";
            StepProps.attribute_name = attribute_name;

            StepProps.current_value = StepProps.element.GetAttribute(attribute_name);

            return assertoptions;
        }

        public void SelectByValue(string value)
        {

            SelectElement select = new SelectElement(StepProps.element);
            select.SelectByValue(value);
        }
        
        public void SelectByIndex(int value)
        {
            SelectElement select = new SelectElement(StepProps.element);
            select.SelectByIndex(value);
        }

        public void SelectByText(string value)
        {
            SelectElement select = new SelectElement(StepProps.element);
            select.SelectByText(value);
        }
}

//}
