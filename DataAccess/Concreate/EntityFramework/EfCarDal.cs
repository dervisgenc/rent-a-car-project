using DataAccess.Abstract;
using Core.Entity;
using Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.DTOs;

namespace DataAccess.Concreate.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, Recapdbcontext>, ICarDal
    {
        //public void SetAvailablityFalse(int carId)
        //{
        //    using (Recapdbcontext context = new Recapdbcontext())
        //    {
        //        var car = new Car() { CarId=carId, isAvailable=false} ;
        //        context.Cars.Attach(car);
        //        context.Entry(car).Property(c=>c.isAvailable).IsModified=true;
        //        context.SaveChanges();
        //    }
        //}
        //public void SetAvailablityTrue(int carId)
        //{
        //    using (Recapdbcontext context = new Recapdbcontext())
        //    {
        //        var car = new Car() { CarId = carId, isAvailable = true };
        //        context.Cars.Attach(car);
        //        context.Entry(car).Property(c => c.isAvailable).IsModified = true;
        //        context.SaveChanges();
        //    }
        //}

        public List<CarDetailDto> GetCarDetails()
        {
            using (Recapdbcontext context = new Recapdbcontext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join cl in context.Colors on c.ColorId equals cl.ColorId
                             select new CarDetailDto
                             {

                                 CarId = c.CarId,
                                 ColorName = cl.ColorName,
                                 BrandName = b.BrandName,
                                 Description = c.Description,
                                 Year = c.Year,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }

        public int BrandsNumbers()
        {
            using (Recapdbcontext context = new Recapdbcontext())
            {
                var result = from b in context.Brands select new Brand();
                return result.ToList().Count();
            }
        }
    }
}
