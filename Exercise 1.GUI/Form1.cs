using Exercise_1.BAL.BAL;
using Exercise_1.BAL.Employee;
using Exercise_1.DTO.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise_1.GUI
{
    public partial class Form1 : Form
    {
        EmployeeBAL employeeBAL = new EmployeeBAL();
        DepartmentBAL departmentBAL = new DepartmentBAL();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<DepartmentDTO> departments = employeeBAL.ReadEmployee();
            foreach (DepartmentDTO department in departments)
            {
                dgvEmployee.Rows.Add(customer.ID, customer.Name, customer.AreaName);
            }
            List<AreaBEL> areas = areaBAL.ReadAreaList();
            foreach (AreaBEL area in areas)
            {
                cbArea.Items.Add(area);
            }
            cbArea.DisplayMember = "name";
        }
    }
}
