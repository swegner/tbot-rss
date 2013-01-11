namespace TbotRssService.Transforms
{
    using System.ServiceModel.Syndication;

    public class AddIsClosedCaptioned : ISyndicationItemVisitor
    {
        public void TransformItem(SyndicationItem item, SyndicationVisitorContext context)
        {
            item.ElementExtensions.Add("isClosedCaptioned", Constants.ItunesNS.NamespaceName, "no");
        }
    }
}