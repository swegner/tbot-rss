using System.IO;

namespace TbotRssService
{
    public class Utf8StringWriter : StringWriter
    {
        public override System.Text.Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }
}