# MetabolonAssessment
Given a Dictionary keyed by Company and valued by RSS feed url, write a function that determines which companies had no activity for a given number of days.
Resources: https://rss.com/popular-rss-feeds/ provides many example companies and their RSS feeds

Assumptions:
1. The dictionary provided as input has valid company names and valid URLs.
2. All URLs point to RSS Feeds and will return XML.
3. Dictionary input is in the correct format of string and List of strings for the feeds.
4. RSS Feeds are correct formats.


Program.cs can be used to test functionality.

**INPUT Dictionary:**

var companyDict = new Dictionary<string, IEnumerable<string>>
            {
                { "Unrivaled: Long Island Serial Killer", new List<string>{"https://rss.acast.com/unraveled" } },
                {"Morbid: A True Crime Podcast", new List<string>{"https://audioboom.com/channels/4997220.rss"} },
                {"CNN", new List<string>{"http://rss.cnn.com/rss/cnn_topstories.rss","http://rss.cnn.com/rss/money_pf_college.rss" } },
                {"Crime Junkie", new List<string>{"https://feeds.megaphone.fm/ADL9840290619" } },
                {"CNBC", new List<string>{ "https://www.cnbc.com/id/100003114/device/rss/rss.html","https://www.cnbc.com/id/100370673/device/rss/rss.html",         "https://www.cnbc.com/id/10000108/device/rss/rss.html" } },

            };
            
  
 **** Results in Following output:****
 
  Companies that have no activity in the past 2 Days:

  Morbid: A True Crime Podcast
        https://audioboom.com/channels/4997220.rss

  CNN
        http://rss.cnn.com/rss/money_pf_college.rss

  Crime Junkie
        https://feeds.megaphone.fm/ADL9840290619
