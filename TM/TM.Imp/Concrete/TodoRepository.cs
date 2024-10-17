using TM.Core.Concrete;
using TM.Core.Data;
using TM.Core.Entity;
using TM.Imp.Abstract;

namespace TM.Imp.Concrete
{
    public class TodoRepository(TodoContext context) : GenericRepository<Todo>(context), ITodoRepository
    {
        // For Phase 2 Additional Content.
    }
}
