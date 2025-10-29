using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace WebAPIProject.Controllers
{
    public class MyMessage
    {
        public string Text { get; set; } = String.Empty;
    }
    [ApiController]
    [Route("[controller]")]
    public class TestController(ILogger<WeatherForecastController> logger, IConfiguration configuration, SQLServerContext context) : ControllerBase
    {
        private const string V = "select @@version";
        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        private readonly ILogger<WeatherForecastController> _logger = logger;
        private readonly IConfiguration _configuration = configuration;
        private readonly SQLServerContext _context = context;  
        [HttpGet(Name = "GetTestMessage")]
        //[Produces("application/json")]
        //[Produces("text/html")]
        //public IOptions<MySettings> Get()
        //public async Task<OkObjectResult> Get()
        public ContentResult Get()
        {
            var fs = FormattableStringFactory.Create(V);
            //MyMessage p = new MyMessage(); 
            //p.Text= "Hello, this is a test message.";
            //return p; 
            //dynamic json = JsonConvert.DeserializeObject(str);
            //return json;
            //return "{\"objects\":[{\"id\":1,\"title\":\"Book\",\"position_x\":0,\"position_y\":0,\"position_z\":0,\"rotation_x\":0,\"rotation_y\":0,\"rotation_z\":0,\"created\":\"2016-09-21T14:22:22.817Z\"},{\"id\":2,\"title\":\"Apple\",\"position_x\":0,\"position_y\":0,\"position_z\":0,\"rotation_x\":0,\"rotation_y\":0,\"rotation_z\":0,\"created\":\"2016-09-21T14:22:52.368Z\"}]}"; 
            //return _settings;  
            //return _context.Blogs.
            //var items = await _context.Blogs.ToListAsync();
            //var items = _context.ContextId.ToString() + "--" + _context.ConnectionString; 
            var items = _context.Database.SqlQuery<string>(fs).ToList();
             
            //return Ok(items);
            //return base.Content(items??"Cannot find SQL Server Version", "text/html");
            return new ContentResult
            {
                Content = $"<html><script src=\"/_framework/aspnetcore-browser-refresh.js\"></script>'<body>{string.Join("<br/>", items).Replace("Microsoft SQL Server 2019", "<b>Microsoft SQL Server 2019</b>")}</body>",
                ContentType = "text/html"
            };
        }
    }
}
