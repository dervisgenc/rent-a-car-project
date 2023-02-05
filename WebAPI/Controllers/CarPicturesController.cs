using Business.Abstract;
using Entities.Concreate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPicturesController : ControllerBase
    {
        ICarPictureService _carPictureService;
        public CarPicturesController(ICarPictureService carPictureService)
        {
            _carPictureService = carPictureService;
        }

        [HttpGet("getimagebyid")]
        public IActionResult GetImageById(int id)
        {
            var carPicture = _carPictureService.GetCarPicture(id);
            var imagePath = carPicture.Data.ImagePath;
            //Do null check
            if (carPicture.Success)
            {
                return File(System.IO.File.OpenRead(imagePath), "image/jpeg");
            }
            return BadRequest(carPicture.Message);
        }

        [HttpPost("postimage")]
        public async Task<IActionResult> PostImage(IFormFile formFile)//, CarPicture image
        {
            // Validate the image file
            if ( formFile.Length <= 0)
            {
                return BadRequest("Image is required");
            }

            var result = _carPictureService.Add(formFile,new CarPicture());
            if (result.Success)
            {
                // Create a unique name for the image
                string uniqueName = Guid.NewGuid().ToString() + ".jpeg";

                // Define the path to store the image
                var path = Path.Combine(@"C:\Users\Dervis\source\repos\pictures", uniqueName);

                // Save the image to the specified path
                using (var fileStream = System.IO.File.Create(path))
                {
                    formFile.CopyTo(fileStream);
                    fileStream.Flush();
                }

                // Set the ImagePath property to the path of the saved image
                //image.ImagePath = path;

                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}
