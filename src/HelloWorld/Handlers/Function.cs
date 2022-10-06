using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;

using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using HelloWorld.Interfaces;
using Microsoft.Extensions.DependencyInjection;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace HelloWorld.Handlers
{
    [ExcludeFromCodeCoverage(Justification = "Entry point for Lambda")]
    public class Function
    {
        private readonly INetworkServices _networkServices;
        public Function() : this(null) { }

        private Function(INetworkServices networkServices = null)
        {
            Startup.ConfigureServices();
            _networkServices = networkServices ?? Startup.Services.GetRequiredService<INetworkServices>();
        }

        public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest apiProxyEvent, ILambdaContext context)
        {

            var location = await _networkServices.GetCallingIp();
            var body = new Dictionary<string, string>
            {
                { "message", "hello world" },
                { "location", location }
            };

            return new APIGatewayProxyResponse
            {
                Body = JsonSerializer.Serialize(body),
                StatusCode = 200,
                Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } }
            };
        }
    }
}
