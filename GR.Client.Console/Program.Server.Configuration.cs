using System.Net.Http.Headers;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using Owin;

namespace GR.Client.Console
{
    /// <summary>
    /// The purpose of this class is to configure our REST service.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// The purpose of this method is to setup routing and support media formats.
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            //Setup our default routing system.
            config.Routes.MapHttpRoute("DefaultApi",
                "{controller}",
                new { id = RouteParameter.Optional });

            //This is the pattern of our action calls.
            config.Routes.MapHttpRoute("ActionApi",
                "{controller}/{action}",
                new { id = RouteParameter.Optional });

            //We don't want to support xml..so...clear the supported mediatypes of the xml formatter
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            //We want to support JSON calls.
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));

            //Set configuration.
            app.UseWebApi(config);
        }
    }
}
