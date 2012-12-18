using System.Linq;
using System.ServiceModel.Syndication;

namespace TbotRssService.Transforms
{
    public class ReplaceLink : ISyndicationFeedVisitor
    {
        public void TransformFeed(SyndicationFeed feed, SyndicationVisitorContext context)
        {
            feed.BaseUri = context.RssUrl;
            if (feed.Links.Any())
            {
                feed.Links[0] = new SyndicationLink(context.RssUrl);
            }
        }
    }
}