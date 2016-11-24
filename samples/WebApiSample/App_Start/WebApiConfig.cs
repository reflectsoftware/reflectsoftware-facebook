using System.Web.Http;

namespace WebApiSample.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();            
        }
    }
}
