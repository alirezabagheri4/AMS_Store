namespace Domain.Common
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
