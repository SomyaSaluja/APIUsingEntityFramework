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
    public class EmployeeController : ApiController
    {

        public IEnumerable<EmployeeModel> Get(int id)
        {
            DBOperations dbo = new DBOperations();
            return dbo.GetEmployeeDetailsById(id);         
        }

        public IEnumerable<EmployeeModel> Get([FromUri]PagingModal paging)
        {
            DBOperations dbo = new DBOperations();
            return dbo.GetEmployeePageVise(paging);
        }

    }
}
