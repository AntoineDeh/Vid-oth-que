using VideoTheque.DTOs;

namespace VideoTheque.Repositories.Supports
{
    public interface ISupportsRepository
    {
        Task<List<SupportsDto>> GetSupports();

        ValueTask<SupportsDto?> GetSupport(int id);
    }
}
