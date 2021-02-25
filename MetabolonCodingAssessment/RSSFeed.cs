using System;
using System.Collections.Generic;
using System.Xml;
using System.ServiceModel.Syndication;
using System.Linq;


public class RSSFeed
{
    /// <summary>
    /// Returns the list of companies that have had no activity for a given number of days.
    /// Number of days is 5 by default if not passed as an argument.
    /// </summary>
    public List<string> ActivityTrackerRSS(Dictionary<string, string> companyRSSFeed, int numOfDays = 5)
    {
        List<string> inactiveCompanies = new List<string>();
        return inactiveCompanies;
    }

    /// <summary>
    /// Parse the current companies RSS Feed XML and find the latest publish date
    /// </summary>
    public void ReadRSSFeed(string currURL)
    {
        XmlReader currentXML = XmlReader.Create(currURL);
        SyndicationFeed currentFeed = SyndicationFeed.Load(currentXML);
        currentXML.Close();

        var post = currentFeed.Items.OrderByDescending(x => x.PublishDate).FirstOrDefault();
        DateTime pubDate = post.PublishDate.DateTime;

    }
}
