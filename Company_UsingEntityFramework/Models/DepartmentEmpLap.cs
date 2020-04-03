using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Company_UsingEntityFramework.Models
{
    public class DepartmentEmpLap
    {
        public int Id { get; set; }
        public string DeptName { get; set; }
        public string EmpName { get; set; }
        public int EmployeeId { get; set; }
        public int LaptopId { get; set; }
        public string BrandName { get; set; }
    }
}