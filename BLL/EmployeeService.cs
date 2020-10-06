using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BLL
{
    public interface IEmployeeService
    {
        //EmployeeBLLModel FetchById(long id);
        List<EmployeeBLLModel> FetchAll(bool includeRetired = false);

        //   List<EmployeeBLLModel> FetchAllIncldueRetired();
        //void Update(EmployeeBLLModel model);
        void Add(EmployeeBLLModel model);
        //void Delete(long id);
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly IDalService _dataAccessService;

        public EmployeeService(IDalService dataAccessService)
        {
            // _dataAccessService = new DataAccessService();
            _dataAccessService = dataAccessService;
        }

        public EmployeeBLLModel FetchById(long id)
        {
            var result = new EmployeeBLLModel();
            //try
            //{
            //    result = _dataAccessService.f.FetchEmployee(id);

            //}
            //catch (Exception e)
            //{
            //    //
            //}

            return result;
        }


        public List<EmployeeBLLModel> FetchAll(bool includeRetired)
        {
            var result = new List<EmployeeBLLModel>();
            try
            {

                if (includeRetired == true)
                {
                    result = _dataAccessService.FetchAllEmployee();
                }
                else
                {
                    result = _dataAccessService.FetchAllEmployee()
                        .Where(x => x.IsRetired == false).ToList();
                }
                result = _dataAccessService.FetchAllEmployee(); //.OrderBy(x => x.Sequence);
                //result = result.Where(x => includeRetired || x.IsRetired == false).ToList();
            }
            catch (Exception e)
            {
                //result.Errors.Add(e.BuildExceptionMessage());
            }
            return result;
        }

        public void Update(EmployeeBLLModel model)
        {
            try
            {
                //var checkResults = CheckForDuplicates(model);
                //if (checkResults.Any())
                //{
                //    result.Errors = checkResults;
                //}
                //else
                //{
                _dataAccessService.UpdateEmployee(model);
                //}
            }
            catch (Exception e)
            {
                // result.Errors.Add(e.BuildExceptionMessage());
            }

        }

        public void Add(EmployeeBLLModel model)
        {

            //var checkResults = CheckForDuplicates(model);
            //if (checkResults.Any())
            //{
            //    result.Errors = checkResults;
            //}
            //else
            //{
            _dataAccessService.AddEmployee(model);

            //}


        }

        public void Delete(long id)
        {
            //send email -- check any business validation 
            _dataAccessService.DeleteEmployee(id);
        }

        private List<string> CheckForDuplicates(EmployeeBLLModel model)
        {
            var errors = new List<string>();
            var duplicateModel = _dataAccessService.FetchAllEmployee()
                .FirstOrDefault(x => (x.Name.Equals(model.Name,
                                         StringComparison.CurrentCultureIgnoreCase)) &&
                                     x.EmployeeId != model.EmployeeId);
            if (duplicateModel != null)
            {
                errors.Add(duplicateModel.Name.Equals(model.Name, StringComparison.OrdinalIgnoreCase)
                    ? "Errors.EmployeeNameExists"
                    : "Errors.EmployeeCodeExists");

            }
            return errors;
        }

    }
}

