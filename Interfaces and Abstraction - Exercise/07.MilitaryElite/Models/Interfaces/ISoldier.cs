using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Models.Interfaces
{
    public interface ISoldier
    {
        int Id { get; }

        string FirstName { get; }

        string LastName { get; }
    }
}
