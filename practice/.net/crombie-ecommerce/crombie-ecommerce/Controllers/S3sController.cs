using crombie_ecommerce.Services;
using Microsoft.AspNetCore.Mvc;

namespace crombie_ecommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class S3sController : ControllerBase
    {
        private readonly s3Service _s3Service;

        public S3sController(s3Service s3Service)
        {
            _s3Service = s3Service;
        }

        [HttpPost("upload")]
        public async Task<ActionResult<string>> PutObject(IFormFile fileObject)
        {
            try
            {
                if (fileObject == null || fileObject.Length == 0)
                    return BadRequest("File is missing");

                using var stream = fileObject.OpenReadStream();
                var fileName = $"{Guid.NewGuid()}-{fileObject.FileName}";

                var url = await _s3Service.UploadFileAsync(stream, fileName, fileObject.ContentType);

                return Ok($"{url}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
