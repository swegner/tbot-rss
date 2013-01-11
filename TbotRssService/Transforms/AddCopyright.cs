using System.Linq;
using System.ServiceModel.Syndication;
using TbotRssService.Configuration;

namespace TbotRssService.Transforms
{
    public class AddCopyright : ISyndicationFeedVisitor
    {
        public void TransformFeed(SyndicationFeed feed, SyndicationVisitorContext context)
        {
            string copyright = string.Join(" & ", context.Config.Authors
                .Cast<AuthorElement>()
                .Select(a => a.Name));
            feed.Copyright = new TextSyndicationContent(copyright);
        }
    }
}