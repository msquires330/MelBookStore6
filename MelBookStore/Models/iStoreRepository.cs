using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelBookStore.Models
{
    // Change this from a class to an interface (meant to be inherited, define the infrastructure) 
    public interface iStoreRepository
    {
        // Similar to IEnumerable. Store Project type in the IQueryable. Only allow them to get the projects. 
        IQueryable<Project> Projects { get; }
    }
}
