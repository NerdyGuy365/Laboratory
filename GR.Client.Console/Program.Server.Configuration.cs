using System.Net.Http.Headers;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using Owin;

namespace GR.Client.Console
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            config.Routes.MapHttpRoute("DefaultApi",
                "{controller}",
                new { id = RouteParameter.Optional });

            config.Routes.MapHttpRoute("ActionApi",
                "{controller}/{action}",
                new { id = RouteParameter.Optional });

            // clear the supported mediatypes of the xml formatter
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));

            // configure caching
            app.UseWebApi(config);
        }
    }
}
