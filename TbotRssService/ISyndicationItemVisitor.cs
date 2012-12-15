using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;

namespace TbotRssService
{
    public interface ISyndicationItemVisitor
    {
        void TransformItem(SyndicationItem item);
    }
}