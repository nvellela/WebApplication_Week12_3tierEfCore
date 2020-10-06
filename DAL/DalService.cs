using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{

    public interface IDalService
    {
        List<EmployeeBLLModel> FetchAllEmployee();
        void DeleteEmployee(long id);
        void UpdateEmployee(EmployeeBLLModel model);
        void AddEmployee(EmployeeBLLModel model);
    }

    public class DALService : IDalService
    {

        private readonly DALContext context;
        public DALService(DALContext _context)
        {
            this.context = _context;
        }

        #region Employee CRUD functions

        public void AddEmployee(EmployeeBLLModel model)
        {
            var efModel = new Employee()
            {
                Name = model.Name,
                Salary = model.Salary,
                IsRetired = model.IsRetired
            };
            context.Employees.Add(efModel);
            context.SaveChanges();
        }

        public void DeleteEmployee(long id)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeBLLModel> FetchAllEmployee()
        {
            var efModel = context.Employees.ToList();
            var returnObject = new List<EmployeeBLLModel>();

            foreach (var item in efModel)
            {
                returnObject.Add(new EmployeeBLLModel()
                {
                    EmployeeId = item.EmployeeId,
                    Name = item.Name,
                    Salary = item.Salary,
                    IsRetired = item.IsRetired
                });
            }

            return returnObject;
        }

        public void UpdateEmployee(EmployeeBLLModel model)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
