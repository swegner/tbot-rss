namespace TbotRssService.Transforms
{
    using System.Linq;
    using System.ServiceModel.Syndication;

    public class FixupGuid : ISyndicationItemVisitor
    {
        public void TransformItem(SyndicationItem item, SyndicationVisitorContext context)
        {
            string guid = item.Links
                .Where(l => l.RelationshipType == "alternate")
                .Select(l => l.Uri.AbsoluteUri)
                .FirstOrDefault();

            if (guid != null)
            {
                item.Id = guid;
            }
        }
    }
}