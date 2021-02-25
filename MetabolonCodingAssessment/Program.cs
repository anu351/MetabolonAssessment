using System;
using System.Collections.Generic;
using System.Linq;


namespace MetabolonCodingAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            RSSFeed rssFeed = new RSSFeed();
            Dictionary<string, IEnumerable<string>> companyList = new Dictionary<string, IEnumerable<string>>();
            int inactivityDays;

            //Dictionary Input
            var companyDict = new Dictionary<string, IEnumerable<string>>
            {
                { "Unrivaled: Long Island Serial Killer", new List<string>{"https://rss.acast.com/unraveled" } },
                {"Morbid: A True Crime Podcast", new List<string>{"https://audioboom.com/channels/4997220.rss"} },
                {"CNN", new List<string>{"http://rss.cnn.com/rss/cnn_topstories.rss","http://rss.cnn.com/rss/money_pf_college.rss" } },
                {"Crime Junkie", new List<string>{"https://feeds.megaphone.fm/ADL9840290619" } },
                {"CNBC", new List<string>{ "https://www.cnbc.com/id/100003114/device/rss/rss.html","https://www.cnbc.com/id/100370673/device/rss/rss.html", "https://www.cnbc.com/id/10000108/device/rss/rss.html" } },

            };

            //Set number of inactivity days
            inactivityDays = 2;

            //Get the list of inactive companies
            companyList = rssFeed.ActivityTrackerRSS(companyDict, inactivityDays);

            if (companyList.Count > 0)
            {
                Console.WriteLine("Companies that have no activity in the past " + inactivityDays + " Days:");
                foreach (KeyValuePair<string, IEnumerable<string>> compName in companyList)
                {
                    Console.WriteLine("\n" + compName.Key);
                    foreach (string feed in compName.Value)
                    {
                        Console.WriteLine("\t" + feed);
                    }
                    
                }
            }
           
            else
            {
                Console.WriteLine("There are no inactive Companies in the past " + inactivityDays + " Days!");
            }
            
        }
    }
}
