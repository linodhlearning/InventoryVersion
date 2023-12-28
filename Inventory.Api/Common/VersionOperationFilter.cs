using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Inventory.Api.Common
{
    public class VersionGetOperationFilter : IOperationFilter
    {
        private static List<string> VersionStrings = new List<string> { "version", "x-api-version", "api-version" };
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.ApiDescription.HttpMethod == "GET")
            {
                var versionParameters = operation.Parameters.Where(x => VersionStrings.Contains(x.Name.ToLower()));
                foreach (var param in versionParameters)
                {
                    param.Required = false;
                }
                return;
            }
        }
    }
}
