using System.ServiceModel.Syndication;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace TbotRssService.Transforms
{
    public class HtmlRemover : ISyndicationItemVisitor
    {
        private static readonly XNamespace ItunesNS = "http://www.itunes.com/dtds/podcast-1.0.dtd";

        public void TransformItem(SyndicationItem item)
        {
            string strippedSummary = Regex.Replace(item.Summary.Text, @"<[^>]+>", string.Empty);
            item.Summary = new TextSyndicationContent(strippedSummary);
        }
    }
}