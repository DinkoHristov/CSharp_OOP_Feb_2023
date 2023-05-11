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
    public class StudentRepository : IRepository<IStudent>
    {
        private readonly List<IStudent> students;

        public StudentRepository()
        {
            students = new List<IStudent>();
        }

        public IReadOnlyCollection<IStudent> Models
            => students.AsReadOnly();

        public void AddModel(IStudent model)
            => students.Add(model);

        public IStudent FindById(int id)
        {
            IStudent searchedStudent = students.FirstOrDefault(s => s.Id == id);

            if (searchedStudent != null)
            {
                return searchedStudent;
            }

            return null;
        }

        public IStudent FindByName(string name)
        {
            string[] splittedName = name.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            IStudent searchedStudent = students
                .FirstOrDefault(s => s.FirstName == splittedName[0] &&
                                s.LastName == splittedName[1]);

            if (searchedStudent != null)
            {
                return searchedStudent;
            }

            return null;
        }
    }
}
