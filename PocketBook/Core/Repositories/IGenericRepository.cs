namespace PocketBook.Core.Repositories
{
    public interface IGenericRepository<X> where X : class
    {
        Task<IEnumerable<X>> All();
        Task<X> GetById(Guid id);
        Task<bool> Add(X entity);
        Task<bool> Delete(Guid id);
        Task<bool> Upsert(X entity);

    }
}
