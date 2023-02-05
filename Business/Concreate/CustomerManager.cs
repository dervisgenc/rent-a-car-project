using Business.Abstract;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concreate.EntityFramework;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult();
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult();
        }
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult();
        }

        public IDataResult<Customer> GetCustomerById(int id)
        {
           return new SuccessDataResult<Customer>(_customerDal.Get(c=>c.CustomerId==id));
        }

        public IDataResult<List<Customer>> GetCustomers()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

    }
}
