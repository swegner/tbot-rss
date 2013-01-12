namespace TbotRssService.Transforms
{
    using System.ServiceModel.Syndication;

    public class RemoveXmlBase : ISyndicationFeedVisitor, ISyndicationItemVisitor
    {
        public void TransformFeed(SyndicationFeed feed, SyndicationVisitorContext context)
        {
            feed.BaseUri = null;
        }

        public void TransformItem(SyndicationItem item, SyndicationVisitorContext context)
        {
            item.BaseUri = null;
        }
    }
}