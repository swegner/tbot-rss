using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.ServiceModel.Syndication;
using System.Web.Http;
using System.Web.Mvc;
using System.Xml;
using TbotRssService.Transforms;

namespace TbotRssService
{
    public class RssController : Controller
    {
        private static readonly IEnumerable<ISyndicationFeedVisitor> FeedVisitors = new ISyndicationFeedVisitor[]
        {
            new AddCopyright(), 
            new ReplaceLink(),
        };

        private static readonly IEnumerable<ISyndicationItemVisitor> ItemVisitors = new[]
        {
            new RemoveHtml(),
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