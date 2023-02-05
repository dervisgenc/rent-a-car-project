using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concreate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Business.Concreate
{
    public class CarPictureManager : ICarPictureService
    {
        ICarPictureDal _carPictureDal;
        public CarPictureManager(ICarPictureDal carPictureDal)
        {
            _carPictureDal = carPictureDal;
        }

        public IResult Add(IFormFile formFile,CarPicture carPicture)
        {
           
            carPicture.Date = DateTime.Now;
            _carPictureDal.Add(carPicture);
            return new SuccessResult();
        }

        public IDataResult<CarPicture> GetCarPicture(int carPictureId)
        {
            return new SuccessDataResult<CarPicture>(_carPictureDal.Get(c => c.PictureId == carPictureId));
        }
    }
}
