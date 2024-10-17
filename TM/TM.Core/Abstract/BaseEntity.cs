namespace TM.Core.Abstract
{
    public abstract class BaseEntity
    {
        public virtual DateTimeOffset Created { get; set; }
        public virtual DateTimeOffset Updated { get; set; }
    }
}
