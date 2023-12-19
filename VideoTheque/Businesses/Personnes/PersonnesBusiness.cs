using VideoTheque.DTOs;
using VideoTheque.Core;
using VideoTheque.Repositories.Personnes;

namespace VideoTheque.Businesses.Personnes
{
    public class PersonnesBusiness : IPersonnesBusiness
    {
        private readonly IPersonnesRepository _PersoneDao;

        public PersonnesBusiness(IPersonnesRepository personeDao)
        {
            _PersoneDao = personeDao;
        }

        public Task<List<PersonneDto>> GetPersonnes() => _PersoneDao.GetPersonnes();

        public PersonneDto GetPersonne(int id)
        {
            var personne = _PersoneDao.GetPersonne(id).Result;

            if (personne is null)
            {
                throw new NotFoundException($"Personne '{id}' non trouvé");
            }

            return personne;
        }

        public PersonneDto InsertPersonne(PersonneDto personne)
        {
            if (_PersoneDao.InsertPersonne(personne).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de l'insertion de la personne {personne.FirstName} {personne.LastName}");
            }

            return personne;
        }

        public void UpdatePersonne(int id, PersonneDto personne)
        {
            if (_PersoneDao.UpdatePersonne(id, personne).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de la modification de la personne {personne.FirstName} {personne.LastName}");
            }
        }

        public void DeletePersonne(int id)
        {
            if (_PersoneDao.DeletePersonne(id).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de la suppression de la personne identifiante {id}");
            }
        }
    }
}
