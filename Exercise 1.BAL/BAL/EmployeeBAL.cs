using Exercise_1.DAL.Employee;
using Exercise_1.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1.BAL.Employee
{
    public class EmployeeBAL
    {
        EmployeeDAL dal = new EmployeeDAL();
        public List<DepartmentDTO> ReadEmployee()
        {
            List<DepartmentDTO> departments = dal.ReadEmployee();
            return departments;
        }

        public void NewEmployee(DepartmentDTO department)
        {
            dal.NewEmployee(department);
        }

        public void DeleteEmployee(DepartmentDTO department)
        {
            dal.DeleteEmployee(department);
        }

        public void EditEmployee(DepartmentDTO department)
        {
            dal.EditEmployee(department);
        }
    }
}
