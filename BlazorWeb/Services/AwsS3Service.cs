using System.Diagnostics;
using Amazon.S3.Model;
using BlazorWeb.AwsClients;

namespace BlazorWeb.Services;

public class AwsS3Service(IS3Client client): IAwsS3Service
{
    public async Task<List<S3Bucket>> ListBuckets()
    {
        try 
        {
            var res = await client.ListBucketsAsync();
            return res.Buckets;
        }
        catch (Exception ex)
        {
            Debug.WriteLine("client faceplanted {0}", ex.Message);
            return [];
        }
    }
}