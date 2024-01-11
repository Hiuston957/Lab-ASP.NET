using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium3.Models
{
  
    public class Album
    {
        [HiddenInput]
        public int Id { get; set; }

        public string Nazwa { get;set; }

        public string Zespol { get;set; }

        public List<string> Spis_piosenek { get; set; }

        public int Notowanie { get;set; }
        [DataType(DataType.Date)]
        public DateTime Data_wydania { get;set; }

        public List<TimeSpan> Czas_trwania { get; set; }

   
    }
}
