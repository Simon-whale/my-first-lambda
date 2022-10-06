using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.SystemTextJson.Converters;
using HelloWorld.Interfaces;
using HelloWorld.Models;
using Microsoft.Extensions.DependencyInjection;

namespace HelloWorld.Handlers;

public class EchoMessage
{
    private readonly IPersonStore _personStore;

    public EchoMessage() : this(null) { }

    public EchoMessage(IPersonStore personStore)
    {
        Startup.ConfigureServices();
        _personStore = personStore ?? Startup.Services.GetRequiredService<IPersonStore>();
    }
    
    public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayHttpApiV2ProxyRequest  request, ILambdaContext ctx)
    {
        var options = new JsonSerializerOptions
        {
            Converters = { new DateTimeConverter() },
            PropertyNameCaseInsensitive = true,
        };
        
        var person = JsonSerializer.Deserialize<Person>(request.Body, options);

        _personStore.AddPersons(person);
        
        return new APIGatewayProxyResponse
        {
            Body = JsonSerializer.Serialize($"{person}, has been added"),
            StatusCode = 200,
            Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } }
        };
    }
}