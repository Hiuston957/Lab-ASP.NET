using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium3.Models
{
  
    public class Album
    {
        [HiddenInput]
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nazwa albumu")]
        [Required(ErrorMessage = "Musisz podać nazwę albumu")]
        [StringLength(maximumLength: 100, ErrorMessage = "Zbyt długa nazwa albumu, wpisz max 100 znaków")]
        public string Nazwa { get; set; }

        [Display(Name = "Nazwa zespołu")]
        [Required(ErrorMessage = "Musisz podać nazwę zespołu")]
        [StringLength(maximumLength: 100, ErrorMessage = "Zbyt długa nazwa zespołu, wpisz max 100 znaków")]
        public string Zespol { get; set; }

        [Display(Name = "Spis piosenek")]
        public string Spis_piosenek { get; set; }

        [Display(Name = "Pozycja w rankingu")]
        [Range(1, int.MaxValue, ErrorMessage = "Pozycja w rankingu musi być większa niż 0")]
        public int Notowanie { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data wydania")]
        public DateTime Data_wydania { get; set; }

        [Display(Name = "Czas trwania [min]")]
        [Range(1, int.MaxValue, ErrorMessage = "Czas trwania musi być większy niż 0")]
        public int Czas_trwania { get; set; }


    }
}
