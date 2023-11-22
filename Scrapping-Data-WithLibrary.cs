//using HtmlAgilityPack;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Threading.Tasks;

//public class LinkedInScraper
//{
//    private readonly ChromeDriver driver;

//    public LinkedInScraper()
//    {
//        var options = new ChromeOptions();
//        options.AddArgument("--headless");

//        driver = new ChromeDriver(@"C:\Users\admin\source\repos\Scrapping\Scrapping\chromedriver-win64\chromedriver.exe", options);

//        driver.Manage().Window.Maximize();
//    }

//    public static void Main()
//    {
//        var scraper = new LinkedInScraper();

//        Console.WriteLine("Enter your LinkedIn email:");
//        var email = Console.ReadLine();

//        Console.WriteLine("Enter your LinkedIn password:");
//        var password = Console.ReadLine();

//        Console.WriteLine("Enter the LinkedIn profile URL to scrape:");
//        var profileUrl = Console.ReadLine();

//        var csvFilePath = @"C:\Users\admin\source\repos\Scrapping\Scrapping\LinkedinScrappingWL\LinkedinDataScrapedWL.csv";

//        try
//        {
//            scraper.driver.Navigate().GoToUrl("https://www.linkedin.com/login");

//            var emailField = scraper.driver.FindElement(By.Id("username"));
//            emailField.SendKeys(email);

//            var passwordField = scraper.driver.FindElement(By.Id("password"));
//            passwordField.SendKeys(password);

//            passwordField.SendKeys(Keys.Enter);

//            System.Threading.Thread.Sleep(1000);

//            Console.WriteLine(scraper.driver.Url.Contains("feed") ? "Login successful!" : "Login failed. Check your credentials");

//            scraper.driver.Navigate().GoToUrl(profileUrl);

//            Task.Delay(TimeSpan.FromSeconds(1)).Wait();

//            var postsData = new List<Post>();
//            HashSet<string> uniquePosts = new HashSet<string>();

//            for (int i = 0; i < 15; i++)
//            {
//                ((IJavaScriptExecutor)scraper.driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
//                Task.Delay(TimeSpan.FromSeconds(5)).Wait();

//                var htmlDocument = new HtmlDocument();
//                htmlDocument.LoadHtml(scraper.driver.PageSource);
//                var postNodes = htmlDocument.DocumentNode.SelectNodes("//main/div/div/div[2]/div[3]/div/div/div")?.ToList();

//                if (postNodes != null)
//                {
//                    foreach (var postNode in postNodes)
//                    {
//                        var postText = postNode.SelectSingleNode(".//div[4]/div/div/span")?.InnerText.Trim();
//                        var postDate = postNode.SelectSingleNode(".//div[2]/div//a[2]/span/span[@aria-hidden='true']")?.InnerText.Trim();
//                        var postLikes = postNode.SelectSingleNode(".//button//span[contains(@class, 'social-details-social-counts__reactions-count')]")?.InnerText.Trim();

//                        var postKey = $"{postText}|{postDate}|{postLikes}";

//                        if (!uniquePosts.Contains(postKey) && !string.IsNullOrEmpty(postText) && !string.IsNullOrEmpty(postDate) && !string.IsNullOrEmpty(postLikes))
//                        {
//                            uniquePosts.Add(postKey);

//                            var postData = new Post
//                            {
//                                Text = postText,
//                                Date = postDate,
//                                Likes = postLikes
//                            };

//                            postsData.Add(postData);
//                            Console.WriteLine();
//                            Console.WriteLine("-------Request start------");
//                            Console.WriteLine($"Post Text:     {postData.Text}");
//                            Console.WriteLine($"Post Date:     {postData.Date}");
//                            Console.WriteLine($"Post Likes:    {postData.Likes}");
//                            Console.WriteLine("------------Request Complete.....------");
//                            Console.WriteLine();
//                        }
//                    }
//                }
//            }

//            using (var writer = new StreamWriter(csvFilePath, true))
//            {
//                foreach (var postData in postsData)
//                {
//                    writer.WriteLine($" Post Text:     {postData.Text}");
//                    writer.WriteLine($" Post Date:     {postData.Date}");
//                    writer.WriteLine($" Post Likes:    {postData.Likes}");
//                    writer.WriteLine();
//                    writer.WriteLine();
//                    writer.WriteLine();
//                }
//            }

//            Console.WriteLine($"Data saved to {csvFilePath}");
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Error: {ex.Message}");
//        }
//        finally
//        {
//            scraper.driver.Quit();
//        }
//    }

//    public class Post
//    {
//        public string Text { get; set; }
//        public string Date { get; set; }
//        public string Likes { get; set; }
//    }
//}

















