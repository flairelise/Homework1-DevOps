using System;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace ConsoleStats
{
    class Program
    {
        static IWebDriver driver = new ChromeDriver("C:/Users/carys/OneDrive - University of Arkansas/Business DevOps/Projects");
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing ... Please wait ...\n\n");

            

            // on home pc, use C:/Users/carys/OneDrive - University of Arkansas/Business DevOps/Projects
            // on school network, use O:/Business DevOps/Projects
            // note that location slows down program as it has to pull from cloud--will also get warning that it is not
            // a "safe" location for it...

            /* List of URLs used:
             * https://www.vgchartz.com/analysis/platform_totals/ 
             * https://thegamingsetup.com/guides/console-power-comparison-chart 
             * https://en.wikipedia.org/wiki/Video_game_publisher
             * https://riseatseven.com/blog/xbox-series-x-v-ps5-worlds-most-in-demand-game-console-rise-at-seven/ 
             * https://www.vgchartz.com/analysis/platform_totals/Software/Global/ 
             * 
             * Notes on what each link provides at bottom of code VVVV
             */


            ///////// data pulled from source one BELOW

            void SourceOne()
            {
                            
                Console.WriteLine("\n\nInitializing Source 1 ... Please wait ...\n\n");

                driver.Url = "https://www.vgchartz.com/analysis/platform_totals/";

                Console.WriteLine("Title: " + driver.Title + "\n");

                Console.WriteLine("URL: " + driver.Url + "\n");

                DataTable dsOne = new DataTable();
                dsOne.Clear();


                IWebElement table = driver.FindElement(By.Id("myTable"));

                
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

                    Console.WriteLine("\n\n");
                }

                

            }

            ////////////////// data from source 2 BELOW
            
            void SourceTwo()
            {
                
                Console.WriteLine("\n\nInitializing Source 2... Please wait ...\n\n");

                driver.Url = "https://thegamingsetup.com/guides/console-power-comparison-chart";

                Console.WriteLine("Title: " + driver.Title + "\n");

                Console.WriteLine("URL: " + driver.Url + "\n");

               

                IWebElement table = driver.FindElement(By.XPath("/html/body/div[2]/div/section[3]/div/div/div/section/div/div[1]/div/div[1]/div/div/div/section/div/div/div/div/div/table/tbody"));
                Thread.Sleep(1000);

                var rows = table.FindElements(By.TagName("tr"));

                foreach (var row in rows)
                {
                    
                    var tds = row.FindElements(By.TagName("td"));
                  
                    foreach (var entry in tds)
                    {
                        Console.Write(entry.Text + "\t");
                    }

                    Console.WriteLine("\n\n");
                }

               


            }

            /////////// data from source 3 below
            

            void SourceThree()
            {
                

                Console.WriteLine("\n\nInitializing Source 3... Please wait ...\n\n");

                driver.Url = "https://en.wikipedia.org/wiki/Video_game_publisher";

                Console.WriteLine("Title: " + driver.Title + "\n");

                Console.WriteLine("URL: " + driver.Url + "\n");

               

                IWebElement table = driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div[5]/div[1]/table[3]"));
                Thread.Sleep(1000);

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

                    Console.WriteLine("\n\n");
                }

          


            }

            /////////////// data pulled from 4 below
            
            void SourceFour()
            {


                Console.WriteLine("\n\nInitializing Source 4... Please wait ...\n\n");

                driver.Url = "https://riseatseven.com/blog/xbox-series-x-v-ps5-worlds-most-in-demand-game-console-rise-at-seven/";

                Console.WriteLine("Title: " + driver.Title + "\n");

                Console.WriteLine("URL: " + driver.Url + "\n");


                IWebElement table = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div[1]/div/article/div/div/div/figure/table/tbody"));

                var rows = table.FindElements(By.TagName("tr"));

                foreach (var row in rows)
                {
                    
                    var tds = row.FindElements(By.TagName("td"));
                  
                    foreach (var entry in tds)
                    {
                        Console.Write(entry.Text + "\t");
                    }

                    Console.WriteLine("\n\n");
                }

              
                

            }

            ///// data pulled from 5 below
            
            void SourceFive()
            {

                Console.WriteLine("\n\nInitializing Source 5... Please wait ...\n\n");

                driver.Url = "https://www.vgchartz.com/analysis/platform_totals/Software/Global/";

                Console.WriteLine("Title: " + driver.Title + "\n");

                Console.WriteLine("URL: " + driver.Url + "\n");

                IWebElement table = driver.FindElement(By.Id("myTable"));

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
                
                Console.WriteLine("\n\nNow calculating index, please wait...\n\n");
                
                double calc = 0;
                
                foreach (var row in rows) //first time through we're going to calculate an average
                {
                    var tdStatic = row.FindElements(By.XPath("td[3]"));
                    foreach (var entry in tdStatic)
                    {
                        //now we calculate

                        double y;
                        string x = entry.Text;
                        y = Convert.ToDouble(x);

                        calc += y;
                    }
                    
                }
                
                double index5 = (calc / 28); //only 28 entries actually have data to support them, so we'll use this to make the average

                Console.WriteLine(String.Format("The index for this calculation is an average showing increase or decrease in value for North America ONLY. The average is: {0:0} billion USD.\n", index5));
                Console.WriteLine("NOTE: The last 5 entries do not reflect any data as of yet.\n");
                
                double avg;
                int count = 1;
                Console.WriteLine("Pos\tIndex Number");
                foreach (var row in rows) //second time through we'll compare the average to each entry and print the results
                {

                    var tdStatic = row.FindElements(By.XPath("td[3]"));
                    foreach (var entry in tdStatic)
                    {
                        //now we calculate
                        
                        double y;
                        string x = entry.Text;
                        y = Convert.ToDouble(x);

                        avg = ((y-index5) / index5) * 100;
                        
                        Console.WriteLine(String.Format(count + "\t{0:0}", avg));
                        count += 1;
                    }

                }

                Console.WriteLine("\nNOTE: Index values are currently given in order corresponding to their position on the website." +
                            "\nRefer to the first printed table above for clarification.\n");
                Console.WriteLine("\n\n");
   

            }

            //now to call each method and start the process
            //remember that each has to start the driver manually on their own and reassign their respective URLs

           // SourceOne();
           // SourceTwo();
           // SourceThree();
           // SourceFour();
            SourceFive();

            //now we just need to calculate meaningful indices from these sources vvvvvvvvvvvvvvv

            /* SOURCE 1 --
             * consoles by units sold in diff areas of the world (will focus on NA)
             * 
             * SOURCE 2 --
             * consoles by gpu fglops
             * 
             * SOURCE 3 --
             * top video game publisher and revenue in bn
             * 
             * SOURCE 4 --
             * console dominance by country
             * 
             * SOURCE 5 --
             * consoles by software units (games) sold (despite 30+ entries, data for some is barren, so we calculate out of 28)
             */
            
            driver.Quit();
            Console.WriteLine();

        }
    }
}