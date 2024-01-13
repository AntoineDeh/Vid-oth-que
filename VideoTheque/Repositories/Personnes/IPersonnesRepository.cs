using VideoTheque.DTOs;

namespace VideoTheque.Repositories.Personnes
{
    public interface IPersonnesRepository
    {
        Task<List<PersonneDto>> GetPersonnes();

        ValueTask<PersonneDto?> GetPersonne(int id);

        Task<PersonneDto?> GetPersonne(string firstName, string lastName);

        Task<PersonneDto?> GetPersonne(string fullName);

        Task InsertPersonne(PersonneDto personne);

        Task UpdatePersonne(int id, PersonneDto personneD);

        Task DeletePersonne(int id);
    }
}
