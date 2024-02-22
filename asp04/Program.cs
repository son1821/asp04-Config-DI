using asp04.Middleware;
using asp04.Options;
using asp04.Service;
using Microsoft.Extensions.Options;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
//dang ky dich vu
builder.Services.AddTransient<TestOptionsMiddleware>();
builder.Services.AddSingleton<ProductName>();
builder.Services.AddOptions();
var testoptions = builder.Configuration.GetSection("TestOptions");

builder.Services.Configure<TestOptions>(testoptions);

//return IOptions<TestOptions>



var app = builder.Build();

app.UseMiddleware<TestOptionsMiddleware>();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/ShowOptions", async context =>
    {
        var testOptions = context.RequestServices.GetRequiredService<IOptions<TestOptions>>().Value;
        

      //var configuration =   context.RequestServices.GetService<IConfiguration>();
      // var testOptions  = configuration.GetSection("TestOptions").Get<TestOptions>();
       
        //var opt_key1 = testOptions["opt_key1"];
       //var k1 =  testOptions.GetSection("opt_key2")["k1"];
       //var k2 =  testOptions.GetSection("opt_key2")["k2"];

       //var stringBuilder = new StringBuilder();
       // stringBuilder.Append("TESTOPTIONS\n");
       // stringBuilder.Append($"opt_key1 = {testOptions.opt_key1} \n ");
       // stringBuilder.Append($"TestOptions.opt_key2.k1 = {testOptions.opt_key2.k1}\n");
       // stringBuilder.Append($"TestOptions.opt_key2.k2 = {testOptions.opt_key2.k2}\n");
        
        await context.Response.WriteAsync("Show Options");


    });
});

app.Run();
