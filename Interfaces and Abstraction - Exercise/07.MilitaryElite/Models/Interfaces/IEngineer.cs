using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Models.Interfaces
{
    public interface IEngineer : ISpecialisedSoldier
    {
        IReadOnlyCollection<IRepair> Repairs { get; }
    }
}
