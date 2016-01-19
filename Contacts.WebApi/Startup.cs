using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Contacts.Repository;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Formatters;

namespace Contacts
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      //MvcCore - basic package needed for MVC 6 Web API
      //services.AddMvcCore()
      //        .AddJsonFormatters(a => a.ContractResolver = new CamelCasePropertyNamesContractResolver());

      services.Configure<MvcOptions>(options =>
      {
        // options.AddXmlDataContractSerializerFormatter();
        options.RespectBrowserAcceptHeader = true;
        options.InputFormatters.Add(new JsonInputFormatter());
        options.InputFormatters.Add(new XmlSerializerInputFormatter());
        options.OutputFormatters.Add(new JsonOutputFormatter());
        options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
        options.OutputFormatters.Add(new StringOutputFormatter());
      });
      services.AddMvc();

      //using Dependency Injection
      services.AddSingleton<IContactRepository, ContactRepository>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app)
    {
      app.UseIISPlatformHandler();
      app.UseMvc();
    }

    // Entry point for the application.
    public static void Main(string[] args) => WebApplication.Run<Startup>(args);
  }
}
