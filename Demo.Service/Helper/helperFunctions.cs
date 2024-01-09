using Demo.EntityFramework.Models;
using Demo.Repository.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Demo.Service.Helper
{
    internal class HelperFunctions
    {
        private readonly IRepository<User> _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HelperFunctions(IRepository<User> userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public int GetCurrentUserId()
        {
            try
            {
                var identity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
                var userClaims = identity.Claims;
                var email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value;
                int id = _userRepository.GetAll().First(x => x.Email == email).UserId;
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        public async Task<string> ProcessImageFile(IFormFile image)
        {
            try
            {
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                string imagePath = Path.Combine("Uploads", uniqueFileName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }
                return "Uploads/" + uniqueFileName;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
