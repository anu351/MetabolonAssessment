﻿using System;
using System.Collections.Generic;

namespace MetabolonCodingAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            //Temporary TestValues
            var companyDict = new Dictionary<string, string>
            {
                { "Unrivaled: Long Island Serial Killer", "https://rss.acast.com/unraveled" },
                {"Morbid: A True Crime Podcast", "https://audioboom.com/channels/4997220.rss"},
                {"CNN", "http://rss.cnn.com/rss/cnn_topstories.rss" }
            };

            RSSFeed rssFeed = new RSSFeed();
            rssFeed.ReadRSSFeed("https://rss.acast.com/unraveled");
            DateTime oldDate = new DateTime(2021, 2, 12, 11, 0, 0);
            rssFeed.CheckFeedActivity(oldDate,5);
        }
    }
}
