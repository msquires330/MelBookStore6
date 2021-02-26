using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelBookStore.Models.ViewModels
{
    public class ProjectListViewModel
    {
        // The ProjectListViewModel is going to contain information about the project itself and also about the paging info 
        public IEnumerable<Project> Projects { get; set; }
        public PagingInfo PagingInfo { get; set; }

    }
}
