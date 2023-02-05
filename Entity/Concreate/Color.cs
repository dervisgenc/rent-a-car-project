using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate
{
    public partial class Color : IEntity
    {
        public int ColorId { get; set; }

        public string ColorName { get; set; } = null!;

        public virtual ICollection<Car> Cars { get; } = new List<Car>();

    }
}
