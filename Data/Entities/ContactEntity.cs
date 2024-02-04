using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("contacts")]
    public class ContactEntity
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [MaxLength(50)]
        [Required]
        public string Email { get; set; }
        [MaxLength(12)]
        [MinLength(9)]
        public string Phone { get; set; }
        [Column("birth_date")]
        public DateTime Birth { get; set; }
        public int OrganizationId { get; set; }
        public OrganizationEntity? Organization { get; set; }
    }





}

