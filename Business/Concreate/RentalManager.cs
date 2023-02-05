using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        //ICarDal _carDal;
        //public RentalManager(IRentalDal rentalDal, ICarDal carDal) : this(rentalDal)
        //{
        //    //_rentalDal = rentalDal;
        //    _carDal = carDal;
        //}
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        private IResult Check(Rental rental)
        {

            if (_rentalDal.CheckAvailablity(rental.CarId))
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CarNotAvaible);
        }

        public IResult Add(Rental rental)
        {
            //ICarDal _carDal;
            if (Check(rental).Success)
            {
                _rentalDal.Add(rental);
                _rentalDal.SetAvailablityFalse(rental.CarId);
                _rentalDal.SetRentDate(rental.RentalId);
                return new SuccessResult();
            }
            //Console.WriteLine("Araba dolu");
            return new ErrorResult();
        }

        public IResult Delete(Rental rental)
        {
            //set return date
            _rentalDal.SetAvailablityTrue(rental.CarId); 
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }

        public IDataResult<Rental> GetRentalById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(c => c.RentalId == id));
        }

        public IDataResult<List<Rental>> GetRentals()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }
    }
}
