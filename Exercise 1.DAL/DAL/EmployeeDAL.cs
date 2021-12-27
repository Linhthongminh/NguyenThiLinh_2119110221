using Exercise_1.DAL.DAL;
using Exercise_1.DTO.Employee;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1.DAL.Employee
{
    public class EmployeeDAL : DBConnection
    {
        public List<EmployeeDTO> ReadEmployee()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Employee", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<EmployeeDTO> employees = new List<EmployeeDTO>();
            DepartmentDAL departmentDAL = new DepartmentDAL();
            while (reader.Read())
            {
                EmployeeDTO employee = new EmployeeDTO();
                employee.ID_Employee = int.Parse(reader["id"].ToString());
                employee.Name = reader["name"].ToString();
                employee.DateBirth = DateTime.Parse(reader["datebirth"].ToString());
                employee.Gender = int.Parse(reader["gender"].ToString());
                employee.PlaceBirth = reader["placebirth"].ToString();
                employee.ID_Department = departmentDAL.ReadDepartment(int.Parse(reader["id_area"].ToString()));
                employees.Add(employee);
            }
            conn.Close();
            return employees;
        }

        public void EditCustomer(EmployeeDTO employee)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("update Employee set name = @name, ID_Department = @ID_Department where ID_Employee = @ID_Employee", conn);
            cmd.Parameters.Add(new SqlParameter("@id", employee.ID_Department));
            cmd.Parameters.Add(new SqlParameter("@name", employee.Name));
            cmd.Parameters.Add(new SqlParameter("@id_area", employee.ID_Department.ID));
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteCustomer(EmployeeDTO employee)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from Employee where ID_Employee = @ID_Employee", conn);
            cmd.Parameters.Add(new SqlParameter("@ID_Employee", employee.ID_Employee));
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void NewCustomer(EmployeeDTO employee)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("update Employee set name = @name, ID_Department = @ID_Department where ID_Employee = @ID_Employee", conn);
            cmd.Parameters.Add(new SqlParameter("@id", employee.ID_Department));
            cmd.Parameters.Add(new SqlParameter("@name", employee.Name));
            cmd.Parameters.Add(new SqlParameter("@id_area", employee.ID_Department.ID));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
