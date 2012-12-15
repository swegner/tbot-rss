using System;
using System.IO;
using System.Reflection;
using System.ServiceModel.Syndication;
using System.Web.Http;
using System.Web.Mvc;
using System.Xml;

namespace TbotRssService
{
    public class RssController : Controller
    {
         public SyndicationFeedResult Feed()
         {
             SyndicationFeed feed = this.LoadFeed();

             return new SyndicationFeedResult(feed);
         }

         private SyndicationFeed LoadFeed()
         {
             SyndicationFeed feed;

             string executingDirectory = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);
             string sampleDataFile = Path.Combine(executingDirectory, "sample-data.txt");
             using (FileStream fileStream = System.IO.File.OpenRead(sampleDataFile))
             using (XmlReader reader = new XmlTextReader(fileStream))
             {
                 feed = SyndicationFeed.Load(reader);
             }

             return feed;
         }
    }
}