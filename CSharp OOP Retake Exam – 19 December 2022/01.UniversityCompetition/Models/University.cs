using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;

namespace UniversityCompetition.Models
{
    public class University : IUniversity
    {
        private readonly List<int> requiredSubjects;

        private string name;
        private string category;
        private int capacity;

        public University(int id, string name, string category, int capacity, List<int> requiredSubjects)
        {
            this.Id = id;
            this.Name = name;
            this.Category = category;
            this.Capacity = capacity;

            this.requiredSubjects = requiredSubjects;
        }

        public int Id { get; private set; }

        public string Name {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                this.name = value;
            }
        }

        public string Category {
            get
            {
                return this.category;
            }
            private set
            { 
                if (value != "Technical" && value != "Economical" && value != "Humanity")
                {
                    throw new ArgumentException($"University category {value} is not allowed in the application!");
                }

                this.category = value;
            }
        }

        public int Capacity {
            get
            {
                return this.capacity;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("University capacity cannot be a negative value!");
                }

                this.capacity = value;
            }
        }

        public IReadOnlyCollection<int> RequiredSubjects
            => this.requiredSubjects.AsReadOnly();
    }
}
