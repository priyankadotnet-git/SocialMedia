using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.DTOs;
using SocialMedia.Interface;
using SocialMedia.Models;

namespace SocialMedia.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;
        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }
        [HttpGet]
        public IActionResult GetProfile(int UserId)
        {
            var user = _profileService.GetUserById(UserId);
            if(user == null) 
                return NotFound("Profile Not Found");
            return Ok(user);
        }
        [HttpPost("UpdateProfile")]
        public IActionResult UpdateProfile(UpdateProfileDTO updateProfile)
        {
            if (updateProfile == null || updateProfile.Id == null)
                return BadRequest();
            return View();
        }
    }
}
