using System.Security.Claims;
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
        private int GetUserId() =>
           int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        [HttpGet]
        public IActionResult GetProfile(int UserId)
        {
            var user = _profileService.GetUserById(UserId);
            if(user == null) 
                return NotFound("Profile Not Found");
            return Ok(user);
        }
        //[HttpPost("UpdateProfile")]
        //public IActionResult UpdateProfile([FromBody] UpdateProfileDTO updateProfile)
        //{
        //    if (updateProfile == null || updateProfile.Id == null)
        //        return BadRequest();
        //    var Res = _profileService.UpdateUserProfile(updateProfile);
        //    return Ok("Profile Updated");
        //}
        [HttpPut("update")]
        public IActionResult UpdateProfile([FromBody] UpdateProfileDTO dto)
        {
            var updated = _profileService.UpdateProfile(GetUserId(), dto);

            if (updated == null)
                return NotFound("User not found");

            return Ok(updated);
        }
    }
}
