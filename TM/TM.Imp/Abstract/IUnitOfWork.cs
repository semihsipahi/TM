namespace TM.Imp.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        ITodoRepository TodoRepository { get; }
        int Complete();
    }
}
