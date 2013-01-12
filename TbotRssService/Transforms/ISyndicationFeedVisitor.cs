using System.ServiceModel.Syndication;
using TbotRssService.Transforms;

namespace TbotRssService
{
    public interface ISyndicationFeedVisitor
    {
        void TransformFeed(SyndicationFeed feed, SyndicationVisitorContext context);
    }
}