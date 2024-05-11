
using Amazon.S3.Model;

namespace BlazorWeb.AwsClients;

public interface IS3Client
{
    public Task<ListBucketsResponse> ListBucketsAsync();
}