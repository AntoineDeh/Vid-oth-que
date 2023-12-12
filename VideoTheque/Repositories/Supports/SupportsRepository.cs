using VideoTheque.DTOs;

namespace VideoTheque.Repositories.Supports
{
    public class SupportsRepository : ISupportsRepository
    {
        public enum Supports
        {
            bluray = 1,
            VHS = 2,
            Dematerialise = 3
        }

        public Task<List<SupportsDto>> GetSupports()
        {
            var supportsDtos = Enum.GetValues(typeof(Supports))
                .Cast<Supports>()
                .Select(support => new SupportsDto
                {
                    Id = (int)support,
                    Name = support.ToString()
                })
                .ToList();

            return Task.FromResult(supportsDtos);
        }

        public ValueTask<SupportsDto?> GetSupport(int id)
        {
            var support = Enum.GetValues(typeof(Supports))
                .Cast<Supports>()
                .FirstOrDefault(s => (int)s == id);

            if (support != 0)
            {
                var supportDto = new SupportsDto
                {
                    Id = (int)support,
                    Name = support.ToString()
                };
                return new ValueTask<SupportsDto?>(supportDto);
            }
            else
            {
                var supportDto = new SupportsDto
                {
                    Id = 0,
                    Name = null
                };
                return new ValueTask<SupportsDto?>(supportDto);
            }
        }
    }
}
