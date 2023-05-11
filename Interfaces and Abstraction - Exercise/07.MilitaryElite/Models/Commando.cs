using _07.MilitaryElite.Enums;
using _07.MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps, IReadOnlyCollection<IMission> missions) 
            : base(id, firstName, lastName, salary, corps)
        {
            Missions = missions;
        }

        public IReadOnlyCollection<IMission> Missions { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.ToString());
            result.AppendLine("Missions:");

            foreach (var mission in Missions)
            {
                result.AppendLine($"  {mission}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
