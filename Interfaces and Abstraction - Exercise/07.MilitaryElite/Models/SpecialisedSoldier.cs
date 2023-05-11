using _07.MilitaryElite.Enums;
using _07.MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, Corps corps) 
            : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }

        public Corps Corps { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.ToString());
            result.AppendLine($"Corps: {Corps}");

            return result.ToString().TrimEnd();
        }
    }
}
