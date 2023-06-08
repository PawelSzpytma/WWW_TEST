using DotVVM.Framework.Configuration;
using DotVVM.Framework.Controls.Bootstrap4;
using DotVVM.Framework.ResourceManagement;
using DotVVM.Framework.Routing;
using Microsoft.Extensions.DependencyInjection;
using WWW.Api;

namespace WWW
{
    public class DotvvmStartup : IDotvvmStartup, IDotvvmServiceConfigurator
    {
        // For more information about this class, visit https://dotvvm.com/docs/tutorials/basics-project-structure
        public void Configure(DotvvmConfiguration config, string applicationPath)
        {
            config.RegisterApiClient(typeof(ApiClient), "https://localhost:7153", "wwwroot/Scripts/ApiClient.js", "_ApiSelf");

            config.AddBootstrap4Configuration(new DotvvmBootstrapOptions
            {
                IncludeBootstrapResourcesInPage = false,
                IncludeJQueryResourceInPage = false
            });

            ConfigureRoutes(config, applicationPath);
            ConfigureControls(config, applicationPath);
            ConfigureResources(config, applicationPath);
        }

        private void ConfigureRoutes(DotvvmConfiguration config, string applicationPath)
        {
            config.RouteTable.Add("Default", "", "Views/Default.dothtml");
            config.RouteTable.Add("Page", "Page", "Views/Page.dothtml");
            config.RouteTable.AutoDiscoverRoutes(new DefaultRouteStrategy(config));    
        }

        private void ConfigureControls(DotvvmConfiguration config, string applicationPath)
        {
            config.Markup.AddCodeControls("self", typeof(WWW.Controls.ButtonSelf));
            config.Markup.AddMarkupControl("modal", "One", "Controls/ModalOne.dotcontrol");
            config.Markup.AddMarkupControl("modal", "Two", "Controls/ModalTwo.dotcontrol");
        }

        private void ConfigureResources(DotvvmConfiguration config, string applicationPath)
        {
            // register custom resources and adjust paths to the built-in resources
            config.Resources.Register("bootstrap-css", new StylesheetResource
            {
                Location = new UrlResourceLocation("~/lib/bootstrap/dist/css/bootstrap.min.css")
            });
            config.Resources.Register("bootstrap", new ScriptResource
            {
                Location = new UrlResourceLocation("~/lib/bootstrap/dist/js/bootstrap.bundle.min.js"),
                Dependencies = new[] { "bootstrap-css" , "jquery" }
            });
            config.Resources.Register("jquery", new ScriptResource
            {
                Location = new UrlResourceLocation("~/lib/jquery/jquery.min.js")
            });
            config.Resources.Register("Styles", new StylesheetResource()
            {
                Location = new UrlResourceLocation("~/Resources/style.css")
            });

            config.Resources.Register("moduleDlpro", new ScriptModuleResource(new UrlResourceLocation("~/Dotvvm.ExtendDlpro.js"))
            {
            });
        }

		public void ConfigureServices(IDotvvmServiceCollection options)
        {
            options.AddDefaultTempStorages("temp");
            options.AddBusinessPack(DotVVM.BusinessPack.BusinessPackTheme.Bootstrap4);
            options.AddHotReload();
		}
    }
}
