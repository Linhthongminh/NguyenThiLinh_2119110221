using Exercise_1.DTO.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1.DTO.DTO
{
    public class DepartmentDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<EmployeeDTO> employees { get; set; }
    }
}
