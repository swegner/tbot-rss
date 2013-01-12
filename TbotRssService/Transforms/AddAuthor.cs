namespace TbotRssService.Transforms
{
    using System.ServiceModel.Syndication;
    using TbotRssService.Configuration;

    public class AddAuthor : ISyndicationFeedVisitor, ISyndicationItemVisitor
    {
        public void TransformFeed(SyndicationFeed feed, SyndicationVisitorContext context)
        {
            this.AddAuthorElement(feed.ElementExtensions, context);
        }

        public void TransformItem(SyndicationItem item, SyndicationVisitorContext context)
        {
            this.AddAuthorElement(item.ElementExtensions, context);
        }

        private void AddAuthorElement(SyndicationElementExtensionCollection elementExtensions, SyndicationVisitorContext context)
        {
            elementExtensions.Add("author", Constants.ItunesNS.NamespaceName, context.Config.Authors.GetAuthorsString());
        }
    }
}