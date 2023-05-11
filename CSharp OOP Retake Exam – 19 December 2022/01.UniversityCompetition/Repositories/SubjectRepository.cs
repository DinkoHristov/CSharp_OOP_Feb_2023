
using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class SubjectRepository : IRepository<ISubject>
    {
        private readonly List<ISubject> subjects;

        public SubjectRepository()
        {
            subjects = new List<ISubject>();
        }

        public IReadOnlyCollection<ISubject> Models
            => subjects.AsReadOnly();

        public void AddModel(ISubject model)
            => subjects.Add(model);

        public ISubject FindById(int id)
        {
            ISubject searchedSubject = subjects.FirstOrDefault(s => s.Id == id);

            if (searchedSubject != null)
            {
                return searchedSubject;
            }

            return null;
        }

        public ISubject FindByName(string name)
        {
            ISubject searchedSubject = subjects.FirstOrDefault(s => s.Name == name);

            if (searchedSubject != null)
            {
                return searchedSubject;
            }

            return null;
        }
    }
}
