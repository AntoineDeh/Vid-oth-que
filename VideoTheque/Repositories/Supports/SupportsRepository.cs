using Microsoft.EntityFrameworkCore;
using VideoTheque.Context;
using VideoTheque.DTOs;

/*namespace VideoTheque.Repositories.Supports
{
    public class SupportsRepository : ISupportsRepository
    {
        private readonly VideothequeDb _db;
        public SupportsRepository(VideothequeDb db)
        {
            _db = db;
        }

        public Task<List<SupportsDto>> GetSupports() => _db.Supports.ToListAsync();

        public ValueTask<SupportsDto?> GetSupports(int id) => _db.Supports.FindAsync(id);

        public Task InsertSupport(SupportsDto support)
        {
            _db.Supports.AddAsync(support);
            return _db.SaveChangesAsync();
        }

        public Task UpdateSupport(int id, SupportsDto support)
        {
            var supportToUpdate = _db.Supports.FindAsync(id).Result;

            if (supportToUpdate is null)
            {
                throw new KeyNotFoundException($"Support '{id}' non trouvé");
            }

            supportToUpdate.Name = support.Name;

            return _db.SaveChangesAsync();
        }

        public Task DeleteSupport(int id)
        {
            var supportToDelete = _db.Supports.FindAsync(id).Result;
            
            if (supportToDelete is null)
            {
                throw new KeyNotFoundException($"Support '{id}' non trouvé");
            }

            _db.Supports.Remove(supportToDelete);
            return _db.SaveChangesAsync();
        }
    }
}*/
