using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concreate.EntityFramework;
using DataAccess.Concreate.InMemory;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal _carDal)
        {
            this._carDal = _carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            //ValidationTool.Validate(new CarValidator(),car);

            IResult result = BusinessRules.Run(CheckIfCarCountOfBrandCorrect(car.BrandId), CheckIfDescriptionSame(car.Description),CheckIfBrandsAreFull());



            if (result != null)
            {
                return result;
            }
            return new SuccessResult(Messages.CarAdded );

        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult("Car updated");
        }
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult("Car deleted");
        }

        public IDataResult<List<Car>> GetAllByBrand(int id)
        {
            
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id).ToList());
        }

        public IDataResult<List<Car>> GetAllByColor(int id)
        {
            
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id).ToList());
        }

        public IDataResult<List<Car>> GetAllByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice <= max && c.DailyPrice >= min));
        }

        public IDataResult<List<Car>> GetAllCars()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c=>c.CarId==id));
        }
        private IResult CheckIfCarCountOfBrandCorrect(int brandId)
        {
            if (_carDal.GetAll(c=>c.BrandId==brandId).Count<15)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CarCountOfBrandError);
        }
        private IResult CheckIfDescriptionSame(string description) 
        {
 
            if (_carDal.GetAll(c => c.Description.Equals(description)).Any())
            {
                return new SuccessResult();

            }
            return new ErrorResult(Messages.CarExist);
        }
        private IResult CheckIfBrandsAreFull()
        {
            if (_carDal.BrandsNumbers() > 15)
            {
                return new ErrorResult(Messages.BrandsAreFull);
            }
            return new SuccessResult(); 
        }
    }
}
