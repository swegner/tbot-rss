namespace TbotRssService.Transforms
{
    using System.Linq;
    using System.ServiceModel.Syndication;

    public class ReplaceLink : ISyndicationFeedVisitor
    {
        public void TransformFeed(SyndicationFeed feed, SyndicationVisitorContext context)
        {
            if (feed.Links.Any())
            {
                feed.Links[0] = new SyndicationLink(context.RssUrl, "alternate", title: null, mediaType: null, length: 0);
            }
        }
    }
}