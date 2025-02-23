
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Data.Entities;

namespace Business.Models;

public class Customer
{

    public int Id { get; set; }

    public string CustomerName { get; set; } = null!;

    public virtual ICollection<ProjectsEntity> Projects { get; set; } = [];

    public virtual ICollection<CustomerContacts> Contacts { get; set; } = [];
    

}


   