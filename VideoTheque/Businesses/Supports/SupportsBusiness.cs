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
    }
}
