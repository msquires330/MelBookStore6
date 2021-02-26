using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace MelBookStore.Models
{
    // creates a model / mold for each individual project or book that is going to be published to the site. 
    public class Project
    {
        // Sets BookID as auto incrementing primary key
        // Makes each field Required
        [Key, Required]
        public int BookID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string AuthorFirst { get; set; }
        public string AuthorMiddle { get; set; }
        [Required]
        public string AuthorLast { get; set; }
        [Required]
        public string Publisher { get; set; }

        // Sets up format for how ISBN will be accepted
        [Required, RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{10}))$", ErrorMessage = "Not a valid ISBN")]
        public string ISBN { get; set; }
        [Required]
        public string Classification { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int NumOfPages { get; set; }
    }
}
