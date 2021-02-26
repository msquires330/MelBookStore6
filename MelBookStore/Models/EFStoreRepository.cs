using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelBookStore.Models
{
    // This implements the iStoreRepository 
    public class EFStoreRepository : iStoreRepository
    {
        private StoreDbContext _context;
        //Constructor
        // Create a context that will take and store permanently into the private _context
        public EFStoreRepository(StoreDbContext context)
        {
            _context = context;
        }
        public IQueryable<Project> Projects => _context.Projects;
    }
}
