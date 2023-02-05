using Business.Abstract;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class FirmManager : IFirmService
    {
        IFirmDal _firmDal;
        public FirmManager(IFirmDal firmDal)
        {
            _firmDal = firmDal;
        }

        public IResult Add(Firm firm)
        {
            _firmDal.Add(firm);
            return new SuccessResult();
        }

        public IResult Delete(Firm firm)
        {
            _firmDal.Delete(firm);
            return new SuccessResult();
        }
        public IResult Update(Firm firm)
        {
            _firmDal.Update(firm);
            return new SuccessResult();
        }

        public IDataResult<Firm> GetFirmById(int id)
        {
            return new SuccessDataResult<Firm>(_firmDal.Get(c => c.FirmId == id));
        }

        public IDataResult<List<Firm>> GetFirms()
        {
            return new SuccessDataResult<List<Firm>>(_firmDal.GetAll());
        }
    }
}
