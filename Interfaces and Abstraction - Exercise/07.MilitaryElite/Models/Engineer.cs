using _07.MilitaryElite.Enums;
using _07.MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps, IReadOnlyCollection<IRepair> repairs) 
            : base(id, firstName, lastName, salary, corps)
        {
            Repairs = repairs;
        }

        public IReadOnlyCollection<IRepair> Repairs { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.ToString());
            result.AppendLine("Repairs:");

            foreach (var repair in Repairs)
            {
                result.AppendLine($"  {repair}");
            }    

            return result.ToString().TrimEnd();
        }
    }
}
