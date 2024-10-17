using TM.Core.Data;
using TM.Imp.Abstract;

namespace TM.Imp.Concrete
{
    public class UnitOfWork(TodoContext context) : IUnitOfWork
    {
        private readonly TodoContext _context = context;
        public ITodoRepository TodoRepository { get; private set; } = new TodoRepository(context);
        public IUserRepository UserRepository { get; private set; } = new UserRepository(context);

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
