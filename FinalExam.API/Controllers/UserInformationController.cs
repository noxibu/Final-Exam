using Final_Exam___Sales_Management_System.DTOs;
using Final_Exam___Sales_Management_System.Repositories;
using Final_Exam___Sales_Management_System.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Final_Exam___Sales_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserInformationController : ControllerBase
    {
        private readonly IUserInformationService _userInformationService;
        private readonly IAddressService _addressService;
        private readonly IImageService _imageService;
        public UserInformationController(IUserInformationService userInformationService, 
            IAddressService addressService,
            IImageService imageService)
        {
            _userInformationService = userInformationService;
            _addressService = addressService;
            _imageService = imageService;
        }

        [HttpPost]
        public IActionResult AddUserInformation([FromBody] UserInformationDto userInformation)
        {
            try
            {
                var userIdentity = User.Identity as ClaimsIdentity;
                if (userIdentity == null || !userIdentity.IsAuthenticated)
                {
                    return Unauthorized("User is not authenticated.");
                }

                var userIdClaim = userIdentity.FindFirst(ClaimTypes.Sid)?.Value;
                Console.WriteLine("User ID Claim: "+userIdClaim);
                _userInformationService.AddUserInformation(Guid.Parse(userIdClaim), 
                    userInformation);

                return Ok();

            } catch(ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            } catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetUserInformationById(Guid id)
        {
            try
            {
                var userIdentity = User.Identity as ClaimsIdentity;
                if (userIdentity == null || !userIdentity.IsAuthenticated)
                {
                    return Unauthorized("User is not authenticated.");
                }
                var userIdClaim = userIdentity.FindFirst(ClaimTypes.Sid)?.Value;
                if (!_userInformationService.IsUserComplete(Guid.Parse(userIdClaim)))
                {
                    return BadRequest("Complete registration by adding user information, address and image first.");
                }
                Console.WriteLine("User ID Claim: " + userIdClaim);
                var userInformation = _userInformationService.GetUserInformation(id);

                    return Ok(userInformation);

            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetUserInformation()
        {
            try
            {
                var userIdentity = User.Identity as ClaimsIdentity;
                if (userIdentity == null || !userIdentity.IsAuthenticated)
                {
                    return Unauthorized("User is not authenticated.");
                }


                var userIdClaim = userIdentity.FindFirst(ClaimTypes.Sid)?.Value;
                if (!_userInformationService.IsUserComplete(Guid.Parse(userIdClaim)))
                {
                    return BadRequest("Complete registration by adding user information, address and image first.");
                }

                    Console.WriteLine("User ID Claim: " + userIdClaim);

                var userInformation = _userInformationService.GetUserInformation(Guid.Parse(userIdClaim));

                return Ok(userInformation);


            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateUserInformation([FromBody] UserInformationDto userInformation)
        {
            try
            {
                var userIdentity = User.Identity as ClaimsIdentity;
                if (userIdentity == null || !userIdentity.IsAuthenticated)
                {
                    return Unauthorized("User is not authenticated.");
                }

                var userIdClaim = userIdentity.FindFirst(ClaimTypes.Sid)?.Value;
                if (!_userInformationService.IsUserComplete(Guid.Parse(userIdClaim)))
                {
                    return BadRequest("Complete registration by adding user information, address and image first.");
                }

                Console.WriteLine("User ID Claim: " + userIdClaim);
                _userInformationService.UpdateUserInformation(Guid.Parse(userIdClaim), userInformation);

                return Ok();

            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("FirstName/")]
        public IActionResult UpdateUserInformationFirstname([FromBody] FirstNameDto firstNameDto)
        {
            try
            {
                var userIdentity = User.Identity as ClaimsIdentity;
                if (userIdentity == null || !userIdentity.IsAuthenticated)
                {
                    return Unauthorized("User is not authenticated.");
                }

                var userIdClaim = userIdentity.FindFirst(ClaimTypes.Sid)?.Value;
                if (!_userInformationService.IsUserComplete(Guid.Parse(userIdClaim)))
                {
                    return BadRequest("Complete registration by adding user information, address and image first.");
                }

                Console.WriteLine("User ID Claim: " + userIdClaim);
                _userInformationService.UpdateUserInformationFirstName(Guid.Parse(userIdClaim), firstNameDto);

                return Ok();

            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("LastName/")]
        public IActionResult UpdateUserInformationLastName([FromBody] LastNameDto lastNameDto)
        {
            try
            {
                var userIdentity = User.Identity as ClaimsIdentity;
                if (userIdentity == null || !userIdentity.IsAuthenticated)
                {
                    return Unauthorized("User is not authenticated.");
                }

                var userIdClaim = userIdentity.FindFirst(ClaimTypes.Sid)?.Value;
                if (!_userInformationService.IsUserComplete(Guid.Parse(userIdClaim)))
                {
                    return BadRequest("Complete registration by adding user information, address and image first.");
                }
                Console.WriteLine("User ID Claim: " + userIdClaim);
                _userInformationService.UpdateUserInformationLastName(Guid.Parse(userIdClaim), lastNameDto);

                return Ok();

            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("PersonalCode/")]
        public IActionResult UpdateUserInformationLastName([FromBody] PersonalCodeDto personalCodeDto)
        {
            try
            {
                var userIdentity = User.Identity as ClaimsIdentity;
                if (userIdentity == null || !userIdentity.IsAuthenticated)
                {
                    return Unauthorized("User is not authenticated.");
                }

                var userIdClaim = userIdentity.FindFirst(ClaimTypes.Sid)?.Value;
                if (!_userInformationService.IsUserComplete(Guid.Parse(userIdClaim)))
                {
                    return BadRequest("Complete registration by adding user information, address and image first.");
                }
                Console.WriteLine("User ID Claim: " + userIdClaim);
                _userInformationService.UpdateUserInformationPersonalCode(Guid.Parse(userIdClaim), personalCodeDto);

                return Ok();

            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("PhoneNumber/")]
        public IActionResult UpdateUserInformationLastName([FromBody] PhoneNumberDto phoneNumberDto)
        {
            try
            {
                var userIdentity = User.Identity as ClaimsIdentity;
                if (userIdentity == null || !userIdentity.IsAuthenticated)
                {
                    return Unauthorized("User is not authenticated.");
                }

                var userIdClaim = userIdentity.FindFirst(ClaimTypes.Sid)?.Value;
                if (!_userInformationService.IsUserComplete(Guid.Parse(userIdClaim)))
                {
                    return BadRequest("Complete registration by adding user information, address and image first.");
                }
                Console.WriteLine("User ID Claim: " + userIdClaim);
                _userInformationService.UpdateUserInformationPhoneNumber(Guid.Parse(userIdClaim), phoneNumberDto);

                return Ok();

            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("Email/")]
        public IActionResult UpdateUserInformationEmail([FromBody] EmailDto emailDto)
        {
            try
            {
                var userIdentity = User.Identity as ClaimsIdentity;
                if (userIdentity == null || !userIdentity.IsAuthenticated)
                {
                    return Unauthorized("User is not authenticated.");
                }

                var userIdClaim = userIdentity.FindFirst(ClaimTypes.Sid)?.Value;
                if (!_userInformationService.IsUserComplete(Guid.Parse(userIdClaim)))
                {
                    return BadRequest("Complete registration by adding user information, address and image first.");
                }
                Console.WriteLine("User ID Claim: " + userIdClaim);
                _userInformationService.UpdateUserInformationEmail(Guid.Parse(userIdClaim), emailDto);

                return Ok();

            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteUserInformation()
        {
            try
            {
                var userIdentity = User.Identity as ClaimsIdentity;
                if (userIdentity == null || !userIdentity.IsAuthenticated)
                {
                    return Unauthorized("User is not authenticated.");
                }

                var userIdClaim = userIdentity.FindFirst(ClaimTypes.Sid)?.Value;
                if (!_userInformationService.IsUserComplete(Guid.Parse(userIdClaim)))
                {
                    return BadRequest("Complete registration by adding user information, address and image first.");
                }
                Console.WriteLine("User ID Claim: " + userIdClaim);
                _userInformationService.DeleteUserInformation(Guid.Parse(userIdClaim));

                return Ok();

            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // User Address
        [HttpPost("Address/")]
        public IActionResult AddUserAddress([FromBody] AddressDto addressDto)
        {
            try
            {
                var userIdentity = User.Identity as ClaimsIdentity;
                if (userIdentity == null || !userIdentity.IsAuthenticated)
                {
                    return Unauthorized("User is not authenticated.");
                }

                var userIdClaim = userIdentity.FindFirst(ClaimTypes.Sid)?.Value;
                if (!_userInformationService.IsUserComplete(Guid.Parse(userIdClaim)))
                {
                    return BadRequest("Complete registration by adding user information, address and image first.");
                }
                Console.WriteLine("User ID Claim: " + userIdClaim);
                _addressService.AddAddress(Guid.Parse(userIdClaim),
                    addressDto);

                return Ok();

            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("Address/")]
        public IActionResult UpdateUserAddress([FromBody] AddressDto addressDto)
        {
            try
            {
                var userIdentity = User.Identity as ClaimsIdentity;
                if (userIdentity == null || !userIdentity.IsAuthenticated)
                {
                    return Unauthorized("User is not authenticated.");
                }

                var userIdClaim = userIdentity.FindFirst(ClaimTypes.Sid)?.Value;
                if (!_userInformationService.IsUserComplete(Guid.Parse(userIdClaim)))
                {
                    return BadRequest("Complete registration by adding user information, address and image first.");
                }
                Console.WriteLine("User ID Claim: " + userIdClaim);
                _addressService.UpdateAddress(Guid.Parse(userIdClaim),
                    addressDto);

                return Ok();

            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("Address/")]
        public IActionResult GetUserAddress()
        {
            try
            {
                var userIdentity = User.Identity as ClaimsIdentity;
                if (userIdentity == null || !userIdentity.IsAuthenticated)
                {
                    return Unauthorized("User is not authenticated.");
                }


                var userIdClaim = userIdentity.FindFirst(ClaimTypes.Sid)?.Value;
                if (!_userInformationService.IsUserComplete(Guid.Parse(userIdClaim)))
                {
                    return BadRequest("Complete registration by adding user information, address and image first.");
                }
                Console.WriteLine("User ID Claim: " + userIdClaim);
                var userAddress = _addressService.GetAddress(Guid.Parse(userIdClaim));

                return Ok(userAddress);

            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("Address/City")]
        public IActionResult UpdateUserAddressCity([FromBody] CityDto cityDto)
        {
            try
            {
                var userIdentity = User.Identity as ClaimsIdentity;
                if (userIdentity == null || !userIdentity.IsAuthenticated)
                {
                    return Unauthorized("User is not authenticated.");
                }

                var userIdClaim = userIdentity.FindFirst(ClaimTypes.Sid)?.Value;
                if (!_userInformationService.IsUserComplete(Guid.Parse(userIdClaim)))
                {
                    return BadRequest("Complete registration by adding user information, address and image first.");
                }
                Console.WriteLine("User ID Claim: " + userIdClaim);
                _addressService.UpdateAddressCity(Guid.Parse(userIdClaim),
                    cityDto);

                return Ok();

            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("Address/Street")]
        public IActionResult UpdateUserAddressStreet([FromBody] StreetDto streetDto)
        {
            try
            {
                var userIdentity = User.Identity as ClaimsIdentity;
                if (userIdentity == null || !userIdentity.IsAuthenticated)
                {
                    return Unauthorized("User is not authenticated.");
                }

                var userIdClaim = userIdentity.FindFirst(ClaimTypes.Sid)?.Value;
                if (!_userInformationService.IsUserComplete(Guid.Parse(userIdClaim)))
                {
                    return BadRequest("Complete registration by adding user information, address and image first.");
                }
                Console.WriteLine("User ID Claim: " + userIdClaim);
                _addressService.UpdateAddressStreet(Guid.Parse(userIdClaim),
                    streetDto);

                return Ok();

            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("Address/HouseNumber")]
        public IActionResult UpdateUserAddressHouseNumber([FromBody] HouseNumberDto houseNumberDto)
        {
            try
            {
                var userIdentity = User.Identity as ClaimsIdentity;
                if (userIdentity == null || !userIdentity.IsAuthenticated)
                {
                    return Unauthorized("User is not authenticated.");
                }

                var userIdClaim = userIdentity.FindFirst(ClaimTypes.Sid)?.Value;
                if (!_userInformationService.IsUserComplete(Guid.Parse(userIdClaim)))
                {
                    return BadRequest("Complete registration by adding user information, address and image first.");
                }
                Console.WriteLine("User ID Claim: " + userIdClaim);
                _addressService.UpdateAddressHouseNumber(Guid.Parse(userIdClaim),
                    houseNumberDto);

                return Ok();

            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("Address/ApartmentNumber")]
        public IActionResult UpdateUserAddressApartmentNumber([FromBody] ApartmentNumberDto apartmentNumberDto)
        {
            try
            {
                var userIdentity = User.Identity as ClaimsIdentity;
                if (userIdentity == null || !userIdentity.IsAuthenticated)
                {
                    return Unauthorized("User is not authenticated.");
                }

                var userIdClaim = userIdentity.FindFirst(ClaimTypes.Sid)?.Value;
                if (!_userInformationService.IsUserComplete(Guid.Parse(userIdClaim)))
                {
                    return BadRequest("Complete registration by adding user information, address and image first.");
                }
                Console.WriteLine("User ID Claim: " + userIdClaim);
                _addressService.UpdateAddressApartmentNumber(Guid.Parse(userIdClaim),
                    apartmentNumberDto);

                return Ok();

            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("Address/")]
        public IActionResult DeleteUserAddress()
        {
            try
            {
                var userIdentity = User.Identity as ClaimsIdentity;
                if (userIdentity == null || !userIdentity.IsAuthenticated)
                {
                    return Unauthorized("User is not authenticated.");
                }

                var userIdClaim = userIdentity.FindFirst(ClaimTypes.Sid)?.Value;
                if (!_userInformationService.IsUserComplete(Guid.Parse(userIdClaim)))
                {
                    return BadRequest("Complete registration by adding user information, address and image first.");
                }
                Console.WriteLine("User ID Claim: " + userIdClaim);
                _addressService.RemoveAddress(Guid.Parse(userIdClaim));

                return Ok();

            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Image
        [HttpPost("Image/")]
        public async Task<ActionResult> UploadImage([FromForm] ImageUploadDto imageUploadDto)
        {
            try
            {
                var userIdentity = User.Identity as ClaimsIdentity;
                if (userIdentity == null || !userIdentity.IsAuthenticated)
                {
                    return Unauthorized("User is not authenticated.");
                }

                var userIdClaim = userIdentity.FindFirst(ClaimTypes.Sid)?.Value;
                Console.WriteLine("User ID Claim: " + userIdClaim);


                var addedImage = await _imageService.AddImageAsync(Guid.Parse(userIdClaim), imageUploadDto);
                var stream = new MemoryStream(addedImage.ImageBytes);
                return new FileStreamResult(stream, addedImage.ContentType);

            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("Image/")]
        public IActionResult GetImage()
        {
            try
            {
                var userIdentity = User.Identity as ClaimsIdentity;
                if (userIdentity == null || !userIdentity.IsAuthenticated)
                {
                    return Unauthorized("User is not authenticated.");
                }

                var userIdClaim = userIdentity.FindFirst(ClaimTypes.Sid)?.Value;
                if (!_userInformationService.IsUserComplete(Guid.Parse(userIdClaim)))
                {
                    return BadRequest("Complete registration by adding user information, address and image first.");
                }
                Console.WriteLine("User ID Claim: " + userIdClaim);

                var image = _imageService.GetImage(Guid.Parse(userIdClaim));

                return Ok(image);

            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("Image/")]
        public async Task<ActionResult> UpdateImage([FromForm] ImageUploadDto imageUploadDto)
        {
            try
            {
                var userIdentity = User.Identity as ClaimsIdentity;
                if (userIdentity == null || !userIdentity.IsAuthenticated)
                {
                    return Unauthorized("User is not authenticated.");
                }

                var userIdClaim = userIdentity.FindFirst(ClaimTypes.Sid)?.Value;
                Console.WriteLine("User ID Claim: " + userIdClaim);


                var addedImage = await _imageService.AddImageAsync(Guid.Parse(userIdClaim), imageUploadDto);
                var stream = new MemoryStream(addedImage.ImageBytes);
                return new FileStreamResult(stream, addedImage.ContentType);

            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("Image/")]
        public IActionResult DeleteImage()
        {
            try
            {
                var userIdentity = User.Identity as ClaimsIdentity;
                if (userIdentity == null || !userIdentity.IsAuthenticated)
                {
                    return Unauthorized("User is not authenticated.");
                }

                var userIdClaim = userIdentity.FindFirst(ClaimTypes.Sid)?.Value;
                if (!_userInformationService.IsUserComplete(Guid.Parse(userIdClaim)))
                {
                    return BadRequest("Complete registration by adding user information, address and image first.");
                }
                Console.WriteLine("User ID Claim: " + userIdClaim);

                _imageService.DeleteImage(Guid.Parse(userIdClaim));

                return Ok();

            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        
    }
}
