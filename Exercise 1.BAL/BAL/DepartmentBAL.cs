﻿using Exercise_1.DAL.DAL;
using Exercise_1.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1.BAL.BAL
{
    public class DepartmentBAL
    {
        DepartmentDAL dal = new DepartmentDAL();
        public List<DepartmentDTO> ReadDepartmentList()
        {
            List<DepartmentDTO> departments = dal.ReadDepartmentList();
            return departments;
        }
    }
}
