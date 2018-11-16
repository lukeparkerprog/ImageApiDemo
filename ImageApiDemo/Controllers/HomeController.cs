using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ImageApiDemo.Models;
using ImageApiDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageApiDemo.Controllers
{
    public class HomeController : Controller
    {
		private IDataService<Image> _imageService;

		public HomeController(
			IDataService<Image> imageService
			)
		{
			_imageService = imageService;
		}

		public IActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public IActionResult Index(IFormFile myImage)
		{
			if(myImage == null)
			{
				return View();
			}
			else if (myImage.ContentType.ToLower().StartsWith("image/"))
			{
				MemoryStream ms = new MemoryStream();
				myImage.OpenReadStream().CopyTo(ms);
				System.Drawing.Image image = System.Drawing.Image.FromStream(ms);

				Image dbImg = new Image()
				{
					Data = ms.ToArray(),
					FileName = myImage.FileName,
                    ContentType = myImage.ContentType
				};

				_imageService.Create(dbImg);				
			}
			return View();
		}
    }
}