using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using BlazorWeb.Models;

using Microsoft.Extensions.Options;

namespace BlazorWeb.AwsClients;

public class S3Client : IS3Client
{
    
    private AmazonS3Client _client;
    public S3Client(IOptions<AwsCredentials> config)
    {
        var awsCredentials = new BasicAWSCredentials(config.Value.AccessKeyId, config.Value.SecretAccessKey);
        _client = new AmazonS3Client(awsCredentials);
    }

    public async Task<ListBucketsResponse> ListBucketsAsync()
    {
        var res = await _client.ListBucketsAsync();
        return res;
    }
}