using Core.Utilities.Results;
using Entities.Concreate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarPictureService
    {
        IDataResult<CarPicture> GetCarPicture(int carPictureId);
        IResult Add(IFormFile formFile, CarPicture carPicture);
    }
}
