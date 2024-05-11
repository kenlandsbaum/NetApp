using Amazon.S3.Model;
using BlazorWeb.AwsClients;

namespace BlazorWeb.Services;

public class AwsS3ServiceTest
{
    [Fact]
    public async Task Should_Get_Buckets_From_Client()
    {
        var mockS3Client = new MockS3Client(false);
        var sut = new AwsS3Service(mockS3Client);
        var buckets = await sut.ListBuckets();
        Assert.Equal(4, buckets.Count);
        var i = 0;
        foreach (var bucket in buckets)
        {
            i += 1;
            var expectedName = String.Concat("bucket-", i);
            Assert.Equal(expectedName, bucket.BucketName);
        }
    }
}

class MockS3Client : IS3Client
{
    private bool _shouldErr;
    public MockS3Client(bool shouldErr)
    {
        _shouldErr = shouldErr;
    }

    public Task<ListBucketsResponse> ListBucketsAsync()
    {
        if (_shouldErr) {
            return Task.FromResult(new ListBucketsResponse());
        }
        var buckets = new List<S3Bucket> {
            new S3Bucket(){BucketName = "bucket-1", CreationDate = new System.DateTime()},
            new S3Bucket(){BucketName = "bucket-2", CreationDate = new System.DateTime()},
            new S3Bucket(){BucketName = "bucket-3", CreationDate = new System.DateTime()},
            new S3Bucket(){BucketName = "bucket-4", CreationDate = new System.DateTime()}
        };
        var response = new ListBucketsResponse() {Buckets = buckets};
        return Task.FromResult(response);
    }
}