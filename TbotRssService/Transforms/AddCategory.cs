namespace TbotRssService.Transforms
{
    using System.ServiceModel.Syndication;
    using System.Xml.Linq;

    public class AddCategory : ISyndicationFeedVisitor
    {
        public void TransformFeed(SyndicationFeed feed, SyndicationVisitorContext context)
        {
            feed.ElementExtensions.Add(new XElement(Constants.ItunesNS + "category", new XAttribute("text", "Technology")));
        }
    }
}