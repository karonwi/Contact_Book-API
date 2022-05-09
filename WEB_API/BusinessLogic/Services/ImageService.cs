using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Data.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Model;

namespace BusinessLogic.Services
{
    public class ImageService : IImageService
    {
        private readonly IConfiguration _configuration;
        private readonly Cloudinary _cloudinary;
        private readonly ImageUploadSetting _accountSetting;

        public ImageService(IConfiguration configuration,IOptions<ImageUploadSetting> accountSetting)
        {
            _accountSetting = accountSetting.Value;
            _configuration = configuration;  
            _cloudinary = new Cloudinary(new Account(_accountSetting.CloudName,
                _accountSetting.ApiKey, _accountSetting.ApiSecret));
           
        }
        public async Task<UploadResult> UploadAsync(IFormFile image)
        {
            var pictureFormat = false;
            var listOfImageExt = _configuration.GetSection("PhotoSettings: Formats").Get<List<string>>();

            foreach (var item in listOfImageExt)
            {
                if (image.FileName.EndsWith(item))
                {
                    pictureFormat = true;
                    break;
                }
            }

            if (pictureFormat == false)
            {
                throw new ArgumentException("File format not supported");
            }

            var uploadResult = new ImageUploadResult();

            using ( var imageStream = image.OpenReadStream())
            {
                string fileName = Guid.NewGuid().ToString() + image.FileName;

                uploadResult = await _cloudinary.UploadAsync(new ImageUploadParams()
                {
                    File = new FileDescription(fileName, imageStream),
                    Transformation = new Transformation().Crop("thumb").Gravity("face").Width(150).Height(150)
                });
            }
            return uploadResult;                      

        }
    }
}
