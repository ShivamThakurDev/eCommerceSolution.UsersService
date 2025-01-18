using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>   
/// Define the ApplicationUser class which acts as a model for the user entity
/// </summary>
namespace eCommerce.Core.Entities
{
    public class ApplicationUser
    {
        public Guid UserID { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PersonName { get; set; }
        public string? Gender { get; set; }

    }
}
