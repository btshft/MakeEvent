using System.IO;

namespace MakeEvent.Web.Extensions
{
    public static class StreamExtensions
    {
        public static byte[] AsBytes(this Stream stream)
        {
            using (var ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}