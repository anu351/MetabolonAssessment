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
            List<string> companyList = new List<string>();
            int inactivityDays;

            //Dictionary Input
            var companyDict = new Dictionary<string, string>
            {
                { "Unrivaled: Long Island Serial Killer", "https://rss.acast.com/unraveled" },
                {"Morbid: A True Crime Podcast", "https://audioboom.com/channels/4997220.rss"},
                {"CNN", "http://rss.cnn.com/rss/cnn_topstories.rss" },
                {"Crime Junkie", "https://feeds.megaphone.fm/ADL9840290619" }
            };

            //Set number of inactivity days
            inactivityDays = 2;

            //Get the list of inactive companies
            companyList = rssFeed.ActivityTrackerRSS(companyDict, inactivityDays);

            if (companyList.Count > 0)
            {
                Console.WriteLine("Companies that have no activity in the past " + inactivityDays + " Days:");
                foreach (string compName in companyList)
                {
                    Console.WriteLine(compName);
                }
            }
           
            else
            {
                Console.WriteLine("There are no inactive Companies in the past " + inactivityDays + " Days!");
            }
            
        }
    }
}
