using System.ServiceModel.Syndication;
using TbotRssService.Transforms;

namespace TbotRssService
{
    public interface ISyndicationItemVisitor
    {
        void TransformItem(SyndicationItem item, SyndicationVisitorContext context);
    }
}