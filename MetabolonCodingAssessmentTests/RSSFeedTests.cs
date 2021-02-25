using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestClass()]
    public class RSSFeedTests
    {
        [TestMethod()]
        public void ReadRSSFeedTest()
        {
            string testURL = "https://rss.acast.com/unraveled";
            RSSFeed rssFeed = new RSSFeed();
            DateTime expectedDate = new DateTime(2021, 2, 24, 11, 0, 0);

            DateTime pubDate = rssFeed.ReadRSSFeed(testURL);

            Assert.AreEqual(pubDate, expectedDate);
           
        }
    }
}