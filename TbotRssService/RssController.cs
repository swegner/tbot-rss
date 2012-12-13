using System;
using System.ServiceModel.Syndication;
using System.Web.Http;

namespace TbotRssService
{
    public class RssController : ApiController
    {
         public SyndicationFeed Get()
         {
             SyndicationFeed feed = new SyndicationFeed("title", "description", new Uri("http://alternativeLink"), "id",
                                                        new DateTimeOffset(DateTime.Now));
             feed.Items = new[]
                 {
                     new SyndicationItem("item title", "content", new Uri("http://alternativeLink/content"), "contentId",
                                         new DateTimeOffset(DateTime.Now)),
                 };
             return feed;
         }
    }
}