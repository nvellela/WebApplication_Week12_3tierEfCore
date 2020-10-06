namespace WebApplication_Week12.Controllers
{
    public class EmployeeViewModel
    {

        public int Id { get; set; }    
        public string Name { get; set; }

        public int Salary { get; set; }

        public bool IsRetired { get; set; }
        public string SalarySuper { get; set; }
        public string SalaryColor { get; set; }
    }
}