using System.IO;
using System.ServiceModel.Syndication;
using System.Web.Mvc;
using System.Xml;

namespace TbotRssService
{
    public class SyndicationFeedResult : ContentResult
    {
        public SyndicationFeedResult(SyndicationFeed feed)
        {
            this.ContentType = "application/rss+xml";

            using (TextWriter tWriter = new StringWriter())
            {
                using (XmlTextWriter writer = new XmlTextWriter(tWriter)
                {
#if (DEBUG)
                    Formatting = Formatting.Indented
#endif
                })
                {
                    feed.SaveAsRss20(writer);
                }

                this.Content = tWriter.ToString();
            }
        }
    }
}