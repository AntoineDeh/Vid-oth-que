﻿using Microsoft.EntityFrameworkCore;
using VideoTheque.Context;
using VideoTheque.DTOs;

namespace VideoTheque.Repositories.AgeRatings
{
    public class AgeRatingsRepository : IAgeRatingsRepository
    {
        private readonly VideothequeDb _db;
        public AgeRatingsRepository(VideothequeDb db)
        {
            _db = db;
        }

        public Task<List<AgeRatingDto>> GetAgeRatings() => _db.AgeRatings.ToListAsync();

        public ValueTask<AgeRatingDto?> GetAgeRating(int id) => _db.AgeRatings.FindAsync(id);

        public Task<AgeRatingDto?> GetAgeRating(string name) => _db.AgeRatings.FirstOrDefaultAsync(p => string.Equals(p.Name, name));
        public Task InsertAgeRating(AgeRatingDto ageRating)
        {
            _db.AgeRatings.AddAsync(ageRating);
            return _db.SaveChangesAsync();
        }

        public Task UpdateAgeRating(int id, AgeRatingDto ageRating)
        {
            var ageRatingToUpdate = _db.AgeRatings.FindAsync(id).Result;

            if (ageRatingToUpdate is null)
            {
                throw new KeyNotFoundException($"Limite d'âge '{id}' non trouvé");
            }

            ageRatingToUpdate.Name = ageRating.Name;
            ageRatingToUpdate.Abreviation = ageRating.Abreviation;
            return _db.SaveChangesAsync();
        }

        public Task DeleteAgeRating(int id)
        {
            var ageRatingToDelete = _db.AgeRatings.FindAsync(id).Result;
            if (ageRatingToDelete is null)
            {
                throw new KeyNotFoundException($"Limite d'âge '{id}' non trouvé");
            }

            _db.AgeRatings.Remove(ageRatingToDelete);
            return _db.SaveChangesAsync();
        }
    }
}
