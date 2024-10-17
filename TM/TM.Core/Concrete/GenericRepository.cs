using Microsoft.EntityFrameworkCore;
using TM.Core.Abstract;
using TM.Core.Data;

namespace TM.Core.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected TodoContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(TodoContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<bool> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public async void Delete(int id)
        {
            var todo = await GetById(id);
            _dbSet.Remove(todo);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
