namespace TbotRssService.Transforms
{
    using System;
    using System.ServiceModel.Syndication;
    using System.Xml.Linq;

    public class AddImage : ISyndicationFeedVisitor, ISyndicationItemVisitor
    {
        private static readonly Uri ImageUrl = new Uri("http://businessoftech.com/sites/all/themes/blueprint/images/logo.png");

        public void TransformFeed(SyndicationFeed feed, SyndicationVisitorContext context)
        {
            feed.ImageUrl = ImageUrl;
            this.AddItunesImage(feed.ElementExtensions);
        }

        public void TransformItem(SyndicationItem item, SyndicationVisitorContext context)
        {
            this.AddItunesImage(item.ElementExtensions);
        }

        private void AddItunesImage(SyndicationElementExtensionCollection extensions)
        {
            extensions.Add(new XElement(Constants.ItunesNS +"image", new XAttribute("href", ImageUrl.AbsoluteUri)));
        }
    }
}