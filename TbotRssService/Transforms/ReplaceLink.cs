using System.Linq;
using System.ServiceModel.Syndication;

namespace TbotRssService.Transforms
{
    public class ReplaceLink : ISyndicationFeedVisitor
    {
        public void TransformFeed(SyndicationFeed feed, SyndicationVisitorContext context)
        {
            // TODO: Separate BaseUri
            feed.BaseUri = null;
            if (feed.Links.Any())
            {
                feed.Links[0] = new SyndicationLink(context.RssUrl, "alternate", title: null, mediaType: null, length: 0);
            }
        }
    }
}