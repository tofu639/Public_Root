using System.Net;
using System.Net.Sockets;
using Microsoft.Extensions.Configuration;
namespace DynamicsReporting.ExternalService;

public class Utility
{
    private readonly IConfiguration _configuration;
    //private readonly IHostEnvironment _hostEnvironment;
    

    public Utility(IConfiguration configuration) //, IHostEnvironment hostEnvironment, IHttpContextAccessor httpContextAccessor)
    {
        _configuration = configuration;
        //_hostEnvironment = hostEnvironment;
        //_httpContextAccessor = httpContextAccessor;
    }

    public string GetConnectionString(string sectionName)
    {
        return _configuration.GetConnectionString(sectionName) ?? "";
    }


    public string GetProjectName()
    {
        return _configuration.GetSection("ProjectName").Value ?? "";
    }

    public string GetProjectName(string sectionName)
    {
        return _configuration.GetSection(sectionName)?.Value ?? "";

    }

    public string GetSection(string sectionName)
    {
        return _configuration.GetSection(sectionName)?.Value ?? "";

    }
     
    public double GetCacheAbsoluteExpiration()
    {
        var cacheSection = _configuration.GetSection("CacheAbsoluteExpiration");
        if (cacheSection == null || cacheSection["Houre"] == null)
        {
            throw new InvalidOperationException("CacheAbsoluteExpiration or its 'Houre' value is not configured properly.");
        }

        return double.Parse(cacheSection["Houre"]);
    }

    public string GetLocalIPAddress()
    {
        var host = Dns.GetHostName();
        var ip = Dns.GetHostEntry(host)
            .AddressList
            .FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork);
        return ip?.ToString() ?? "127.0.0.1";
    }


    public string GetHost()
    {
        return Dns.GetHostEntry(Dns.GetHostName()).HostName;
    }

 
}