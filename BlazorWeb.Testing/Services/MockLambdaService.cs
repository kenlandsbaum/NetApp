using Amazon.Lambda.Model;
using BlazorWeb.Services;
using BlazorWeb.Models;

namespace BlazorWeb.Testing.Services;
public class MockLambdaService : IAwsLambdaService
{
    public Task<List<FunctionConfiguration>> ListFunctions()
    {
        var fcs = new List<FunctionConfiguration> {
            new FunctionConfiguration() {
                FunctionName = "BlazorWeb-dev-listFunctions",
                LastModified = "2021-03-04T19:14:00.000+0000"
            },
            new FunctionConfiguration() {
                    FunctionName = "BlazorWeb-prd-listFunctions",
                    LastModified = "2021-03-04T19:14:00.000+0000"
            }
        };
        return Task.FromResult(fcs);
    }
}