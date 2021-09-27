using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace CryptoStats
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing ... Please wait ...\n\n");

            IWebDriver driver = new ChromeDriver("C:/Users/carys/OneDrive - University of Arkansas/Business DevOps/Projects");

            // on home pc, use C:/Users/carys/OneDrive - University of Arkansas/Business DevOps/Projects
            // on school network, use O:/Business DevOps/Projects
            // note that location slows down program as it has to pull from cloud--will also get warning that it is not
            // a "safe" location for it...however, with THIS program, security in this aspect is unimportant

            /* List of URLs used:
             * https://blockchain.news/analysis/which-cryptocurrency-has-the-highest-roi-as-of-q1-2020-bitcoin-only-ranked-5th -- use xpath
             * https://www.slickcharts.com/currency -- use table for class name
             * https://coincodex.com/historical-data/crypto/ -- use xpath
             * https://www.coingecko.com/en/coins/trending -- use xpath
             * https://www.coingecko.com/en/coins/high_volume -- uses xpath
             */


            ///////// data pulled from source one BELOW

            void SourceOne()
            {
                //don't need new driver here because we'll call this method first, and it has already initialized in the first
                //piece of code under Main()

                Console.WriteLine("\n\nInitializing Source 1 ... Please wait ...\n\n");

                driver.Url = "https://blockchain.news/analysis/which-cryptocurrency-has-the-highest-roi-as-of-q1-2020-bitcoin-only-ranked-5th";

                Console.WriteLine("Title: " + driver.Title + "\n");

                Console.WriteLine("URL: " + driver.Url + "\n");

                //Console.WriteLine(driver.PageSource);

                IWebElement table = driver.FindElement(By.XPath("/html/body/div/div[2]/div/div/main/div[1]/div/div[1]/div/div[2]/div/table"));

                var rows = table.FindElements(By.TagName("tr"));

                foreach (var row in rows)
                {
                    var tds = row.FindElements(By.TagName("td"));

                    foreach (var entry in tds)
                    {
                        Console.Write(entry.Text + "\t");
                    }

                    Console.WriteLine();
                }

                driver.Quit();
                

            }

            ////////////////// data from source 2 BELOW
            
            void SourceTwo()
            {
                IWebDriver driver = new ChromeDriver("C:/Users/carys/OneDrive - University of Arkansas/Business DevOps/Projects");

                Console.WriteLine("\n\nInitializing Source 2... Please wait ...\n\n");

                driver.Url = "https://www.slickcharts.com/currency";

                Console.WriteLine("Title: " + driver.Title + "\n");

                Console.WriteLine("URL: " + driver.Url + "\n");

                //Console.WriteLine(driver.PageSource);

                IWebElement table = driver.FindElement(By.ClassName("table")); //bad practice but they named the only table table...

                var rows = table.FindElements(By.TagName("tr"));

                foreach (var row in rows)
                {
                    var ths = row.FindElements(By.TagName("th"));
                    var tds = row.FindElements(By.TagName("td"));
                    foreach (var entry in ths)
                    {
                        Console.Write(entry.Text + "\t");
                    }
                    foreach (var entry in tds)
                    {
                        Console.Write(entry.Text + "\t");
                    }

                    Console.WriteLine();
                }

                driver.Quit();


            }

            /////////// data from source 3 below
            

            void SourceThree()
            {
                IWebDriver driver = new ChromeDriver("C:/Users/carys/OneDrive - University of Arkansas/Business DevOps/Projects");

                Console.WriteLine("\n\nInitializing Source 3... Please wait ...\n\n");

                driver.Url = "https://coincodex.com/historical-data/crypto/";

                Console.WriteLine("Title: " + driver.Title + "\n");

                Console.WriteLine("URL: " + driver.Url + "\n");

                //Console.WriteLine(driver.PageSource);

                IWebElement table = driver.FindElement(By.XPath("/html/body/app-root/app-historical-data/div/div/div[4]/div/div/table"));

                var rows = table.FindElements(By.TagName("tr"));

                foreach (var row in rows)
                {
                    
                    var tds = row.FindElements(By.TagName("td"));       
                   
                    foreach (var entry in tds)
                    {
                        Console.Write(entry.Text + "\t");
                    }

                    Console.WriteLine();
                }

                driver.Quit();


            }

            /////////////// data pulled from 4 below
            
            void SourceFour()
            {
                IWebDriver driver = new ChromeDriver("C:/Users/carys/OneDrive - University of Arkansas/Business DevOps/Projects");

                Console.WriteLine("\n\nInitializing Source 4... Please wait ...\n\n");

                driver.Url = "https://www.coingecko.com/en/coins/trending";

                Console.WriteLine("Title: " + driver.Title + "\n");

                Console.WriteLine("URL: " + driver.Url + "\n");

                //Console.WriteLine(driver.PageSource);

                IWebElement table = driver.FindElement(By.XPath("/html/body/div[3]/div[5]/div[1]/div"));

                var rows = table.FindElements(By.TagName("tr"));

                foreach (var row in rows)
                {
                    var ths = row.FindElements(By.TagName("th"));
                    var tds = row.FindElements(By.TagName("td"));
                    foreach (var entry in ths)
                    {
                        Console.Write(entry.Text + "\t");
                    }
                    foreach (var entry in tds)
                    {
                        Console.Write(entry.Text + "\t");
                    }

                    Console.WriteLine();
                }

                driver.Quit();
                

            }

            ///// data pulled from 5 below
            
            void SourceFive()
            {
                IWebDriver driver = new ChromeDriver("C:/Users/carys/OneDrive - University of Arkansas/Business DevOps/Projects");

                Console.WriteLine("\n\nInitializing Source 5... Please wait ...\n\n");

                driver.Url = "https://www.coingecko.com/en/coins/high_volume";

                Console.WriteLine("Title: " + driver.Title + "\n");

                Console.WriteLine("URL: " + driver.Url + "\n");

               // Console.WriteLine(driver.PageSource);

                IWebElement table = driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div[3]/div/div/div/table"));

                var rows = table.FindElements(By.TagName("tr"));

                foreach (var row in rows)
                {
                    var ths = row.FindElements(By.TagName("th"));
                    var tds = row.FindElements(By.TagName("td"));
                    foreach (var entry in ths)
                    {
                        Console.Write(entry.Text + "\t");
                    }
                    foreach (var entry in tds)
                    {
                        Console.Write(entry.Text + "\t");
                    }

                    Console.WriteLine();
                }

                driver.Quit();
                

            }

            //now to call each method and start the process
            //remember that each has to start the driver manually on their own and reassign their respective URLs

            SourceOne();
            SourceTwo();
            SourceThree();
            SourceFour();
            SourceFive();

            //now we just need to calculate meaningful indices from these sources vvvvvvvvvvvvvvv

            /* SOURCE 1 --
             * Top 30 cryptos by ROI
             * 
             * SOURCE 2 --
             * Market cap, market share, price and 24 hour change in percentage of top 100 cryptos
             * 
             * SOURCE 3 --
             * Shows price, 24 h change, 7d change, 1m change, etc of top 100
             * 
             * SOURCE 4 --
             * Shows top gainers in the crypto world, volume, price and percentage increase
             * 
             * SOURCE 5 --
             * Shows top crypto coins by trading volume
             */


        }
    }
}