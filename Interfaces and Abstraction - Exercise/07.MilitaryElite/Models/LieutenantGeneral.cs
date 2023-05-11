using _07.MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, IReadOnlyCollection<IPrivate> privates) 
            : base(id, firstName, lastName, salary)
        {
            Privates = privates;
        }

        public IReadOnlyCollection<IPrivate> Privates { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.ToString());
            result.AppendLine("Privates:");

            foreach (var currPrivate in Privates)
            {
                result.AppendLine($"  {currPrivate}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
