namespace TbotRssService.Transforms
{
    using System.Linq;
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
            SyndicationElementExtensionCollection extensions = item.ElementExtensions;
            SyndicationElementExtension original = extensions
                .Where(e => e.OuterName == "author")
                .FirstOrDefault();
            if (original != null)
            {
                extensions.Remove(original);
            }

            this.AddAuthorElement(extensions, context);
        }

        private void AddAuthorElement(SyndicationElementExtensionCollection elementExtensions, SyndicationVisitorContext context)
        {
            elementExtensions.Add("author", Constants.ItunesNS.NamespaceName, context.Config.Authors.GetAuthorsString());
        }
    }
}