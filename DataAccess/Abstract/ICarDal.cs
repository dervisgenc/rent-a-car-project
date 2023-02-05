using Core.DataAccess;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntitiyRepository<Car>
    {
        //List<Car> GetAllCars();
        //List<Car> GetCarsByBrandId(int brandId);
        //Car GetByID(int id);
        //void AddCar(Car car);
        //void UpdateCar(Car car);
        //void DeleteCar(Car car);

        List<CarDetailDto> GetCarDetails();
        //void SetAvailablityTrue(int carId);
        //void SetAvailablityFalse(int carId);
        int BrandsNumbers();


    }
}
