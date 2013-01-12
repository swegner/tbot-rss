using System.Configuration;

namespace TbotRssService.Configuration
{
    public class AuthorElement : ConfigurationElement
    {
        private const string NameXmlKey = "name";

        [ConfigurationProperty(NameXmlKey)]
        public string Name
        {
            get { return (string)this[NameXmlKey]; }
        }
    }
}