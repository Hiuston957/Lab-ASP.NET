using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium3.Models
{
    public class Contact 
    {
       public int Id { get; set; }
        //atrybuty nad dotyczą pola pod
       [Required(ErrorMessage ="Musisz podac imię")]
       [StringLength(maximumLength: 50, ErrorMessage = "Zbyt dlugie imie, wpisz max 50 znaków")]
       public string Name { get; set; }
       [EmailAddress(ErrorMessage = "Podano zły adres email")]
       public string Email { get; set; }
       [Phone]
       public string Phone { get; set; }
       [DataType(DataType.Date)]
       public DateTime? Birth { get; set; }

        [Display(Name = "Priorytet")]
        public Priority Priority { get; set; }
    }
}
