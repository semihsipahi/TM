namespace TM.Imp.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        ITodoRepository TodoRepository { get; }
        IUserRepository UserRepository { get; }
        int Complete();
    }
}
