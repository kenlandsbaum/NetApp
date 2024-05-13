using Amazon.Lambda;
using Amazon.Lambda.Model;

namespace BlazorWeb.Services;

public class AwsLambdaService(IAmazonLambda client, ILogger<AwsLambdaService> logger) : IAwsLambdaService
{
    public async Task<List<FunctionConfiguration>> ListFunctions()
    {
        try 
        {
            var res = await client.ListFunctionsAsync();
            return res.Functions;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error listing functions");
            throw;
        }
    }
}