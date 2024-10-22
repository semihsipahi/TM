using Microsoft.AspNetCore.Mvc;
using TM.Core.Entity;
using TM.Imp.Concrete;
using TM.Imp.DTO;

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
            var users = await unitOfWork.UserRepository.GetAll();

            var mapped = users.Select(x => new UserDto()
            {
                Email = x.EMail,
                PKUserId = x.PKUserId,
            });

            return Ok(mapped);
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

        [HttpGet]
        [Route("{id}/Todos")]
        public async Task<IActionResult> GetTodosByUserId(int id)
        {
            var result = await unitOfWork.UserRepository.GetTodosByUserId(id);

            return Ok(result);
        }
    }
}
