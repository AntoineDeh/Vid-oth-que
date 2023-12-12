using VideoTheque.Core;
using VideoTheque.DTOs;
using VideoTheque.Repositories.Supports;

namespace VideoTheque.Businesses.Supports
{
    public class SupportsBusiness : ISupportsBusiness
    {
        private readonly ISupportsRepository _supportsDao;

        public SupportsBusiness(ISupportsRepository supportsDao)
        {
            _supportsDao = supportsDao;
        }

        public Task<List<SupportsDto>> GetSupports() => _supportsDao.GetSupports();

        public SupportsDto GetSupport(int id)
        {
            var support = _supportsDao.GetSupport(id).Result;

            if (support is null)
            {
                throw new NotFoundException($"Support non trouvé");
            }
            return support;
        }

        public SupportsDto InsertSupport(SupportsDto supports)
        {
            if (_supportsDao.InsertSupport(supports).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de l'insertion de support {supports.Name}");
            }

            return supports;
        }
        public void UpdateSupport(int id, SupportsDto support)
        {
            if (_supportsDao.UpdateSupport(id, support).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de la modification de support {support.Name}");
            }
        }

        public void DeleteSupport(int id)
        {
            if (_supportsDao.DeleteSupport(id).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de la suppression de support");
            }
        }
    }
}
