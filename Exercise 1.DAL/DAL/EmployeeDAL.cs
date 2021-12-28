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
                employee.ID_Employee = reader["ID_Employee"].ToString();
                employee.Name = reader["Name"].ToString();
                employee.DateBirth = reader["DateBirth"].ToString();
                employee.Gender = (bool)reader["Gender"];
                employee.PlaceBirth = reader["PlaceBirth"].ToString();
                employee.ID_Department = departmentDAL.ReadDepartment(reader["ID_Department"].ToString());
                employees.Add(employee);
            }
            conn.Close();
            return employees;
        }

        public void EditEmployee(EmployeeDTO employee)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("update Employee set Name = @Name, DateBirth = @DateBirth, PlaceBirth = @PlaceBirth, ID_Department = @ID_Department where ID_Employee = @ID_Employee", conn);
            cmd.Parameters.Add(new SqlParameter("@ID_Employee", employee.ID_Employee));
            cmd.Parameters.Add(new SqlParameter("@Name", employee.Name));
            cmd.Parameters.Add(new SqlParameter("@DateBirth", employee.DateBirth));
            cmd.Parameters.Add(new SqlParameter("@PlaceBirth", employee.PlaceBirth));
            cmd.Parameters.Add(new SqlParameter("@ID_Department", employee.ID_Department.ID_Department));
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteEmployee(EmployeeDTO employee)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from Employee where ID_Employee = @ID_Employee", conn);
            cmd.Parameters.Add(new SqlParameter("@ID_Employee", employee.ID_Employee));
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void NewEmployee(EmployeeDTO employee)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("update Employee set Name = @Name, ID_Department = @ID_Department where ID_Employee = @ID_Employee", conn);
            cmd.Parameters.Add(new SqlParameter("@ID_Employee", employee.ID_Employee));
            cmd.Parameters.Add(new SqlParameter("@Name", employee.Name));
            cmd.Parameters.Add(new SqlParameter("@DateBirth", employee.DateBirth));
            cmd.Parameters.Add(new SqlParameter("@PlaceBirth", employee.PlaceBirth));
            cmd.Parameters.Add(new SqlParameter("@ID_Department", employee.ID_Department.ID_Department));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
