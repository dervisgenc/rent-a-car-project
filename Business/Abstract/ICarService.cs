using Core.Utilities.Results;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAllCars();
        IDataResult<List<Car>> GetAllByBrand(int id);
        IDataResult<List<Car>> GetAllByDailyPrice(decimal min,decimal max);
        IDataResult<List<Car>> GetAllByColor(int id);
        IDataResult<Car> GetById(int id);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<CarDetailDto>> GetCarDetails();
    }
}
