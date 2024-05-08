using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FinalProjectASP.Models
{
    public class ApplicationUser : IdentityUser
    {
       
        public int CustId { get; set; }

        [RegularExpression("^[^0-9].*", ErrorMessage = "Name should not start with a number.")]
        public string ?Firstname {  get; set; }
        [RegularExpression("^[^0-9].*", ErrorMessage = "Name should not start with a number.")]
        public string ?Lastname {  get; set; }

    }
}
