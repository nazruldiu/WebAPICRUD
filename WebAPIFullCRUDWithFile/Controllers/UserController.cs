using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPIFullCRUDWithFile.DataService.IConfiguration;
using WebAPIFullCRUDWithFile.Entities.Entities;
using WebAPIFullCRUDWithFile.ViewModel;

namespace WebAPIFullCRUDWithFile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private IConfiguration _configuration;
        public UserController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userList = await Task.Run(() => _unitOfWork.Users.GetAll()); 
            return Ok(userList);
        }

        [HttpGet]
        [Route("GetUserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _unitOfWork.Users.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> SaveUser([FromBody] UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userEntity = new UserModelEntity
                {
                    Username = model.Username,
                    Password = model.Password,
                    Email = model.Email,
                    Status = 1,
                    InsertDate = DateTime.Now
                };

               var result =  await _unitOfWork.Users.Add(userEntity);
                if(result)
                {
                    await _unitOfWork.SaveChangesAsync();
                    return Ok("Success.");
                }
                else
                    return BadRequest("Save failed.");
            }
            else
                return BadRequest("Model is not valid.");

        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userEntity = new UserModelEntity
                {
                    Id = model.Id,
                    Username = model.Username,
                    Password = model.Password,
                    Email = model.Email,
                    Status = 1,
                    UpdateDate = DateTime.Now
                };
                var result = _unitOfWork.Users.Update(userEntity);

                if (result)
                {
                    await _unitOfWork.SaveChangesAsync();
                    return Ok("Success.");
                }
                else
                    return BadRequest("Update failed.");
            }
            else
                return BadRequest("Model is not valid.");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Users.Delete(id);
            if(result)
                return Ok("Success");
            else
                return BadRequest("Delete Failed.");
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] UserViewModel loginRequest)
        {
            var userList = _unitOfWork.Users.GetAll();
            var user = userList.Where(x => x.Username == loginRequest.Username && x.Password == loginRequest.Password).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Authentication Fail");
            }
            else
            {
                var iUser = new IdentityUser
                {
                    UserName = user.Username,
                    Email = user.Email,
                    Id = user.Id.ToString()
                };
                var token = GetJwtToken(iUser);
                return Ok(token);
            }
        }

        public string GetJwtToken(IdentityUser user)
        {
            var tokenHandeler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtConfig:secret"]);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, user.Id),
                new Claim("UserId", user.Id),
                new Claim("Username", user.UserName),
                new Claim("Email", user.Email)
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials
                (
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandeler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandeler.WriteToken(token);
            return jwtToken;
        }
    }
}
