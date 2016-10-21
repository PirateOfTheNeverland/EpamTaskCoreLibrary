using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace EpamTaskCoreLibrary
{
    public static class ActionProvider
    {
        private static IWebDriver driver;
        private static string baseURL = "https://mail.ru/";

        static ActionProvider()
        {
        }

        #region Actions
        /// <summary>
        /// Starts the driver
        /// </summary>
        public static void Start()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("-incognito");
            driver = new ChromeDriver(options);
        }

        /// <summary>
        /// Stops the driver
        /// </summary>
        public static void Stop()
        {
            driver.Close();
            driver.Dispose();
            driver.Quit();
        }

        /// <summary>
        /// Navigates to base Url
        /// </summary>
        public static void NavigateToBase()
        {
            try
            {
                driver.Navigate().GoToUrl(baseURL);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Navigates to Url
        /// </summary>
        /// <param name="url">Url</param>
        public static void NavigateToUrl(string url)
        {
            try
            {
                driver.Navigate().GoToUrl(url);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Navigates to Url
        /// </summary>
        /// <param name="url">Url</param>
        /// <param name="delay">Time in ms to wait after clicking</param>
        public static void NavigateToUrlAndWait(string url, int delay)
        {
            try
            {
                driver.Navigate().GoToUrl(url);
                System.Threading.Thread.Sleep(delay);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Clicks at an element by Id and waits after click
        /// </summary>
        /// <param name="id">Id of element to click at</param>
        /// <param name="delay">Time in ms to wait after clicking</param>
        public static void ClickAndWaitId(string id, int delay)
        {
            try
            {
                driver.FindElement(By.Id(id)).Click();
                System.Threading.Thread.Sleep(delay);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Clicks at an element by Xpath locator and waits after click
        /// </summary>
        /// <param name="xpath">Xpath locator of element to click at</param>
        /// <param name="delay">Time in ms to wait after clicking</param>
        public static void ClickAndWaitXpath(string xpath, int delay)
        {
            try
            {
                driver.FindElement(By.XPath(xpath)).Click();
                System.Threading.Thread.Sleep(delay);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Clicks at an element by Id locator
        /// </summary>
        /// <param name="id">Id locator of element to click at</param>
        public static void ClickId(string id)
        {
            try
            {
                driver.FindElement(By.Id(id)).Click();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Clicks at an element by Xpath locator
        /// </summary>
        /// <param name="xpath">Xpath locator of element to click at</param>
        public static void ClickXpath(string xpath)
        {
            try
            {
                driver.FindElement(By.XPath(xpath)).Click();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Emulates typing into element
        /// </summary>
        /// <param name="id">Id locator of element</param>
        /// <param name="clearInput">If true field will be cleared before sending keys</param>
        /// <param name="text">Text to type</param>
        public static void SendKeysId(string id, bool clearInput, string text)
        {
            try
            {
                IWebElement field = driver.FindElement(By.Id(id));
                if (clearInput) field.Clear();
                field.SendKeys(text);
                System.Threading.Thread.Sleep(500);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Emulates typing into element
        /// </summary>
        /// <param name="xpath">Xpath locator of element</param>
        /// <param name="clearInput">If true field will be cleared before sending keys</param>
        /// <param name="text">Text to type</param>
        public static void SendKeysXpath(string xpath, bool clearInput, string text)
        {
            try
            {
                IWebElement field = driver.FindElement(By.XPath(xpath));
                if (clearInput) field.Clear();
                field.SendKeys(text);
                System.Threading.Thread.Sleep(500);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Checks visibility of element
        /// </summary>
        /// <param name="id">Id locator of element</param>
        /// <returns>True if element is visible, otherwise false.</returns>
        public static bool IsVisibleId(string id)
        {
            try
            {
                IWebElement element = driver.FindElement(By.Id(id));
                if (element.Displayed) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Checks visibility of element
        /// </summary>
        /// <param name="xpath">Xpath locator of element</param>
        /// <returns>True if element is visible, otherwise false.</returns>
        public static bool IsVisibleXpath(string xpath)
        {
            try
            {
                IWebElement element = driver.FindElement(By.XPath(xpath));
                if (element.Displayed) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves text from element
        /// </summary>
        /// <param name="id">Id locator of element</param>
        /// <returns>Text of the element</returns>
        public static string GetTextId(string id)
        {
            try
            {
                IWebElement element = driver.FindElement(By.Id(id));
                return element.Text;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves text from element
        /// </summary>
        /// <param name="xpath">Xpath locator of element</param>
        /// <returns>Text of the element</returns>
        public static string GetTextXpath(string xpath)
        {
            try
            {
                IWebElement element = driver.FindElement(By.XPath(xpath));
                return element.Text;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets value of attributed for element by it's id
        /// </summary>
        /// <param name="id">Id locator of element</param>
        /// <param name="attrname">Attribute name</param>
        /// <returns>Value of attribute</returns>
        public static string GetAttributeId(string id, string attrname)
        {
            try
            {
                IWebElement element = driver.FindElement(By.Id(id));
                return element.GetAttribute(attrname);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets value of attributed for element by it's Xpath
        /// </summary>
        /// <param name="xpath">Xpath locator of element</param>
        /// <param name="attrname">Attribute name</param>
        /// <returns>Value of attribute</returns>
        public static string GetAttributeXpath(string xpath, string attrname)
        {
            try
            {
                IWebElement element = driver.FindElement(By.XPath(xpath));
                return element.GetAttribute(attrname);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Returns Url of currently displaying page
        /// </summary>
        /// <returns>Url of currently displaying page</returns>
        public static string WhereAmI()
        {
            try
            {
                return driver.Url;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Counts elements satisfying given xpath
        /// </summary>
        /// <param name="xpath">Xpath template for search</param>
        /// <returns>Number of elements found by given xpath</returns>
        public static int CountElementsXpath(string xpath)
        {
            try
            {
                return driver.FindElements(By.XPath(xpath)).Count;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static IWebElement ReturnElementFromCollectionXpath(string xpath, int index)
        {
            try
            {
                return driver.FindElements(By.XPath(xpath)).ElementAt(index);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

    }

}
