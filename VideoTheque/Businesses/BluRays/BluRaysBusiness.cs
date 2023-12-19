using VideoTheque.DTOs;
using VideoTheque.Core;
using VideoTheque.Repositories.BluRays;

namespace VideoTheque.Businesses.BluRays
{
    public class BluRaysBusiness : IBluRaysBusiness
    {
        private readonly IBluRaysRepository _BluRayDao;

        public BluRaysBusiness(IBluRaysRepository bluRayDao)
        {
            _BluRayDao= bluRayDao;
        }

        public Task<List<BluRayDto>> GetBluRays() => _BluRayDao.GetBluRays();

        public BluRayDto GetBluRay(int id)
        {
            var bluRay = _BluRayDao.GetBluRay(id).Result;

            if (bluRay is null)
            {
                throw new NotFoundException($"Film '{id}' non trouvé");
            }

            return bluRay;
        }

        public BluRayDto InsertBluRay(BluRayDto bluRay)
        {
            if (_BluRayDao.InsertBluRay(bluRay).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de l'insertion du film {bluRay.Title}");
            }
            return bluRay;
        }

        public void UpdateBluRay(int id, BluRayDto bluRay)
        {
            if (_BluRayDao.UpdateBluRay(id, bluRay).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de la modification du film {bluRay.Title}");
            }
        }

        public void DeleteBluRay(int id)
        {
            if (_BluRayDao.DeleteBluRay(id).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de la supression du film identifiante {id}");
            }
        }
    }
}
