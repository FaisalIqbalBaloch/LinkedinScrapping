
LinkedIn Scraper
This C# console application allows you to scrape posts from a LinkedIn profile. It utilizes Selenium for web automation and HtmlAgilityPack for HTML parsing.

Usage
Clone the Repository:

bash
Copy code
git clone https://github.com/your-username/LinkedInScraper.git
cd LinkedInScraper
Build the Project:
Open the project in Visual Studio or your preferred C# development environment. Build the project to restore dependencies.

Run the Application:

Launch the application, and you will be prompted to enter your LinkedIn email, password, and the profile URL you want to scrape.
The application will perform a headless login and navigate to the specified profile.
Scrape LinkedIn Posts:

The scraper will scroll through the profile page, collecting post information.
The data (post text, date, and likes) will be displayed in the console and saved to a CSV file (LinkedinDataScrapedWL.csv).
Review the Results:

Once the scraping is complete, the console will display a message indicating the data has been saved to the CSV file.
Dependencies
Selenium.WebDriver: The Selenium WebDriver is used for web automation.
HtmlAgilityPack: HtmlAgilityPack is employed for HTML parsing.
Important Note
This scraper interacts with LinkedIn, and its usage may be subject to LinkedIn's terms of service. Ensure compliance with LinkedIn's policies.
Contribution
Feel free to contribute, report issues, or suggest improvements. Create a pull request with your changes.
