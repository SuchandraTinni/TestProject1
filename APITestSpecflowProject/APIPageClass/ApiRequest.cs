using System.Text.Json;
using RestSharp;
using NUnit.Framework;

namespace TestProject1.APITestProject.APIPageClass;

public class ApiRequest
{
    
    public static RestResponse GetRequest(string contextPath)
    {
        
        var request = new RestRequest(contextPath, Method.Get);
        
        return new RestClient("https://api.tmsandbox.co.nz/v1").ExecuteGetAsync(request).Result;
    }
    
   
}