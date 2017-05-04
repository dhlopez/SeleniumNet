using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//References for selenium
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace mySelenium
{
    class Program
    {
        static void Main(string[] args)
        {
            //!Make sure to add the path to where you extracting the chromedriver.exe:
            //IWebDriver driver = new ChromeDriver(@"C:\Users\dhlopez\Downloads\chromedriver_win32"); //<-Add your path
            //driver.Navigate().GoToUrl("http://www.Epicor.com");
             IWebDriver driver = new ChromeDriver(@"C:\Users\dhlopez\Downloads\chromedriver_win32"); //<-Add your path
             driver.Navigate().GoToUrl("https://ielts.britishcouncil.org/CheckResults.aspx");

            int i=1360;
            string intString = i.ToString().PadLeft(6, '0');
            do
            {
                IWebElement ife = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtIdDocumentNumber"));
                ife.Clear();
                IWebElement candidate = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtCandidateNumber"));
                candidate.Clear();
                //
                IWebElement test = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucTestDate_ddlTestDate"));
                test.SendKeys("13 January 2015");
                IWebElement day = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucDob1_ddlDays"));
                day.SendKeys("17");
                IWebElement month = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucDob1_ddlMonths"));
                month.SendKeys("January");
                IWebElement year = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucDob1_ddlYears"));
                //
                year.SendKeys("1991");
                ife.SendKeys("1206117968042");
                candidate.SendKeys(intString);

                IWebElement button = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_imgbSearch"));
                button.Click();
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));//Wait if page is not loaded?
                i++;
                intString = i.ToString().PadLeft(6, '0'); //change integer format to any value and '0' to the left
                //Is =
            } while (i <= 1360);
            //driver.Close(); //Close chrome
            //driver.Dispose(); //Close driver, cmd
        }
    }
}
