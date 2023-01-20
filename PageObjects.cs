using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PageObjects
{
    public class Endi
    {
        public By clasificados = By.Name("Clasificados");
        public By search = By.Id("st");
    }

    public class Rainforest
    {
        public By pricing = By.XPath("//a[text()='Pricing']");
    }
}
