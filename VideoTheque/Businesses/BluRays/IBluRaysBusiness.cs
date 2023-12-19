using VideoTheque.DTOs;

namespace VideoTheque.Businesses.BluRays
{
    public interface IBluRaysBusiness
    {
        Task<List<BluRayDto>> GetBluRays();

        BluRayDto GetBluRay(int id);

        BluRayDto InsertBluRay(BluRayDto bluRay);

        void UpdateBluRay(int id, BluRayDto bluRay);

        void DeleteBluRay(int id);
    }
}
