using System.Web.Http;

namespace TbotRssService
{
    public class RssController : ApiController
    {
         public string Get()
         {
             return "my feed";
         }
    }
}