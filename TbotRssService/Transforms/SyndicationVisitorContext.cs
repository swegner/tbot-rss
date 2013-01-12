using System;
using TbotRssService.Configuration;

namespace TbotRssService.Transforms
{
    public class SyndicationVisitorContext
    {
        public Uri RssUrl { get; set; }
        public TbotSection Config { get; set; }
    }
}