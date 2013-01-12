namespace TbotRssService.Transforms
{
    using System.Linq;
    using System.ServiceModel.Syndication;

    public class ClearSubtitle : ISyndicationItemVisitor
    {
        public void TransformItem(SyndicationItem item, SyndicationVisitorContext context)
        {
            SyndicationElementExtensionCollection extensions = item.ElementExtensions;
            SyndicationElementExtension subtitle = extensions
                .Where(e => e.OuterName == "subtitle")
                .FirstOrDefault();

            if (subtitle != null)
            {
                extensions.Remove(subtitle);
            }
        }
    }
}