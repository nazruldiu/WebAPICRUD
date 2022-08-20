using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIFullCRUDWithFile.DataService.IConfiguration;
using WebAPIFullCRUDWithFile.Entities.Entities;
using WebAPIFullCRUDWithFile.ViewModel;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace WebAPIFullCRUDWithFile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public UserDetailsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            //var details = (from user in _unitOfWork.Users
            //               join userdetails in _unitOfWork.UserDetails on user.Id equals userdetails.UserId
            //               select new
            //               {
            //                   Username = user.Username,
            //                   Address = user.Address
            //               }).ToList();
            var details = _unitOfWork.UserDetails.GetUserDetails();
            return Ok(details);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] UserDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                // var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = User.FindFirst("UserId")?.Value;
                var userDetails = new UserDetailsEntity
                {
                    UserId = Convert.ToInt32(user),
                    Address = model.Address,
                    ImageFile = model.ImageFile,
                    NationalId = model.NationalId,
                    Status =1,
                    InsertDate = DateTime.Now
                };
                var result = await _unitOfWork.UserDetails.Add(userDetails);
                if (result)
                {
                    await _unitOfWork.SaveChangesAsync();
                    return Ok("Success.");
                }
                else
                    return BadRequest("Save failed.");

            }
            else
                return BadRequest("Model state invalid.");

        }
    }
}
