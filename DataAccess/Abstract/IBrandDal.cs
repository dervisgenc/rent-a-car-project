using Core.DataAccess;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IBrandDal : IEntitiyRepository<Brand>
    {
        //List<Brand> GetAllBrands();
        //void AddBrand(Brand brand);
        //void DeleteBrand(Brand brand);
        //void UpdateBrand(Brand brand);
        //List<Brand> GetCarsByBrandId(int brandId);
    }
}
