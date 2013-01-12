using System.Configuration;

namespace TbotRssService.Configuration
{
    public class AuthorCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new AuthorElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((AuthorElement)element).Name;
        }
    }
}