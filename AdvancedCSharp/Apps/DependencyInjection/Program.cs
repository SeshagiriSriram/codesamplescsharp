using DependencyInjection; // our namespace...
using log4net;
using log4net.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Configuration;
using System.Reflection;
using ConfigurationManager = System.Configuration.ConfigurationManager;
// left as an excerise to clean this up :-) 

// CRUEL HACK FOR LOG4NET 
System.Text.Encoding.RegisterProvider(
    System.Text.CodePagesEncodingProvider.Instance);

/*foreach (string s in ConfigurationManager.AppSettings.AllKeys)
{
    System.Console.WriteLine("App Setting Key:"+s);
}
*/
var categoryName = typeof(Worker).FullName;
Console.WriteLine($"Expected logger category: {categoryName}");
// the default is to use app.exe.config 
log4net.Config.XmlConfigurator.Configure();
HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

// IOC Container 
// Spring IOC 
// pico 
// read Log4Net from Config sections... 

// Will now use our own logging.... 
// Toggle comments for above and below lines.. 
// Below is Log4Net provided by Apache and MS

 builder.Logging.ClearProviders();
//builder.Logging.AddConsole();
//builder.Logging.AddDebug(); 
builder.Logging.AddLog4Net("log4net.settings.xml"); 
//log4net.Util.LogLog.InternalDebugging = true;

// The below will inject
// IMessageWriter as well as ILogger 
// The injection of ILogger is already provided :-) 

builder.Services.AddHostedService<DependencyInjection.Worker>();
builder.Services.AddSingleton<IMessageWriter, DbMessageWriter>();

using IHost host = builder.Build();
// Start the application; 
host.Run();