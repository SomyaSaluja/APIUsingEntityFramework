using Company_UsingEntityFramework.Models;
using Company_UsingEntityFramework.OrganisationDBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Company_UsingEntityFramework.Controllers
{
    public class DepartmentController : ApiController
    {
        public IEnumerable<DepartmentModel> Get()
        {
            DBOperations dbo = new DBOperations();
            return dbo.GetAllDepartments();
        }

        public IEnumerable<DepartmentEmpLap> Get( string deptName)
        {
            DBOperations dbo = new DBOperations();
            return dbo.GetDepartmentDetailsWithEmpLap(deptName);
        }
    }
}
