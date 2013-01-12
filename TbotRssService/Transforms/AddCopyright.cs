namespace TbotRssService.Transforms
{
    using System.ServiceModel.Syndication;

    using TbotRssService.Configuration;

    public class AddCopyright : ISyndicationFeedVisitor
    {
        public void TransformFeed(SyndicationFeed feed, SyndicationVisitorContext context)
        {
            feed.Copyright = new TextSyndicationContent(context.Config.Authors.GetAuthorsString());
        }
    }
}