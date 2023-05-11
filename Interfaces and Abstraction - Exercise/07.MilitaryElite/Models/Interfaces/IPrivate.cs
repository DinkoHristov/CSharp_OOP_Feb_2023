using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Models.Interfaces
{
    public interface IPrivate : ISoldier
    {
        decimal Salary { get; }
    }
}
