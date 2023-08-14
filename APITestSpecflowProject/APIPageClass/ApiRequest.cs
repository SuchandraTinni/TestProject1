using System.Text.Json;
using RestSharp;
using NUnit.Framework;

namespace TestProject1.APITestProject.APIPageClass;

public class ApiRequest
{
    
    public static RestResponse GetRequest()
    {
        var client = new RestClient("https://api.tmsandbox.co.nz/v1");
        var request = new RestRequest("Categories/6327/Details.json", Method.Get);
        request.AddParameter("catalogue", "false");
        var response = client.Execute<dynamic>(request);
        var responseContent = response.Content;
        using var document = JsonDocument.Parse(responseContent);
        
        return client.ExecuteGetAsync(request).Result;
    }
    
   
}