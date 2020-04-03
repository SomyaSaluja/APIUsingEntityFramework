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
    public class LaptopController : ApiController
    {
       
        [HttpGet]
        public IEnumerable<LaptopModel> Get()
        {
            DBOperations dbo = new DBOperations();
            return dbo.GetAllLaptops();
        }

        public IEnumerable<LaptopEmpDept> Get(int id)
        {
            DBOperations dbo = new DBOperations();
            return dbo.GetLaptopDetailsWithEmpDept(id);
        }
    }
}
