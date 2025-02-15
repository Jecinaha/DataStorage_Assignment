using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Business.Models
{
    public class CustomerContacts
    {
      
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;
      
        public string LastName { get; set; } = null!;

    }
}
