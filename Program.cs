using System;
using System.Data; //threw in some extra libraries that I used to experiment, but didn't end up using in the final product.
using System.IO;
using System.Text;
using System.Threading;
using System.Runtime;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace ConsoleStats
{
    class Program
    {   
        static IWebDriver driver = new ChromeDriver("C:/Users/carys/Documents");
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing ... Please wait ...\n\n");

            Console.WriteLine("This program is intended only to scrub data from websites, display, and calculate indexes based on the data provided.\n");

            /*!!!!! WARNING:
             * Please set location of chromedriver manually if project fails.
             * LINE 13 -- edit path
             */

            /* List of URLs used:
             * https://www.vgchartz.com/analysis/platform_totals/ 
             * https://thegamingsetup.com/guides/console-power-comparison-chart 
             * https://en.wikipedia.org/wiki/Video_game_publisher
             * https://www.finder.com.au/in-demand-consoles
             * https://www.vgchartz.com/analysis/platform_totals/Software/Global/ 
             * 
             * Notes on what each link provides at bottom of code VVVV
             */


            // start of data 1 source code -----------------------------------------------------------------

            void SourceOne()
            {
                            
                Console.WriteLine("\n\nInitializing Source 1 ... Please wait ...\n\n");

                driver.Url = "https://www.vgchartz.com/analysis/platform_totals/";

                Console.WriteLine("Title: " + driver.Title + "\n");

                Console.WriteLine("URL: " + driver.Url + "\n");

                Console.WriteLine("\nThis source shows the ranking of gaming console by HARDWARE sales in different areas." +
                    "\nFor this purpose, we will look at the North American numbers only, but the entire chart will be printed for user visibility.\n");


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
                Console.WriteLine("NOTE: Anything that comes out to -100 doesn't have sufficient data as of yet and is ignored in calculation.\n");

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

                        avg = ((y - index5) / index5) * 100;

                        Console.WriteLine(String.Format(count + "\t{0:0}", avg));
                        count += 1;
                    }

                }

                Console.WriteLine("\nNOTE: Index values are currently given in order corresponding to their position on the website." +
                            "\nRefer to the first printed table above for clarification.\n");
                Console.WriteLine("\n\n");


            }
            
            // end of data 1 source code -------------------------------------------------------------------

            // start of data 2 source code -----------------------------------------------------------------


            void SourceTwo()
            {
                
                Console.WriteLine("\n\nInitializing Source 2... Please wait ...\n\n");

                driver.Url = "https://thegamingsetup.com/guides/console-power-comparison-chart";

                Console.WriteLine("Title: " + driver.Title + "\n");

                Console.WriteLine("URL: " + driver.Url + "\n");

               

                IWebElement table = driver.FindElement(By.XPath("/html/body/div[2]/div/section[3]/div/div/div/section/div/div[1]/div/div[1]/div/div/div/section/div/div/div/div/div/table/tbody"));
                

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

                Console.WriteLine("\n\nNow calculating index, please wait...\n\n");

                double calc = 0;

                foreach (var row in rows) //first time through we're going to calculate an average
                {
                    var tdStatic = row.FindElements(By.XPath("td[2]"));
                    foreach (var entry in tdStatic)
                    {
                        //now we calculate
                        try
                        {
                            double y;
                            string x = entry.Text;
                            y = Convert.ToDouble(x);

                            calc += y;
                        }
                        catch
                        {
                            Console.WriteLine("GFlops");
                        }
                    }

                }

                double index5 = (calc / 21); //only 21 entries for this one

                Console.WriteLine(String.Format("The index for this calculation is a comparison of GPUs for consoles in GFlops (power). The average is: {0:0} GFlops.\n", index5));

                double avg;
                int count = 1;
                Console.WriteLine("Pos\tIndex Number");

                foreach (var row in rows) //second time through we'll compare the average to each entry and print the results
                {

                    var tdStatic = row.FindElements(By.XPath("td[2]"));
                    foreach (var entry in tdStatic)
                    {
                        //now we calculate
                        try
                        {
                            double y;
                            string x = entry.Text;
                            y = Convert.ToDouble(x);

                            avg = ((y - index5) / index5) * 100;

                            Console.WriteLine(String.Format(count + "\t{0:0}", avg));
                            count += 1;
                        }
                        catch
                        {
                            
                        }
                    }

                }

                Console.WriteLine("\nNOTE: Index values are currently given in order corresponding to their position on the website." +
                            "\nRefer to the first printed table above for clarification.\n");
                Console.WriteLine("\n\n");


            }

            // end of data 2 source code -------------------------------------------------------------------

            // start of data 3 source code -----------------------------------------------------------------

            void SourceThree()
            {
                

                Console.WriteLine("\n\nInitializing Source 3... Please wait ...\n\n");

                driver.Url = "https://en.wikipedia.org/wiki/Video_game_publisher";

                Console.WriteLine("Title: " + driver.Title + "\n");

                Console.WriteLine("URL: " + driver.Url + "\n");

               

                IWebElement table = driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div[5]/div[1]/table[3]"));
                

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

                Console.WriteLine("\n\nNow calculating index, please wait...\n\n");

                double calc = 0;

                foreach (var row in rows) //first time through we're going to calculate an average
                {
                    var tdStatic = row.FindElements(By.XPath("td[4]"));
                    foreach (var entry in tdStatic)
                    {
                        //now we calculate
                        try
                        {
                            double y;
                            string x = entry.Text;
                            y = Convert.ToDouble(x);

                            calc += y;
                        }
                        catch
                        {
                            
                        }
                    }

                }

                double index5 = (calc / 10); //only top 10 for this one

                Console.WriteLine(String.Format("The index for this calculation is a rating of top 10 video game publishers by revenue. The average is: {0:0} billion USD.\n", index5));

                double avg;
                int count = 1;
                Console.WriteLine("Pos\tIndex Number");

                foreach (var row in rows) //second time through we'll compare the average to each entry and print the results
                {

                    var tdStatic = row.FindElements(By.XPath("td[4]"));
                    foreach (var entry in tdStatic)
                    {
                        //now we calculate
                        try
                        {
                            double y;
                            string x = entry.Text;
                            y = Convert.ToDouble(x);

                            avg = ((y - index5) / index5) * 100;

                            Console.WriteLine(String.Format(count + "\t{0:0}", avg));
                            count += 1;
                        }
                        catch
                        {

                        }
                    }

                }

                Console.WriteLine("\nNOTE: Index values are currently given in order corresponding to their position on the website." +
                            "\nRefer to the first printed table above for clarification.\n");
                Console.WriteLine("\n\n");


            }

            // end of data 3 source code -------------------------------------------------------------------

            // start of data 4 source code -----------------------------------------------------------------


            void SourceFour()
            {


                Console.WriteLine("\n\nInitializing Source 4... Please wait ...\n\n");

                driver.Url = "https://www.finder.com.au/in-demand-consoles";

                Console.WriteLine("Title: " + driver.Title + "\n");

                Console.WriteLine("URL: " + driver.Url + "\n");


                IWebElement table = driver.FindElement(By.XPath("/html/body/div[1]/div/div[5]/div[2]/div[2]/div/table"));

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

                Console.WriteLine("\n\nNow calculating index, please wait...\n\n");

                double calc = 0;

                foreach (var row in rows) //first time through we're going to calculate an average
                {
                    var tdStatic = row.FindElements(By.XPath("td[3]"));
                    foreach (var entry in tdStatic)
                    {
                        //now we calculate
                        try
                        {
                            double y;
                            string x = entry.Text;

                            char[] trimChars = { '%' };
                            x = x.Trim(trimChars);
                            
                            y = Convert.ToDouble(x);

                            calc += y;
                        }
                        catch
                        {

                        }
                    }

                }

                double index5 = (calc / 16); //only top 16 for this one

                Console.WriteLine(String.Format("The index for this calculation is a rating of Playstation 5 demand in different countries compared to Xbox. The average is: {0:0.00}% percentage of demand compared to Xbox Series X.\n", index5));

                double avg;
                int count = 1;
                Console.WriteLine("Pos\tIndex Number");

                foreach (var row in rows) //second time through we'll compare the average to each entry and print the results
                {

                    var tdStatic = row.FindElements(By.XPath("td[3]"));
                    foreach (var entry in tdStatic)
                    {
                        //now we calculate
                        try
                        {
                            double y;
                            string x = entry.Text;

                            char[] trimChars = { '%' };
                            x = x.Trim(trimChars);

                            y = Convert.ToDouble(x);

                            avg = ((y - index5) / index5) * 100;

                            Console.WriteLine(String.Format(count + "\t{0:0}", avg));
                            count += 1;
                        }
                        catch
                        {

                        }
                    }

                }

                Console.WriteLine("\nNOTE: Index values are currently given in order corresponding to their position on the website." +
                            "\nRefer to the first printed table above for clarification.\n");
                Console.WriteLine("\n\n");


            }
            // end of data 4 source code -----------------------------------------------------------------

            // data pulled from 5 below ------------------------------------------------------------------
            
            void SourceFive()
            {

                Console.WriteLine("\n\nInitializing Source 5... Please wait ...\n\n");

                driver.Url = "https://www.vgchartz.com/analysis/platform_totals/Software/Global/";

                Console.WriteLine("Title: " + driver.Title + "\n");

                Console.WriteLine("URL: " + driver.Url + "\n");

                Console.WriteLine("\nThis source shows the ranking of gaming console by SOFTWARE sales in different areas." +
                    "\nFor this purpose, we will look at the North American numbers only, but the entire chart will be printed for user visibility.\n");

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
                Console.WriteLine("NOTE: Anything that comes out to -100 doesn't have sufficient data as of yet and is ignored in calculation.\n");

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

            // end of data 5 source code -----------------------------------------------------------------


            //now to call each method and start the process
            //remember that each has to assign the driver url and it takes a bit of time depending on internet speed
            //indicies are calculated within each method and explained with some text

            SourceOne();
            SourceTwo();
            SourceThree();
            SourceFour();
            SourceFive();

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
             * console dominance by country (xbox series x vs ps5)
             * 
             * SOURCE 5 --
             * consoles by software units (games) sold (despite 30+ entries, data for some is barren, so we calculate out of 28)
             */
            
            driver.Quit();
            Console.WriteLine();
            /*
             * Program Credits:
             * Each source used in this code was simply for creating an opinionated index or rating based on data provided by these sources.
             * No data is claimed as my own, and each source is linked internally. Sources used only as references.
             * 
             * University of Arkansas
             * Carys Brown
             * Fall 2021
             * 
             */
        }
    }
}