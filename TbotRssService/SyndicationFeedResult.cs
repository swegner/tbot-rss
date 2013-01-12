using System.IO;
using System.ServiceModel.Syndication;
using System.Text;
using System.Web.Mvc;
using System.Xml;

namespace TbotRssService
{
    public class SyndicationFeedResult : ContentResult
    {
        public SyndicationFeedResult(SyndicationFeed feed)
        {
            this.ContentType = "application/rss+xml";

            using (StringWriter stringWriter = new Utf8StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(stringWriter, new XmlWriterSettings
                {
                    Indent = true,
                    ConformanceLevel = ConformanceLevel.Document,
                    CheckCharacters = true,
                    NamespaceHandling = NamespaceHandling.OmitDuplicates,
                    OmitXmlDeclaration = false,
                    Encoding = Encoding.UTF8,
                }))
                {
                    Rss20FeedFormatter formatter = feed.GetRss20Formatter(serializeExtensionsAsAtom: false);
                    formatter.PreserveAttributeExtensions = true;
                    formatter.PreserveAttributeExtensions = true;
                    formatter.WriteTo(writer);
                }

                this.Content = stringWriter.ToString();
            }
        }
    }
}