using Amazon.S3.Model;
using BlazorWeb.Services;
using BlazorWeb.Models;

namespace BlazorWeb.Testing.Services;

public class MockAwsS3Service: IAwsS3Service
{
    public Task<List<S3Bucket>> ListBuckets()
    {
        var buckets = new List<S3Bucket> {
            new S3Bucket {
                BucketName = "bucket1",
                CreationDate = new DateTime(2021, 1, 1)
            },
            new S3Bucket {
                BucketName = "bucket2",
                CreationDate = new DateTime(2021, 1, 2)
            }
        };
        return Task.FromResult(buckets);
    }
}