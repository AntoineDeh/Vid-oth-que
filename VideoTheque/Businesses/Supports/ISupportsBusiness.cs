using VideoTheque.DTOs;

namespace VideoTheque.Businesses.Supports
{
    public interface ISupportsBusiness
    {
        Task<List<SupportsDto>> GetSupports();

        SupportsDto GetSupport(int id);

        SupportsDto InsertSupport(SupportsDto support);

        void UpdateSupport(int id, SupportsDto support);
        
        void DeleteSupport(int id);
    }
}
