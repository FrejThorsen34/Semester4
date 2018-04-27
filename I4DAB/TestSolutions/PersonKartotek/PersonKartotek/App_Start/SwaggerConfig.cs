using System.Web.Http;
using WebActivatorEx;
using PersonKartotek;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace PersonKartotek
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration 
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "PersonKartotek");
                        c.IncludeXmlComments(string.Format(@"{0}\bin\PersonKartotek.xml", System.AppDomain.CurrentDomain.BaseDirectory));
                    })
                .EnableSwaggerUi(c =>
                    {
                        
                    });
        }
    }
}