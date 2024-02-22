using asp04.Options;
using asp04.Service;
using Microsoft.Extensions.Options;
using System.Text;

namespace asp04.Middleware
{
    public class TestOptionsMiddleware : IMiddleware
    {
        ProductName productName {  get; set; }
        TestOptions _testOptions {  get; set; }
        public TestOptionsMiddleware(IOptions<TestOptions> options, ProductName product) { 
        
        _testOptions = options.Value;
        productName = product;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Show options in TestOptionsMiddleware\n");
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("TESTOPTIONS\n");
            stringBuilder.Append($"opt_key1 = {_testOptions.opt_key1} \n ");
            stringBuilder.Append($"TestOptions.opt_key2.k1 = {_testOptions.opt_key2.k1}\n");
            stringBuilder.Append($"TestOptions.opt_key2.k2 = {_testOptions.opt_key2.k2}\n");
            foreach (var prdName in productName.GetNames())
            {
                stringBuilder.Append(prdName + "\n");
            }
            await context.Response.WriteAsync(stringBuilder.ToString());
            await next(context);

            

        }
    }
}
