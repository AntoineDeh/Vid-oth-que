using VideoTheque.DTOs;

namespace VideoTheque.Businesses.Supports
{
    public interface ISupportsBusiness
    {
        Task<List<SupportsDto>> GetSupports();

        SupportsDto GetSupport(int id);
    }
}
