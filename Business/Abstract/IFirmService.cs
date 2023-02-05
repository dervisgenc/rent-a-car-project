using Core.Utilities.Results;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFirmService
    {
        IDataResult<List<Firm>> GetFirms();
        IDataResult<Firm> GetFirmById(int id);
        IResult Add(Firm firm);
        IResult Update(Firm firm);
        IResult Delete(Firm firm);
    }
}
