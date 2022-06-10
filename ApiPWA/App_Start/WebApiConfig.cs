using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using ApiPWA;

namespace ApiPWA
{
    public static class WebApiConfig
    {
      
        public static void Register(HttpConfiguration config)
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<users>("users1");
            builder.EntitySet<briefcase>("briefcase");
            builder.EntitySet<certifications>("certifications");
            builder.EntitySet<skills>("skills");
            builder.EntitySet<work_experience>("work_experience");
            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                
           
            );
        }
    }
}
