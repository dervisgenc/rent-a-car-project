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
    public interface IRentalDal : IEntitiyRepository<Rental>
    {
        bool CheckAvailablity(int carId);
        void SetAvailablityFalse(int carId);
        void SetAvailablityTrue(int carId);
        void SetRentDate(int rentalId);
        void SetReturnDate(int rentalId);
    }
}
