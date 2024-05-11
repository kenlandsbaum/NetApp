using Amazon.S3.Model;

namespace BlazorWeb.Services;

public interface IAwsS3Service
{
    public Task<List<S3Bucket>> ListBuckets();
}