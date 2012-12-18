using System;
using System.ServiceModel.Syndication;

namespace TbotRssService.Transforms
{
    public class AddCopyright : ISyndicationFeedVisitor
    {
        public void TransformFeed(SyndicationFeed feed, SyndicationVisitorContext context)
        {
            feed.Copyright = new TextSyndicationContent("Kyle Wegner & Jerelle Gainey");
        }
    }
}