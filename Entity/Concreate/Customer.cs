
using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate
{
    public class Customer : IEntity
    {
        public int CustomerId { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public int PhoneNumber { get; set; }

        public string? IdentityNumber { get; set; }

        public virtual ICollection<Rental> Rentals { get; } = new List<Rental>();
    }
}
