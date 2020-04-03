using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Company_UsingEntityFramework.Models
{
    public class EmployeeModel
    {

        public int Id { get; set; }
        public string EmpName { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
        public int DeptId { get; set; }
        public string BrandName { get; set; }
    }
}