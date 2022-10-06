using System.Threading.Tasks;

namespace HelloWorld.Interfaces;

public interface INetworkServices
{
    Task<string> GetCallingIp();
}