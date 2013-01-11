using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.ServiceModel.Syndication;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Schema;
using TbotRssService.Configuration;
using TbotRssService.Transforms;

namespace TbotRssService
{
    public class RssController : Controller
    {
        private static readonly IEnumerable<ISyndicationFeedVisitor> FeedVisitors = new ISyndicationFeedVisitor[]
        {
            new AddCopyright(), 
            new ReplaceLink(),
            new AddAuthor(), 
        };

        private static readonly IEnumerable<ISyndicationItemVisitor> ItemVisitors = new ISyndicationItemVisitor[]
        {
            new RemoveHtml(),
            new AddAuthor(), 
        };

         public SyndicationFeedResult Feed()
         {
             SyndicationFeed feed = this.LoadFeed();

             this.TransformFeed(feed);

             return new SyndicationFeedResult(feed);
         }

         private void TransformFeed(SyndicationFeed feed)
         {
             SyndicationVisitorContext context = new SyndicationVisitorContext
             {
                RssUrl = new Uri(this.Url.Action("Feed", "Rss", null, this.Request.Url.Scheme)),
                Config = (TbotSection)WebConfigurationManager.GetSection("tbotSection"),
             };

             foreach (ISyndicationFeedVisitor feedVisitor in RssController.FeedVisitors)
             {
                 feedVisitor.TransformFeed(feed, context);
             }

             foreach (var item in feed.Items)
             {
                 foreach (ISyndicationItemVisitor itemVisitor in RssController.ItemVisitors)
                 {
                     itemVisitor.TransformItem(item, context);
                 }
             }
         }

         private SyndicationFeed LoadFeed()
         {
             SyndicationFeed feed;

             string executingDirectory = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);
             string sampleDataFile = Path.Combine(executingDirectory, "sample-data.xml");
             using (FileStream fileStream = System.IO.File.OpenRead(sampleDataFile))
             using (XmlReader reader = XmlReader.Create(fileStream, new XmlReaderSettings
             {
                 CheckCharacters = true,
             }))
             {
                 feed = SyndicationFeed.Load(reader);
             }

             return feed;
         }
    }
}