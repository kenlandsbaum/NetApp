using Amazon.Lambda.Model;

namespace BlazorWeb.Services;

public interface IAwsLambdaService
{
   public Task<List<FunctionConfiguration>> ListFunctions();
}