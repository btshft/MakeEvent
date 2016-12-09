using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MakeEvent.Web.Helpers
{
    public static class HashHelper
    {
        public static string GetSha1Hash(string value)
        {
            var sha1 = new SHA1Managed();
            var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(value));
            var parts = hash.Select(b => b.ToString("x2"));

            return string.Join("", parts);
        }
    }
}