using System;
using System.Collections.Generic;
using System.Xml;
using System.ServiceModel.Syndication;
using System.Linq;
using System.Collections;


public class RSSFeed
{
    /// <summary>
    /// Returns the list of companies that have had no activity for a given number of days.
    /// Number of days is 5 by default if not passed as an argument.
    /// </summary>
    public Dictionary<string, IEnumerable<string>> ActivityTrackerRSS(Dictionary<string, IEnumerable<string>> companyRSSFeed, int numOfDays = 5)
    {
        Dictionary<string, IEnumerable<string>> inactiveCompanies = new Dictionary<string, IEnumerable<string>>();
        DateTime companypubDate;
        bool companyActivity;
       

        foreach (KeyValuePair <string, IEnumerable<string>> cmpyRSS in companyRSSFeed)
        {
            List<string> inactiveCompFeeds = new List<string>();
            foreach (string feedURL in cmpyRSS.Value)
            {
                //Get last publish date from company Feed
                companypubDate = ReadRSSFeed(feedURL);

                //Check if feed actvity is within activity day range
                companyActivity = CheckFeedActivity(companypubDate, numOfDays);

                //If company is Inactive, add it to the return list
                if (!companyActivity)
                {
                    inactiveCompFeeds.Add(feedURL);
                    
                }
            }

            //Add the Feed URLs to the list if inactive
            if (inactiveCompFeeds.Count > 0)
                inactiveCompanies.Add(cmpyRSS.Key, inactiveCompFeeds);
            
        }
           
        return inactiveCompanies;
    }

    /// <summary>
    /// Parse the current companies RSS Feed XML and find the latest publish date
    /// </summary>
    public DateTime ReadRSSFeed(string currURL)
    {
        XmlReader currentXML = XmlReader.Create(currURL);
        SyndicationFeed currentFeed = SyndicationFeed.Load(currentXML);
        currentXML.Close();

        var latestPost = currentFeed.Items.OrderByDescending(x => x.PublishDate).FirstOrDefault();
        DateTime pubDate = latestPost.PublishDate.DateTime;

        return pubDate;
    }

    /// <summary>
    /// Checks if the RSS Feed had posts in the last number of days provided as argument.
    /// Returns true if the Feed is Active
    /// </summary>   
    public bool CheckFeedActivity(DateTime activityDate, int numOfDays)
    {
        bool ifActiveFeed;
        System.TimeSpan dteDiff = DateTime.Now - activityDate;
        int daysSinceLastPost = dteDiff.Days;            

        if (daysSinceLastPost < numOfDays)
            ifActiveFeed = true;
        else
            ifActiveFeed = false;
        
        return ifActiveFeed;
    }
}
