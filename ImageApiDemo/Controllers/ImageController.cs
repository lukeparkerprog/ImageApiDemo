using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ImageApiDemo.Models;
using ImageApiDemo.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ImageApiDemo.Controllers
{
    [Route("api/[controller]")]
    public class ImageController : Controller
    {
		private IDataService<Image> _imageService;

		public ImageController(
			IDataService<Image> imageService
			)
		{
			_imageService = imageService;
		}

		[HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Image image = _imageService.GetSingle(p => p.ImageId == id);

            if (image != null)
            {
                return File(image.Data, image.ContentType);
            }
            return BadRequest();
        }
    }
}
