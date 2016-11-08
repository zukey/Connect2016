using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace PictureStampRally.WebApi.Models
{
    public class ThemeImageRegistOparationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            operation.consumes.Add("multipart/form-data");
            operation.parameters = new[]
            {
                new Parameter
                {
                    name = "file",
                    @in = "formData",
                    required = true,
                    type = "file",
                    description = "アップロードするファイル"
                },
                new Parameter
                {
                    name = "eventId",
                    @in = "formData",
                    required = true,
                    type = "integer",
                    description = "イベントID"
                },
                new Parameter
                {
                    name = "hintAddr",
                    @in = "formData",
                    required = true,
                    type = "string",
                    description = "だいたいの場所"
                }
            };
        }
    }
}