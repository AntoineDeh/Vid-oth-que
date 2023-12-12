using VideoTheque.DTOs;

namespace VideoTheque.Repositories.Supports
{
    public interface ISupportsRepository
    {
        Task<List<SupportsDto>> GetSupports();

        ValueTask<SupportsDto?> GetSupport(int id);

        Task InsertSupport(SupportsDto support);

        Task UpdateSupport(int id, SupportsDto support);

        Task DeleteSupport(int id);
    }
}
