//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Company_UsingEntityFramework.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Project
    {
        public Project()
        {
            this.EmployeeProjects = new HashSet<EmployeeProject>();
        }
    
        public int Id { get; set; }
        public string ProjectName { get; set; }
    
        public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }
}
