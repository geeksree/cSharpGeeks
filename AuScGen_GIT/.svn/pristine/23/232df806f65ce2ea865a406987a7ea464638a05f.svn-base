using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace WebDriver_Test
{  
  public class Class2
  {
    
    public static void Main(string[] args)
    {
        SearchTheWeb(new FirefoxDriver(), "http://www.google.com");
        SearchTheWeb(new InternetExplorerDriver(), "http://www.google.com");
      SearchTheWeb(new ChromeDriver(),"http://www.google.com");
      
        System.Console.Out.WriteLine("Press ENTER to exit");
      System.Console.In.ReadLine();
    }
      
    public static void SearchTheWeb(IWebDriver driver,string Url)
    {
      // And now use this to visit Google
      //driver.get("http://www.google.com");
        driver.Navigate().GoToUrl(Url);
      // Find the text input element by its name
      IWebElement element = driver.FindElement(By.Name("q"));

      // Enter something to search for
      element.SendKeys("Cheese!");

      // Now submit the form. WebDriver will find
      // the form for us from the element
      element.Submit();

      // Check the title of the page
      System.Console.Out.WriteLine(
        "Page title is: " + driver.Title);

      driver.Quit();
    }
  }
}

