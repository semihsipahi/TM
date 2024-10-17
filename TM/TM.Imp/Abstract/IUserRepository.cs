using TM.Core.Abstract;
using TM.Core.Entity;

namespace TM.Imp.Abstract
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<IEnumerable<User>> GetAll();
        User GetUser(string email, string password);
        Task<bool> Add(User entity);
    }
}
