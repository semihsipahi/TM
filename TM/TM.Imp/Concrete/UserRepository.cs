using Microsoft.EntityFrameworkCore;
using TM.Core.Concrete;
using TM.Core.Data;
using TM.Imp.DTO;
using TM.Core.Entity;
using TM.Imp.Abstract;

namespace TM.Imp.Concrete
{
    public class UserRepository(TodoContext context) : GenericRepository<User>(context), IUserRepository
    {
        // For Phase 2 Additional Content.
        public User GetUser(string email, string password)
        {
            return _context.Users.FirstOrDefault(x => x.EMail == email && x.Password == password);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> Create(User user)
        {
            await _context.Users.AddAsync(user);
            return true;
        }

        public async Task<IEnumerable<TodoDto>> GetTodosByUserId(int id)
        {
            return await _context.Users.Join(_context.Todos, user => user.PKUserId, todo => todo.FKUserId,
                            (user, todo) => new TodoDto()
                            {
                                EditMode = true, // For UI.
                                PKTodoId = todo.PKTodoId,
                                FKUserId = user.PKUserId,
                                Title = todo.Title,
                                Detail = todo.Detail,
                                StoryPoint = todo.StoryPoint,
                                UserEmail = user.EMail,
                                DisplayStatus = todo.Status.ToString(),
                                DisplayPriority = todo.Priority.ToString(),
                            }).ToListAsync();
        }
    }
}
