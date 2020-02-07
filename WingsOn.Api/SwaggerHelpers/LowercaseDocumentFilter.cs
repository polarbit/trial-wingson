using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WingsOn.Api.SwaggerHelpers
{
    public class LowercaseDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var newPaths = new OpenApiPaths();
            foreach (var path in swaggerDoc.Paths)
            {
                newPaths.Add(LowercaseEverythingButParameters(path.Key), path.Value);
            }

            swaggerDoc.Paths = newPaths;
        }

        private static string LowercaseEverythingButParameters(string key)
        {
            return string.Join('/', key.Split('/').Select(x => x.Contains("{") ? x : x.ToLower()));
        }
    }
}
