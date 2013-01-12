namespace TbotRssService.Transforms
{
    using System.Linq;
    using System.ServiceModel.Syndication;
    using System.Xml.Linq;

    using TbotRssService.Configuration;

    public class FixupOwner : ISyndicationFeedVisitor
    {
        public void TransformFeed(SyndicationFeed feed, SyndicationVisitorContext context)
        {
            SyndicationElementExtensionCollection extensions = feed.ElementExtensions;
            SyndicationElementExtension original = extensions
                .Where(e => e.OuterName == "owner")
                .FirstOrDefault();

            if (original != null)
            {
                XElement emailElement = original.GetObject<XElement>().Element(Constants.ItunesNS + "email");
                SyndicationElementExtension newOwnerElement = new SyndicationElementExtension(
                    new XElement(Constants.ItunesNS + "owner", new object[]
                    {
                        emailElement,
                        new XElement(Constants.ItunesNS + "name", context.Config.Authors.GetAuthorsString())
                    }));

                extensions.Remove(original);
                extensions.Add(newOwnerElement);
            }
        }
    }
}