using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate
{
    public partial class Car : IEntity
    {
        public int CarId { get; set; }

        public int BrandId { get; set; }

        public int ColorId { get; set; }

        public string? Description { get; set; }

        public int? Year { get; set; }

        public int? FirmId { get; set; }

        public decimal? DailyPrice { get; set; }

        public bool isAvailable { get; set; }

        public virtual Brand Brand { get; set; } = null!;

        public virtual Color Color { get; set; } = null!;

        public virtual ICollection<Rental> Rentals { get; } = new List<Rental>();
        public virtual ICollection<CarPicture> CarPictures { get; } = new List<CarPicture>();
    }
}
