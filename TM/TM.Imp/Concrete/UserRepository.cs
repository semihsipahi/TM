using Microsoft.EntityFrameworkCore;
using TM.Core.Concrete;
using TM.Core.Data;
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
    }
}
