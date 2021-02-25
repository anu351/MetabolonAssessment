using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestClass()]
    public class RSSFeedTests
    {
        DateTime expectedDate = new DateTime(2021, 2, 24, 11, 0, 0);
        RSSFeed rssFeed = new RSSFeed();
        int numOfDays = 5;

        [TestMethod()]
        public void ReadRSSFeedTest()
        {
            string testURL = "https://rss.acast.com/unraveled";
            DateTime pubDate = rssFeed.ReadRSSFeed(testURL);

            Assert.AreEqual(pubDate, expectedDate);

        }

        [TestMethod()]
        public void CheckFeedActivityTest()
        {
            bool testActivity = rssFeed.CheckFeedActivity(expectedDate, numOfDays);
            bool expectedResult = true;
            Assert.AreEqual(testActivity, expectedResult);
        }

        [TestMethod()]
        public void CheckFeedActivityFalseTest()
        {
            DateTime oldDate = new DateTime(2021, 2, 12, 11, 0, 0);
            bool expectedResult = false;
            bool testAct = rssFeed.CheckFeedActivity(oldDate, numOfDays);

            Assert.AreEqual(testAct, expectedResult);

        }

        [TestMethod()]
        public void ActivityTrackerRSSTest()
        {
            Dictionary<string, IEnumerable<string>> actualList = new Dictionary<string, IEnumerable<string>>();
            Dictionary<string, IEnumerable<string>> expectedList = new Dictionary<string, IEnumerable<string>>();

            expectedList.Add("Morbid: A True Crime Podcast", new List<string> { "https://audioboom.com/channels/4997220.rss" });
            expectedList.Add("CNN", new List<string> {"http://rss.cnn.com/rss/money_pf_college.rss" });
            expectedList.Add("Crime Junkie", new List<string> {"https://feeds.megaphone.fm/ADL9840290619" });

            var companyDict = new Dictionary<string, IEnumerable<string>>
            {
                { "Unrivaled: Long Island Serial Killer", new List<string>{"https://rss.acast.com/unraveled" } },
                {"Morbid: A True Crime Podcast", new List<string>{"https://audioboom.com/channels/4997220.rss"} },
                {"CNN", new List<string>{"http://rss.cnn.com/rss/cnn_topstories.rss","http://rss.cnn.com/rss/money_pf_college.rss" } },
                {"Crime Junkie", new List<string>{"https://feeds.megaphone.fm/ADL9840290619" } },
                {"CNBC", new List<string>{ "https://www.cnbc.com/id/100003114/device/rss/rss.html","https://www.cnbc.com/id/100370673/device/rss/rss.html", "https://www.cnbc.com/id/10000108/device/rss/rss.html" } },

            };

            actualList = rssFeed.ActivityTrackerRSS(companyDict, 2);           

            CollectionAssert.AreEqual(expectedList.Keys, actualList.Keys);
            
        }
    }
}