using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate
{
    public partial class Brand : IEntity
    {
        public int BrandId { get; set; }

        public string BrandName { get; set; } = null!;

        public virtual ICollection<Car> Cars { get; } = new List<Car>();
    }
}
