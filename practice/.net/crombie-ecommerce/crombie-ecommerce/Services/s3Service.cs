using Amazon.Runtime;
using Amazon.S3;

namespace crombie_ecommerce.Services
{
    public class s3Service
    {
        private readonly IAmazonS3 _amazonS3;
        private readonly string _bucketName;

        public s3Service(IConfiguration configuration)
        {
            _amazonS3 = new AmazonS3Client(new BasicAWSCredentials(configuration["AccessKeyId"], configuration["SecretAcessKey"]));
            _bucketName = configuration["BucketName"] ?? "";
        }

        public async Task<bool> UploadFileAsync(
            Stream fileStream, string fileName, string contentType)
        {
            var request = new Amazon.S3.Model.PutObjectRequest
            {
                BucketName = _bucketName,
                Key = fileName,
                InputStream = fileStream,
                ContentType = contentType
            };

            var response = await _amazonS3.PutObjectAsync(request);
            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine($"Successfully uploaded {fileName} to {_bucketName}.");
                return true;
            }
            else
            {
                Console.WriteLine($"Could not upload {fileName} to {_bucketName}.");
                return false;
            }
        }


    }
}
