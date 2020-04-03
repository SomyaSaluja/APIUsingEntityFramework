using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Company_UsingEntityFramework.Models
{
    public class PagingModal
    {
        const int maxPageSize = 15;  
  
        public int PageNumber { get; set; }   
  
        public int PageSize { get; set; }  
  
       
    }
}