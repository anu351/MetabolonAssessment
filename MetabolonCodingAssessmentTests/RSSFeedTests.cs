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
    }
}