using Core.Utilities.Results;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetBrands();
        IDataResult<Brand> GetBrandById(int id);
        IResult Add(Brand brand);
        IResult Update(Brand brand);
        IResult Delete(Brand brand);   
    }
}
