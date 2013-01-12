namespace TbotRssService.Transforms
{
    using System.ServiceModel.Syndication;

    public class AddSummary : ISyndicationFeedVisitor
    {
        public const string SummaryText = "Stay up to date with the latest tech news and dive deeper than the headlines with The Busines of Tech Podcast.";

        public void TransformFeed(SyndicationFeed feed, SyndicationVisitorContext context)
        {
            feed.ElementExtensions.Add("summary", Constants.ItunesNS.NamespaceName, SummaryText);
        }
    }
}