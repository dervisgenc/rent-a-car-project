using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate
{
    public partial class Firm : IEntity
    {
        public string FirmName { get; set; } = null!;

        public int FirmId { get; set; }

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public virtual ICollection<Rental> Rentals { get; } = new List<Rental>();
    }
}
