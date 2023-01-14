using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace xUnitTest1
{
    public class Utilities
    {
        private IWebElement p_element = null;
        string p_action = "";
        private string p_attribute_name = "";
        private string p_expected_value = "";
        private string p_current_value = "";
        public IWebDriver driver = null;
        AssertOptions assertoptions = new AssertOptions();
        OnActions onactions = new OnActions();

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
            }

        }

        public IWebDriver getDriver()
        {
            return driver;
        }

        public Utilities On(IWebElement element)
        {
            p_element = element;

            return this;
        }
        public Utilities On(By selector) //IWebDriver driver, 
        {
            try
            {
                p_element = driver.FindElement(selector);
            }
            catch (NoSuchElementException ex) { }

            return this;
        }

        public void Click()
        {
            p_action = "click";
            p_element.Click();
        }

        public AssertOptions AssertThat(string attribute_name)
        {
            p_action = "assert";
            //p_attribute_name = attribute_name;

            //string attribute = attribute_name;

            //if (attribute_name.ToLower().Equals("text"))
            //{
            //    attribute = "innerText";
            //}


            p_current_value = p_element.GetAttribute(attribute_name);

            assertoptions.current_value = p_current_value;

            return assertoptions;// new AssertOptions();
        }
        ///// Method to validate whether object's property value matches the expected value.
        ///// </summary>
        ///// <param name="expected"></param>
        //public void Iss(string expected)
        //{
        //    // Include private variable for Assert Contidtion (like Is,Contains). This would help
        //    // include more validations in  case user leave something incomplete(AssertThat();) leaving the statement incomplete
        //    p_expected_value = expected;

        //    AssertOptions ao = new AssertOptions();
        //    ao.expected_value = expected;

        //    if (p_action == "assert")
        //    {
        //        Assert.Equal(p_expected_value, p_current_value);
        //    }
        //}
        //    public void Contains(string expected)
        //    {
        //        // Include private variable for Assert Contidtion (like Is,Contains). This would help
        //        // include more validations in  case user leave something incomplete(AssertThat();) leaving the statement incomplete
        //        p_expected_value = expected;

        //        if (p_action == "assert")
        //        {
        //            Assert.Equal(p_expected_value, p_current_value);
        //        }
        //    }
        //}
    }
    public class AssertOptions
    {
        public string expected_value = "";
        public string current_value = "";
        //public AssertOptions(string p_expected_value, string p_current_value)
        //{
        //    expected_value = p_expected_value;
        //    current_value = p_current_value;
        //}

        public void Is(string _expected_value)
        {
            // Include private variable for Assert Contidtion (like Is,Contains). This would help
            // include more validations in  case user leave something incomplete(AssertThat();) leaving the statement incomplete
            expected_value = _expected_value;

            //if (p_action == "assert")
            // {
            Assert.Equal(expected_value, current_value);
            //}
        }
    }
    public class OnActions
    {
        public void Click()
        {

        }
    }
    
}
