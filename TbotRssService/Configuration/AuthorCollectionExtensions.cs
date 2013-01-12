namespace TbotRssService.Configuration
{
    using System.Linq;

    /// <summary>
    /// Extension methods for working with <see cref="AuthorCollection"/>s.
    /// </summary>
    public static class AuthorCollectionExtensions
    {
        public static string GetAuthorsString(this AuthorCollection @this)
        {
            string authors = string.Join(" & ", @this.Cast<AuthorElement>().Select(a => a.Name));
            return authors;
        }
    }
}