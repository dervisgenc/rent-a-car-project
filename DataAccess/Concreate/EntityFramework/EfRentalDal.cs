using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, Recapdbcontext>, IRentalDal
    {
        public bool CheckAvailablity(int carId)
        {
            using (Recapdbcontext context = new Recapdbcontext())
            {
                var result = from c in context.Cars where c.CarId == carId select c.isAvailable;
                             
                            
                return result.SingleOrDefault();
            }

        }

        public void SetAvailablityTrue(int carId)
        {
            using (Recapdbcontext context = new Recapdbcontext())
            {
                var car = new Car() { CarId = carId, isAvailable = true };
                context.Cars.Attach(car);
                context.Entry(car).Property(c => c.isAvailable).IsModified = true;
                context.SaveChanges();
            }
        }
        public void SetAvailablityFalse(int carId)
        {
            using (Recapdbcontext context = new Recapdbcontext())
            {
                var car = new Car() { CarId = carId, isAvailable = false };
                context.Cars.Attach(car);
                context.Entry(car).Property(c => c.isAvailable).IsModified = true;
                context.SaveChanges();
            }
        }
        public void SetRentDate(int rentalId)
        {
            using (Recapdbcontext context = new Recapdbcontext())
            {
                Rental rental = new Rental() { RentalId = rentalId, RentDate = DateOnly.FromDateTime(DateTime.Now) };
                context.Rentals.Attach(rental);
                context.Entry(rental).Property(c => c.RentDate).IsModified = true;
                context.SaveChanges();
            }
        }

        public void SetReturnDate(int rentalId)
        {
            using (Recapdbcontext context = new Recapdbcontext())
            {
                Rental rental = new Rental() { RentalId = rentalId, ReturnDate = DateOnly.FromDateTime(DateTime.Now) };
                context.Rentals.Attach(rental);
                context.Entry(rental).Property(c => c.ReturnDate).IsModified = true;
                context.SaveChanges();
            }
        }
    }
}
