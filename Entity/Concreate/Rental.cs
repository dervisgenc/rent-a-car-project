using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate
{
    public partial class Rental : IEntity
    {
        public int RentalId { get; set; }

        public int CarId { get; set; }

        public int CustomerId { get; set; }

        public int FirmId { get; set; }

        public DateOnly RentDate { get; set; }

        public DateOnly? ReturnDate { get; set; }

        public virtual Car Car { get; set; } = null!;

        public virtual Customer Customer { get; set; } = null!;

        public virtual Firm Firm { get; set; } = null!;
    }
}
