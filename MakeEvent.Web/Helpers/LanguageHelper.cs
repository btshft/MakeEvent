using System.Threading;
using MakeEvent.Business.Enums;

namespace MakeEvent.Web.Helpers
{
    public static class LanguageHelper
    {
        public static CultureLanguage? GetThreadLanguage()
        {
            var language = Thread.CurrentThread.CurrentCulture.IetfLanguageTag;
            switch (language.ToUpper())
            {
                case "RU": return CultureLanguage.RU;
                case "EN": return CultureLanguage.EN;
                default: return null;
            }
        }
    }
}