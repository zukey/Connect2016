using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace PictureStampRally.WebApi.Models
{
    public class ThemeImageFileDownloadOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            //operation.parameters = new[]
            //{
            //    new Parameter
            //    {
            //        name = "eventId",
            //        @in = "path",
            //        required = true,
            //        type = "integer",
            //        description = "イベントID"
            //    },
            //    new Parameter
            //    {
            //        name = "themeImageId",
            //        @in = "path",
            //        required = true,
            //        type = "integer",
            //        description = "イメージID"
            //    },
            //};
            operation.produces = new[] { "application/octet-stream" };
            operation.responses["200"].schema = new Schema { type = "file" };
        }
    }
}