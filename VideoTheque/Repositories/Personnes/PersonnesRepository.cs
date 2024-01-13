using Microsoft.EntityFrameworkCore;
using VideoTheque.Context;
using VideoTheque.DTOs;

namespace VideoTheque.Repositories.Personnes
{
    public class PersonnesRepository : IPersonnesRepository
    {
        private readonly VideothequeDb _db;

        public PersonnesRepository(VideothequeDb db)
        {
            _db = db;
        }

        public Task<List<PersonneDto>> GetPersonnes() => _db.Personnes.ToListAsync();

        public ValueTask<PersonneDto?> GetPersonne(int id) => _db.Personnes.FindAsync(id);
        public Task<PersonneDto?> GetPersonne(string firstName, string lastName) => _db.Personnes.FirstOrDefaultAsync(p => string.Equals(p.FirstName, firstName) && string.Equals(p.LastName, lastName));

        public Task<PersonneDto?> GetPersonne(string fullName) => _db.Personnes.FirstOrDefaultAsync(p => string.Equals($"{p.FirstName} {p.LastName}", fullName));
        public Task InsertPersonne(PersonneDto personne)
        {
            _db.Personnes.AddAsync(personne);
            return _db.SaveChangesAsync();
        }

        public Task UpdatePersonne(int id, PersonneDto personne)
        {
            var personneToUpdate = _db.Personnes.FindAsync(id).Result;

            if (personneToUpdate == null)
            {
                throw new KeyNotFoundException($"Personne '{id}' non trouvé");
            }

            personne.FirstName = personneToUpdate.FirstName;
            personne.LastName = personneToUpdate.LastName;
            personne.Nationality = personneToUpdate.Nationality;
            personne.BirthDay = personneToUpdate.BirthDay;
            return _db.SaveChangesAsync();
        }

        public Task DeletePersonne(int id)
        {
            var personneToDelete = _db.Personnes.FindAsync(id).Result;

            if (personneToDelete == null)
            {
                throw new KeyNotFoundException($"Personne '{id}' non trouvé");
            }

            _db.Personnes.Remove(personneToDelete);
            return _db.SaveChangesAsync();
        }
    }
}
