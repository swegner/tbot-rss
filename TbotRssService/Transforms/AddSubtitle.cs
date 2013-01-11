namespace TbotRssService.Transforms
{
    using System.ServiceModel.Syndication;

    public class AddSubtitle : ISyndicationFeedVisitor
    {
        public void TransformFeed(SyndicationFeed feed, SyndicationVisitorContext context)
        {
            feed.ElementExtensions.Add("subtitle", Constants.ItunesNS.NamespaceName, "Technology Business Analysis - Going beyond the headlines");
        }
    }
}