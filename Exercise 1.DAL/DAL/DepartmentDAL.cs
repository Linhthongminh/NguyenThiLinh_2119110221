using Exercise_1.DAL.Employee;
using Exercise_1.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1.DAL.DAL
{
    public class DepartmentDAL : DBConnection
    {
        public List<DepartmentDTO> ReadDepartmentList()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Department", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<DepartmentDTO> departments = new List<DepartmentDTO>();
            while (reader.Read())
            {
                DepartmentDTO department = new DepartmentDTO();
                department.ID_Department = reader["ID_Department"].ToString();
                department.Name = reader["name"].ToString();
                departments.Add(department);
            }
            conn.Close();
            return departments;
        }

        public DepartmentDTO ReadDepartment(int id)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Department where id = " + id.ToString(), conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DepartmentDTO department = new DepartmentDTO();
            if (reader.HasRows && reader.Read())
            {
                department.ID_Department = reader["ID_Department"].ToString();
                department.Name = reader["Name"].ToString();
            }
            conn.Close();
            return department;
        }
    }
}
