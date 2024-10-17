using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using TM.Core.DTO;
using TM.Core.Entity;
using TM.Core.Enum;
using TM.Imp.Concrete;

namespace TM.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly UnitOfWork unitOfWork = new(new Core.Data.TodoContext());

        [HttpGet]
        public async Task<IActionResult> Gets()
        {
            var result = new List<TodoDto>();

            var todos = await unitOfWork.TodoRepository.GetAll();

            foreach (var item in todos)
            {
                var user = await unitOfWork.UserRepository.GetById(item.FKUserId);

                result.Add(new TodoDto()
                {
                    PKTodoId = item.PKTodoId,
                    Title = item.Title,
                    Detail = item.Detail,
                    Status = (int)item.Status,
                    Priority = (int)item.Priority,
                    UserEmail = user.EMail,
                    DisplayStatus = Enum.GetName(typeof(TodoStatus), item.Status),
                    DisplayPriority = Enum.GetName(typeof(TodoPriority), item.Priority)
                });
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var todo = await unitOfWork.TodoRepository.GetById(id);

            if (todo == null)
            {
                return NotFound();
            }

            return Ok(new TodoDto()
            {
                Title = todo.Title,
                Detail = todo.Detail,
                Priority = (int)todo.Priority,
                Status = (int)todo.Status
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TodoDto request)
        {
            var todo = new Todo
            {
                Title = request.Title,
                Detail = request.Detail,
                Status = (TodoStatus)request.Status,
                Priority = (TodoPriority)request.Priority,
                Created = DateTime.Now,
                Updated = DateTime.Now,
                StoryPoint = request.StoryPoint,
                FKUserId = request.FKUserId
            };

            await unitOfWork.TodoRepository.Add(todo);
            unitOfWork.Complete();

            return Ok(todo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TodoDto request)
        {
            var todo = await unitOfWork.TodoRepository.GetById(id);

            if (todo == null)
            {
                return NotFound();
            }

            todo.Title = request.Title ?? todo.Title;
            todo.Detail = request.Detail ?? todo.Detail;
            todo.Status = (TodoStatus)request.Status;
            todo.Priority = (TodoPriority)request.Priority;
            todo.Updated = DateTime.Now;
            todo.FKUserId = request.FKUserId != 0 ? request.FKUserId : todo.FKUserId;

            unitOfWork.TodoRepository.Update(todo);
            unitOfWork.Complete();

            return Ok(todo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var todo = await unitOfWork.TodoRepository.GetById(id);

            if (todo == null)
            {
                return BadRequest();
            }

            unitOfWork.TodoRepository.Delete(id);
            unitOfWork.Complete();

            return Ok();
        }
    }
}
