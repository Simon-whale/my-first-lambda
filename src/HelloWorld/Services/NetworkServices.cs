using System.Net.Http;
using System.Threading.Tasks;
using HelloWorld.Interfaces;

namespace HelloWorld.Services;

public class NetworkServices : INetworkServices
{
    private readonly HttpClient _client = new HttpClient();

    public async Task<string> GetCallingIp()
    {
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Add("User-Agent", "AWS Lambda .Net Client");

        var msg = await _client.GetStringAsync("http://checkip.amazonaws.com/").ConfigureAwait(continueOnCapturedContext:false);

        return msg.Replace("\n","");
    }   
}