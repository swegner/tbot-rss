using System.Configuration;

namespace TbotRssService.Configuration
{ 
    public class TbotSection : ConfigurationSection
    {
        private const string AuthorsXmlKey = "authors";

        [ConfigurationProperty(AuthorsXmlKey)]
        public AuthorCollection Authors
        {
            get { return (AuthorCollection) this[AuthorsXmlKey]; }
        }
    }
}