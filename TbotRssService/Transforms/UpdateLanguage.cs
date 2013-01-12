namespace TbotRssService.Transforms
{
    using System.ServiceModel.Syndication;

    public class UpdateLanguage : ISyndicationFeedVisitor
    {
        public void TransformFeed(SyndicationFeed feed, SyndicationVisitorContext context)
        {
            feed.Language = "en-us";
        }
    }
}