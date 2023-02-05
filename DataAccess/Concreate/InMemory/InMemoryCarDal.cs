using DataAccess.Abstract;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.InMemory
{
    public class InMemoryCarDal 
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{CarId= 1,BrandId= 1,ColorId= 1,DailyPrice= 10,Description="Araba 1",Year=2020},
                new Car{CarId= 2,BrandId= 2,ColorId= 2,DailyPrice= 15,Description="Araba 2",Year=2010},
                new Car{CarId= 3,BrandId= 2,ColorId= 2,DailyPrice= 1,Description="Araba 3",Year=2021},
                new Car{CarId= 4,BrandId= 2,ColorId= 3,DailyPrice= 20,Description="Araba 4",Year=2019},
                new Car{CarId= 5,BrandId= 3,ColorId= 3,DailyPrice= 30,Description="Araba 5",Year=2020}
            };
        }
        public void AddCar(Car car)
        {
            _cars.Add(car);
        }

        public void DeleteCar(Car car)
        { 
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
           

        }   

        public Car GetByID(int id)
        {
            return _cars.Find(c => c.CarId == id);
        }

        public List<Car> GetAllCars()
        {
            return _cars;
        }

        public void UpdateCar(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;  
            carToUpdate.Year = car.Year;
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _cars.Where(c=>c.BrandId== brandId).ToList();
        }
    }
}
