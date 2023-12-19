using Microsoft.EntityFrameworkCore;
using VideoTheque.Context;
using VideoTheque.DTOs;

namespace VideoTheque.Repositories.BluRays
{
    public class BluRaysRepository : IBluRaysRepository
    {
        private readonly VideothequeDb _db;

        public BluRaysRepository(VideothequeDb db)
        {
            _db = db;
        }

        public Task<List<BluRayDto>> GetBluRays() => _db.BluRays.ToListAsync();

        public ValueTask<BluRayDto?> GetBluRay(int id) => _db.BluRays.FindAsync(id);

        public Task InsertBluRay(BluRayDto bluRay)
        {
            _db.BluRays.AddAsync(bluRay);
            return _db.SaveChangesAsync();
        }

        public Task UpdateBluRay(int id, BluRayDto bluRay) {

            var bluRayToUpdate = _db.BluRays.FindAsync(id).Result;

            if (bluRayToUpdate == null)
            {
                throw new KeyNotFoundException($"Film '{id}' non trouvé");
            }

            bluRay.Title = bluRayToUpdate.Title;
            bluRay.Duration = bluRayToUpdate.Duration;
            bluRay.IdFirstActor = bluRayToUpdate.IdFirstActor;
            bluRay.IdDirector = bluRayToUpdate.IdDirector;
            bluRay.IdScenarist = bluRayToUpdate.IdScenarist;
            bluRay.IdAgeRating = bluRayToUpdate.IdAgeRating;
            bluRay.IdGenre = bluRayToUpdate.IdGenre;
            bluRay.IsAvailable = bluRayToUpdate.IsAvailable;
            bluRay.IdOwner = bluRayToUpdate.IdOwner;
            return _db.SaveChangesAsync();
        }

        public Task DeleteBluRay(int id)
        {
            var bluRayToDelete = _db.BluRays.FindAsync(id).Result;

            if (bluRayToDelete == null)
            {
                throw new KeyNotFoundException($"Film '{id}' non trouvé");
            }

            _db.BluRays.Remove(bluRayToDelete);
            return _db.SaveChangesAsync();
        }

    }
}
