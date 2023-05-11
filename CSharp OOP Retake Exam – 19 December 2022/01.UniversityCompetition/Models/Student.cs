using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;

namespace UniversityCompetition.Models
{
    public class Student : IStudent
    {
        private readonly List<int> coveredExams;
        private IUniversity university;

        private string firstName;
        private string lastName;

        public Student(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;

            coveredExams = new List<int>();
        }

        public int Id { get; private set; }

        public string FirstName {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                this.firstName = value;
            }
        }

        public string LastName {
            get
            {
                return this.lastName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                this.lastName = value;
            }
        }

        public IReadOnlyCollection<int> CoveredExams
            => this.coveredExams.AsReadOnly();

        public IUniversity University
            => this.university;

        public void CoverExam(ISubject subject)
        {
            coveredExams.Add(subject.Id);
        }
        public void JoinUniversity(IUniversity university)
            => this.university = university;
    }
}
