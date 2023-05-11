using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Models.Interfaces
{
    public interface ISpy : ISoldier
    {
        int CodeNumber { get; }
    }
}
