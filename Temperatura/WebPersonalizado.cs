using EasyAutomationFramework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Data;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;


namespace Temperatura
{
    public class WebPersonalizado
    {
        public IWebDriver driver;

        public EasyReturn.Web StartBrowser(TypeDriver typeDriver = TypeDriver.GoogleChorme, string pathCache = null)
        {
            try
            {
                switch (typeDriver)
                {
                    case TypeDriver.GoogleChorme:
                        {
                            ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
                            chromeDriverService.HideCommandPromptWindow = true;
                            ChromeOptions chromeOptions = new ChromeOptions();
                            if (string.IsNullOrEmpty(pathCache))
                            {
                                chromeOptions.AddArgument("--incognito");
                            }
                            else
                            {
                                chromeOptions.AddArgument("user-data-dir=" + pathCache);
                            }

                            chromeOptions.AddExcludedArgument("enable-automation");
                            chromeOptions.AddAdditionalCapability("useAutomationExtension", false);
                            chromeOptions.AddArgument("--start-maximized");
                            driver = new ChromeDriver(chromeDriverService, chromeOptions);
                            break;
                        }
                    case TypeDriver.PhantomJS:
                        {
                            PhantomJSDriverService phantomJSDriverService = PhantomJSDriverService.CreateDefaultService();
                            phantomJSDriverService.HideCommandPromptWindow = true;
                            phantomJSDriverService.AddArgument("--ignore-ssl-errors=true");
                            phantomJSDriverService.AddArgument("--script-language='javascript'");
                            PhantomJSOptions options2 = new PhantomJSOptions();
                            driver = new PhantomJSDriver(phantomJSDriverService, options2);
                            break;
                        }
                    case TypeDriver.InternetExplorer:
                        {
                            InternetExplorerDriverService internetExplorerDriverService = InternetExplorerDriverService.CreateDefaultService();
                            internetExplorerDriverService.HideCommandPromptWindow = true;
                            InternetExplorerOptions options = new InternetExplorerOptions();
                            driver = new InternetExplorerDriver(internetExplorerDriverService, options);
                            break;
                        }
                    case TypeDriver.FireFox:
                        {
                            FirefoxDriverService firefoxDriverService = FirefoxDriverService.CreateDefaultService();
                            firefoxDriverService.HideCommandPromptWindow = true;
                            driver = new FirefoxDriver(firefoxDriverService);
                            break;
                        }
                }

                return new EasyReturn.Web
                {
                    driver = driver,
                    Sucesso = true
                };
            }
            catch (Exception ex)
            {
                return new EasyReturn.Web
                {
                    driver = driver,
                    Sucesso = false,
                    Error = ex.Message.ToString()
                };
            }
        }

        public void CloseBrowser()
        {
            if (driver == null)
            {
                return;
            }

            try
            {
                driver.Close();
                driver.Quit();
                driver.Dispose();
            }
            catch
            {
            }
        }

        public EasyReturn.Web Navigate(string url)
        {
            try
            {
                driver.Navigate().GoToUrl(url);
                return new EasyReturn.Web
                {
                    driver = driver,
                    Sucesso = true
                };
            }
            catch (Exception ex)
            {
                return new EasyReturn.Web
                {
                    driver = driver,
                    Sucesso = false,
                    Error = "More info: " + ex.Message
                };
            }
        }

        public EasyReturn.Web Click(TypeElement typeElement, string element, int timeout = 3)
        {
            try
            {
                WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                IWebElement webElement = null;
                switch (typeElement)
                {
                    case TypeElement.Id:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.Id(element)));
                        break;
                    case TypeElement.Name:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.Name(element)));
                        break;
                    case TypeElement.Xpath:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(element)));
                        break;
                    case TypeElement.CssSelector:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.CssSelector(element)));
                        break;
                }

                webElement.Click();
                return new EasyReturn.Web
                {
                    driver = driver,
                    element = webElement,
                    Sucesso = true
                };
            }
            catch (Exception ex)
            {
                return new EasyReturn.Web
                {
                    driver = driver,
                    Sucesso = false,
                    Error = "Element " + element + " not found. More info: " + ex.Message
                };
            }
        }

        public EasyReturn.Web GetValue(TypeElement typeElement, string element, int timeout = 3)
        {
            try
            {
                WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                IWebElement webElement = null;
                switch (typeElement)
                {
                    case TypeElement.Id:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.Id(element)));
                        break;
                    case TypeElement.Name:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.Name(element)));
                        break;
                    case TypeElement.Xpath:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(element)));
                        break;
                    case TypeElement.CssSelector:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.CssSelector(element)));
                        break;
                }

                return new EasyReturn.Web
                {
                    driver = driver,
                    element = webElement,
                    Value = webElement.Text,
                    Sucesso = true
                };
            }
            catch (Exception ex)
            {
                return new EasyReturn.Web
                {
                    driver = driver,
                    Sucesso = false,
                    Error = "Element " + element + " not found. More info: " + ex.Message
                };
            }
        }

        public EasyReturn.Web AssignValue(TypeElement typeElement, string element, string value, int timeout = 3)
        {
            try
            {
                WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                IWebElement webElement = null;
                switch (typeElement)
                {
                    case TypeElement.Id:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.Id(element)));
                        break;
                    case TypeElement.Name:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.Name(element)));
                        break;
                    case TypeElement.Xpath:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(element)));
                        break;
                    case TypeElement.CssSelector:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.CssSelector(element)));
                        break;
                }

                webElement.SendKeys(value);
                return new EasyReturn.Web
                {
                    driver = driver,
                    element = webElement,
                    Sucesso = true
                };
            }
            catch (Exception ex)
            {
                return new EasyReturn.Web
                {
                    driver = driver,
                    Sucesso = false,
                    Error = "Element " + element + " not found. More info: " + ex.Message
                };
            }
        }

        public EasyReturn.Web GetTableData(TypeElement typeElement, string element, int timeout = 3)
        {
            try
            {
                WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                IWebElement webElement = null;
                switch (typeElement)
                {
                    case TypeElement.Id:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.Id(element)));
                        break;
                    case TypeElement.Name:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.Name(element)));
                        break;
                    case TypeElement.Xpath:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(element)));
                        break;
                    case TypeElement.CssSelector:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.CssSelector(element)));
                        break;
                }

                IList<IWebElement> list = webElement.FindElements(By.TagName("tr"));
                DataTable dataTable = new DataTable();
                int num = 0;
                foreach (IWebElement item in list)
                {
                    if (num == 0)
                    {
                        try
                        {
                            IList<IWebElement> list2 = item.FindElements(By.TagName("th"));
                            for (int i = 0; i < list2.Count; i++)
                            {
                                dataTable.Columns.Add(list2[i].Text);
                            }
                        }
                        catch
                        {
                        }
                    }

                    IList<IWebElement> list3 = item.FindElements(By.TagName("td"));
                    if (list3.Count > 0)
                    {
                        List<string> list4 = new List<string>();
                        for (int j = 0; j < list3.Count; j++)
                        {
                            list4.Add(list3[j].Text);
                        }

                        DataRowCollection rows = dataTable.Rows;
                        object[] values = list4.ToArray();
                        rows.Add(values);
                    }

                    num++;
                }

                return new EasyReturn.Web
                {
                    driver = driver,
                    element = webElement,
                    Sucesso = true,
                    table = dataTable
                };
            }
            catch (Exception ex)
            {
                return new EasyReturn.Web
                {
                    driver = driver,
                    Sucesso = false,
                    Error = "Element " + element + " not found. More info: " + ex.Message
                };
            }
        }

        public EasyReturn.Web SelecionaItem(TypeElement typeElement, string element, string cidade, int timeout = 3)
        {
            try
            {
                WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                IWebElement webElement = null;
                switch (typeElement)
                {
                    case TypeElement.Id:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.Id(element)));
                        break;
                    case TypeElement.Name:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.Name(element)));
                        break;
                    case TypeElement.Xpath:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(element)));
                        break;
                    case TypeElement.CssSelector:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.CssSelector(element)));
                        break;
                }

                IList<IWebElement> linkItems = webElement.FindElements(By.TagName("li"));
                string tempMinima = "0";
                string tempMaxima = "0";



                foreach (IWebElement item in linkItems)
                {


                    IWebElement spansInsideLi = item.FindElement(By.TagName("div"));


                    if (spansInsideLi.Text.Contains(cidade))
                    {
                        item.Click();
                        tempMinima = GetValue(TypeElement.Xpath, "/html/body/div[3]/div[3]/div[2]/div/div[2]/div/div/div/div[2]/div[1]/div[2]/div[2]/div[1]/b").Value.ToString();
                        tempMaxima = GetValue(TypeElement.Xpath, "/html/body/div[3]/div[3]/div[2]/div/div[2]/div/div/div/div[2]/div[1]/div[2]/div[3]/div[1]/b").Value.ToString();
                        Console.WriteLine("A temperatura mínima da cidade " + cidade + " é: " + tempMinima);
                        Console.WriteLine("A temperatura máxima da cidade " + cidade + " é: " + tempMaxima);
                        Thread.Sleep(2000);

                    }

                }

                

                return new EasyReturn.Web
                {
                    driver = driver,
                    element = webElement,
                    Sucesso = true,
                    table = null
                };
            }
            catch (Exception ex)
            {
                return new EasyReturn.Web
                {
                    driver = driver,
                    Sucesso = false,
                    Error = "Element " + element + " not found. More info: " + ex.Message
                };
            }
        }

        public EasyReturn.Web TranslateAll(TypeElement typeElement, string element, string textoOriginal, int timeout = 3)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            try
            {
                WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                IWebElement webElement = null;
                switch (typeElement)
                {
                    case TypeElement.Id:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.Id(element)));
                        break;
                    case TypeElement.Name:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.Name(element)));
                        break;
                    case TypeElement.Xpath:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(element)));
                        break;
                    case TypeElement.CssSelector:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.CssSelector(element)));
                        break;
                }

                IList<IWebElement> linkItems = webElement.FindElements(By.TagName("li"));
                var i = 0;

                List<string> topics = new List<string>();

                foreach (IWebElement item in linkItems)
                {
                    //   IWebElement spansInsideLi = item.FindElement(By.ClassName("lang-label"));
                    //   topics.Add(spansInsideLi.Text);
                    ClicarBotao(element, i, timeout);
                    //     ExibirConsole(textoOriginal, topics[i]);
                    i++;
                }

                return new EasyReturn.Web
                {
                    driver = driver,
                    element = webElement,
                    Sucesso = true,
                    table = null
                };
            }

            catch (Exception ex)
            {
                return new EasyReturn.Web
                {
                    driver = driver,
                    Sucesso = false,
                    Error = "Element " + element + " not found. More info: " + ex.Message
                };
            }

        }

        public void ClicarBotao(string element, int i, int timeout)
        {
            WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            IWebElement webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(element)));
            IList<IWebElement> link = webElement.FindElements(By.TagName("li"));
            link[i].Click();
            Thread.Sleep(4000);
            Click(TypeElement.Xpath, "/html/body/app-root/app-translation/div/app-translation-box/div[1]/div[1]/div[1]/app-language-switch/div/app-language-select[2]/div/div/div");

        }

        public void ExibirConsole(string textoOriginal, string idioma)
        {
            IWebElement element = driver.FindElement(By.XPath("/html/body/app-root/app-translation/div/app-translation-box/div[1]/div[1]/div[2]/div[2]/div[1]/textarea"));
            string textoTraduzido = element.Text;
            Console.WriteLine(textoOriginal + " em " + idioma + " é: " + textoTraduzido);
        }

        public EasyReturn.Web SelectValue(TypeElement typeElement, TypeSelect typeSelect, string element, string value, int timeout = 3)
        {
            try
            {
                SelectElement selectElement = null;
                WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                switch (typeElement)
                {
                    case TypeElement.Id:
                        selectElement = new SelectElement(webDriverWait.Until(ExpectedConditions.ElementExists(By.Id(element))));
                        break;
                    case TypeElement.Name:
                        selectElement = new SelectElement(webDriverWait.Until(ExpectedConditions.ElementExists(By.Name(element))));
                        break;
                    case TypeElement.Xpath:
                        selectElement = new SelectElement(webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(element))));
                        break;
                    case TypeElement.CssSelector:
                        selectElement = new SelectElement(webDriverWait.Until(ExpectedConditions.ElementExists(By.CssSelector(element))));
                        break;
                }

                switch (typeSelect)
                {
                    case TypeSelect.Text:
                        selectElement.SelectByText(value);
                        break;
                    case TypeSelect.Value:
                        selectElement.SelectByValue(value);
                        break;
                }

                return new EasyReturn.Web
                {
                    driver = driver,
                    Sucesso = true
                };
            }
            catch (Exception ex)
            {
                EasyReturn.Web web = new EasyReturn.Web();
                web.driver = driver;
                web.Sucesso = false;
                web.Error = "Option " + value + " could not be selected on element " + element + ". More info: " + ex.Message;
                return web;
            }
        }

        public EasyReturn.Web GetWebImage(TypeElement typeElement, string element, string nameImage, int timeout = 3)
        {
            try
            {
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile(Directory.GetCurrentDirectory() + nameImage, ScreenshotImageFormat.Png);
                Image original = Image.FromFile(Directory.GetCurrentDirectory() + nameImage);
                Rectangle rect = default(Rectangle);
                WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                IWebElement webElement = null;
                switch (typeElement)
                {
                    case TypeElement.Id:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.Id(element)));
                        break;
                    case TypeElement.Name:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.Name(element)));
                        break;
                    case TypeElement.Xpath:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(element)));
                        break;
                    case TypeElement.CssSelector:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.CssSelector(element)));
                        break;
                }

                if (webElement != null)
                {
                    int width = webElement.Size.Width;
                    int height = webElement.Size.Height;
                    Point location = webElement.Location;
                    rect = new Rectangle(location.X, location.Y, width, height);
                }

                Bitmap bitmap = new Bitmap(original);
                Bitmap bitmap2 = bitmap.Clone(rect, bitmap.PixelFormat);
                return new EasyReturn.Web
                {
                    driver = driver,
                    element = webElement,
                    Bitmap = bitmap,
                    Sucesso = true
                };
            }
            catch (Exception ex)
            {
                return new EasyReturn.Web
                {
                    driver = driver,
                    Error = "Element " + element + " not found. More info: " + ex.Message,
                    Sucesso = false
                };
            }
        }
        public EasyReturn.Web AccessPopUpClick(TypeElement typeElement, string element, int timeout = 3)
        {
            try
            {
                WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                IWebElement element2 = null;
                switch (typeElement)
                {
                    case TypeElement.Id:
                        element2 = webDriverWait.Until(ExpectedConditions.ElementExists(By.Id(element)));
                        break;
                    case TypeElement.Name:
                        element2 = webDriverWait.Until(ExpectedConditions.ElementExists(By.Name(element)));
                        break;
                    case TypeElement.Xpath:
                        element2 = webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(element)));
                        break;
                    case TypeElement.CssSelector:
                        element2 = webDriverWait.Until(ExpectedConditions.ElementExists(By.CssSelector(element)));
                        break;
                }

                PopupWindowFinder popupWindowFinder = new PopupWindowFinder(driver);
                string windowName = popupWindowFinder.Click(element2);
                driver.SwitchTo().Window(windowName);
                return new EasyReturn.Web
                {
                    driver = driver,
                    element = element2,
                    Sucesso = true
                };
            }
            catch (Exception ex)
            {
                return new EasyReturn.Web
                {
                    driver = driver,
                    Error = "Element " + element + " not found. More info: " + ex.Message,
                    Sucesso = false
                };
            }
        }

        public EasyReturn.Web LeavePopUp()
        {
            try
            {
                driver.SwitchTo().DefaultContent();
                return new EasyReturn.Web
                {
                    driver = driver,
                    Sucesso = true
                };
            }
            catch (Exception ex)
            {
                return new EasyReturn.Web
                {
                    driver = driver,
                    Error = "Driver not found. More info: " + ex.Message,
                    Sucesso = false
                };
            }
        }

        public EasyReturn.Web AccessFrame(TypeElement typeElement, string element, int timeout = 3)
        {
            try
            {
                WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                IWebElement webElement = null;
                switch (typeElement)
                {
                    case TypeElement.Id:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.Id(element)));
                        break;
                    case TypeElement.Name:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.Name(element)));
                        break;
                    case TypeElement.Xpath:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(element)));
                        break;
                    case TypeElement.CssSelector:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.CssSelector(element)));
                        break;
                }

                driver.SwitchTo().Frame(webElement);
                return new EasyReturn.Web
                {
                    driver = driver,
                    element = webElement,
                    Sucesso = true
                };
            }
            catch (Exception ex)
            {
                return new EasyReturn.Web
                {
                    driver = driver,
                    Error = "Element " + element + " not found. More info: " + ex.Message,
                    Sucesso = false
                };
            }
        }

        public EasyReturn.Web ExecuteScript(string script)
        {
            try
            {
                IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
                javaScriptExecutor.ExecuteScript(script);
                return new EasyReturn.Web
                {
                    driver = driver,
                    Sucesso = true
                };
            }
            catch (Exception ex)
            {
                return new EasyReturn.Web
                {
                    driver = driver,
                    Error = "Falha execute in Script. More info: " + ex.Message,
                    Sucesso = false
                };
            }
        }

        public void WaitForLoad(int timeout = 60)
        {
            try
            {
                WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                webDriverWait.Until((IWebDriver wd) => ((IJavaScriptExecutor)wd).ExecuteScript("return document.readyState").ToString() == "complete");
            }
            catch
            {
            }
        }

        public EasyReturn.Web WaitForElement(TypeElement typeElement, string element, int timeout = 3)
        {
            try
            {
                WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                IWebElement element2 = null;
                switch (typeElement)
                {
                    case TypeElement.Id:
                        element2 = webDriverWait.Until(ExpectedConditions.ElementExists(By.Id(element)));
                        break;
                    case TypeElement.Name:
                        element2 = webDriverWait.Until(ExpectedConditions.ElementExists(By.Name(element)));
                        break;
                    case TypeElement.Xpath:
                        element2 = webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(element)));
                        break;
                    case TypeElement.CssSelector:
                        element2 = webDriverWait.Until(ExpectedConditions.ElementExists(By.CssSelector(element)));
                        break;
                }

                webDriverWait.Until(ElementIsVisible(element2));
                return new EasyReturn.Web
                {
                    driver = driver,
                    element = element2,
                    Sucesso = true
                };
            }
            catch (Exception ex)
            {
                return new EasyReturn.Web
                {
                    driver = driver,
                    Error = "More info: " + ex.Message,
                    Sucesso = false
                };
            }
        }

        private static Func<IWebDriver, bool> ElementIsVisible(IWebElement element)
        {
            return delegate
            {
                try
                {
                    return element.Displayed;
                }
                catch (Exception)
                {
                    return false;
                }
            };
        }
    }
}