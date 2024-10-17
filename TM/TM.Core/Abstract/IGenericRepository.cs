namespace TM.Core.Abstract
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public Task<bool> Add(T entity);
        public void Delete(int id);
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(int id);
        public void Update(T entity);
    }
}
