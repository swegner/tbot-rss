using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;

namespace TbotRssService
{
    public interface ISyndicationFeedVisitor
    {
        void TransformFeed(SyndicationFeed feed);
    }
}