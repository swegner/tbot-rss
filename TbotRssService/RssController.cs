namespace TbotRssService
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Reflection;
    using System.ServiceModel.Syndication;
    using System.Threading.Tasks;
    using System.Web.Configuration;
    using System.Web.Mvc;
    using System.Xml;

    using TbotRssService.Configuration;
    using TbotRssService.Transforms;

    public class RssController : AsyncController
    {
        private static readonly IEnumerable<ISyndicationFeedVisitor> FeedVisitors = new ISyndicationFeedVisitor[]
        {
            new AddAuthor(), 
            new AddCategory(), 
            new AddCopyright(), 
            new AddImage(), 
            new AddSubtitle(), 
            new AddSummary(), 
            new FixupOwner(), 
            new RemoveXmlBase(), 
            new ReplaceLink(),
            new UpdateLanguage(), 
        };

        private static readonly IEnumerable<ISyndicationItemVisitor> ItemVisitors = new ISyndicationItemVisitor[]
        {
            new AddAuthor(), 
            new AddImage(), 
            new AddIsClosedCaptioned(), 
            new ClearSubtitle(), 
            new RemoveHtml(),
            new RemoveXmlBase(), 
        };

        /// <summary>
        /// Main controller method. Transform the RSS feed and serve the result.
        /// </summary>
        /// <returns>The transformed RSS feed.</returns>
        [OutputCache(CacheProfile = "RssCache")]
        public async Task<SyndicationFeedResult> Feed()
        {
            SyndicationFeed feed = await this.LoadFeed();

            this.TransformFeed(feed);

            return new SyndicationFeedResult(feed);
        }
        
        private async Task<SyndicationFeed> LoadFeed()
        {
            SyndicationFeed feed;

            using (WebClient wc = new WebClient())
            using (Stream stream = await wc.OpenReadTaskAsync(new Uri("http://businessoftech.com/podcast/feed/1")))
            using (XmlReader reader = XmlReader.Create(stream, new XmlReaderSettings
            {
                CheckCharacters = true,
            }))
            {
                feed = SyndicationFeed.Load(reader);
            }

            feed.AttributeExtensions.Add(new XmlQualifiedName("itunes", "http://www.w3.org/2000/xmlns/"), Constants.ItunesNS.NamespaceName);

            return feed;
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
    }
}