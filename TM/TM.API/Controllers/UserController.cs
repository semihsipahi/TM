using Microsoft.AspNetCore.Mvc;
using TM.Core.DTO;
using TM.Core.Entity;
using TM.Imp.Concrete;

namespace TM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UnitOfWork unitOfWork = new(new Core.Data.TodoContext());

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var result = new List<UserDto>();

            var users = await unitOfWork.UserRepository.GetAll();

            foreach (var item in users)
            {
                result.Add(new UserDto()
                {
                    Email = item.EMail,
                    PKUserId = item.PKUserId,
                });
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserDto request)
        {
            var user = new User()
            {
                EMail = request.Email,
                Password = request.Password,
                Created = DateTime.Now,
                Updated = DateTime.Now,
            };

            await unitOfWork.UserRepository.Add(user);
            unitOfWork.Complete();

            return Ok(user);
        }
    }
}
