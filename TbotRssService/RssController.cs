using System;
using System.ServiceModel.Syndication;
using System.Web.Http;
using System.Web.Mvc;

namespace TbotRssService
{
    public class RssController : Controller
    {
         public SyndicationFeedResult Feed()
         {
             SyndicationFeed feed = new SyndicationFeed("title", "description", new Uri("http://alternativeLink"), "id", new DateTimeOffset(DateTime.Now))
             {
                Items = new[]
                {
                    new SyndicationItem("item title", "content", new Uri("http://alternativeLink/content"), "contentId", new DateTimeOffset(DateTime.Now)),
                }
             };

             return new SyndicationFeedResult(feed);
         }
    }
}