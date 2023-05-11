using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class UniversityRepository : IRepository<IUniversity>
    {
        private readonly List<IUniversity> universities;

        public UniversityRepository()
        {
            universities = new List<IUniversity>();
        }

        public IReadOnlyCollection<IUniversity> Models
            => universities.AsReadOnly();

        public void AddModel(IUniversity model)
            => this.universities.Add(model);

        public IUniversity FindById(int id)
        {
            IUniversity searchedUniversity = universities.FirstOrDefault(s => s.Id == id);

            if (searchedUniversity != null)
            {
                return searchedUniversity;
            }

            return null;
        }

        public IUniversity FindByName(string name)
        {
            IUniversity searchedUniversity = universities.FirstOrDefault(s => s.Name == name);

            if (searchedUniversity != null)
            {
                return searchedUniversity;
            }

            return null;
        }
    }
}
