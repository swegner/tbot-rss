using System.ServiceModel.Syndication;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace TbotRssService.Transforms
{
    public class RemoveHtml : ISyndicationItemVisitor
    {
        public void TransformItem(SyndicationItem item, SyndicationVisitorContext context)
        {
            string strippedSummary = Regex.Replace(item.Summary.Text, @"<[^>]+>", string.Empty);
            item.Summary = new TextSyndicationContent(strippedSummary);
        }
    }
}