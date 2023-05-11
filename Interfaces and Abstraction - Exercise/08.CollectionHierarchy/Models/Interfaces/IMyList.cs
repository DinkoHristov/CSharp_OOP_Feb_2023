using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy.Models.Interfaces
{
    public interface IMyList : IAddRemoveCollection
    {
        int Used { get; }
    }
}
