using OpenQA.Selenium;
public class PageObjects
{
    /// <summary>
    /// Endi Page objects
    /// </summary>
    public class Endi
    {
        public By clasificados = By.Name("Clasificados");
        public By search = By.Id("st");
    }
    /// <summary>
    /// Rainforest Page objects
    /// </summary>
    public class Rainforest
    {
        public By pricing = By.XPath("//a[text()='Pricing']");
        public By introVideo = By.XPath("//video");
    }
}
