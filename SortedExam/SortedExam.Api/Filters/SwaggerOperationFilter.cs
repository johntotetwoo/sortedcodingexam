using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SortedExam.Api.Filters
{
    public class SwaggerOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var attributes = context.MethodInfo.DeclaringType?.GetCustomAttributes(true)
                .Union(context.MethodInfo.GetCustomAttributes(true));
            if (attributes != null)
            {
                var swaggerOperationAttribute = attributes.FirstOrDefault(a => a.GetType() == typeof(SwaggerOperationAttribute)) as SwaggerOperationAttribute;

                if (swaggerOperationAttribute != null)
                {
                    operation.Summary = swaggerOperationAttribute.Summary;
                    operation.Description = swaggerOperationAttribute.Description;

                    // Convert string array to list of OpenApiTag objects
                    if (swaggerOperationAttribute.Tags != null && swaggerOperationAttribute.Tags.Length > 0)
                    {
                        operation.Tags = swaggerOperationAttribute.Tags
                            .Select(tagName => new OpenApiTag { Name = tagName })
                            .ToList<OpenApiTag>();
                    }
                }
            }
        }
    }
}
