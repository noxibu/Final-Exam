using Final_Exam___Sales_Management_System.DTOs;
using Final_Exam___Sales_Management_System.Entities;
using Final_Exam___Sales_Management_System.Repositories;
using System.Drawing;

namespace Final_Exam___Sales_Management_System.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IUserInformationRepository _userInformationRepository;
        public ImageService(IImageRepository imageRepository, IUserInformationRepository userInformationRepository)
        {
            _imageRepository = imageRepository;
            _userInformationRepository = userInformationRepository;
        }
        public async Task<Image> AddImageAsync(Guid id, ImageUploadDto imageUploadDto)
        {
            if (imageUploadDto == null)
            {
                throw new ArgumentNullException(nameof(imageUploadDto));
            }
            using var memoryStream = new MemoryStream();
            await imageUploadDto.Image.CopyToAsync(memoryStream);

            var userInformation = _userInformationRepository.GetUserInfo(id);

            var image = new Image
            {
                Id = Guid.NewGuid(),
                Name = imageUploadDto.Image.FileName,
                ImageBytes = memoryStream.ToArray(),
                ContentType = imageUploadDto.Image.ContentType,
                UserInformationId = userInformation.Id
            };
            return await _imageRepository.AddAsync(id, image);
        
        }


        public ImageDto GetImage(Guid userId)
        {
            var userInformation = _userInformationRepository.GetUserInfo(userId);

            if(userInformation == null)
            {
                throw new Exception("User information is not found");
            }

            var image = _imageRepository.GetImage(userInformation.Id);

            var imageDto = new ImageDto();

            if(image == null)
            {
                imageDto = null;
                return imageDto;
            }

            imageDto.Image = image.ImageBytes;

            return imageDto;
        }

        public void DeleteImage(Guid userId)
        {
            var userInformation = _userInformationRepository.GetUserInfo(userId);

            if(userInformation == null )
            {
                throw new ArgumentNullException();
            }

            _imageRepository.DeleteImage(userInformation.Id);
        }
    }
}
