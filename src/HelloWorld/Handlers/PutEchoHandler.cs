using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using HelloWorld.Models;

namespace HelloWorld.Handlers;

public class EchoMessage
{
    public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayHttpApiV2ProxyRequest  request, ILambdaContext ctx)
    {
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var message = JsonSerializer.Deserialize<RequestMessage>(request.Body, options);
        
        return new APIGatewayProxyResponse
        {
            Body = JsonSerializer.Serialize(message),
            StatusCode = 200,
            Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } }
        };
    }
}