using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Data.Entities
{
    public class OrganizationEntity
    {
        public int OrganizationEntityId { get; set; }
        public string Title { get; set; }
        public string Regon { get; set; }
        public string Nip { get; set; }
        public Address? Address { get; set; }
        public ISet<ContactEntity> Contacts { get; set; }

    }





}

