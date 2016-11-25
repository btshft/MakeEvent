using System.Linq;
using System.Web.Http.ModelBinding;
using Kendo.Mvc.UI;

namespace MakeEvent.Web.Extensions
{
    public static class ModelStateDictionaryExtensions
    {
        public static DataSourceResult ToDataSourceResult(this ModelStateDictionary modelState)
        {
            if (modelState.IsValid)
                return new DataSourceResult { };

            var errors = new DataSourceResult
            {
                Errors = modelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
            };
            return errors;
        }
    }
}