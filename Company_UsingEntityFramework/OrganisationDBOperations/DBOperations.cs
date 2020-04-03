using Company_UsingEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Company_UsingEntityFramework.OrganisationDBOperations
{
    public class DBOperations
    {
        OrganisationContext oc;

        public DBOperations()
        {
            oc = new OrganisationContext();
        }

        /// <summary>
        /// Returns details of  all employees.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EmployeeModel> GetEmployeeDetails()
        {
            //OrganisationContext oc = new OrganisationContext();

            return oc.Employees
                    .Select(e => new EmployeeModel()
                    {
                        Id = e.Id,
                        EmpName = e.EmpName,
                        Email = e.Email,
                        Salary = e.Salary,
                        DeptId = e.DeptId,
                        BrandName = e.Laptops.FirstOrDefault(l => l.EmpId == e.Id).BrandName
                    }).ToList();
        }

        /// <summary>
        /// Returns details of employee whose Id is provided.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<EmployeeModel> GetEmployeeDetailsById(int id)
        {
           // OrganisationContext oc = new OrganisationContext();

            return oc.Employees
                    .Select(e => new EmployeeModel()
                    {
                        Id = e.Id,
                        EmpName = e.EmpName,
                        Email = e.Email,
                        Salary = e.Salary,
                        DeptId = e.DeptId,
                        BrandName = e.Laptops.FirstOrDefault(l => l.EmpId == e.Id).BrandName
                    }).Where(e => e.Id == id).ToList();
        }


        /// <summary>
        /// Fetches details of All Laptops in database.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LaptopModel> GetAllLaptops()
        {
            //OrganisationContext oc = new OrganisationContext();
            return oc.Laptops
                .Select(l => new LaptopModel()
                {
                    Id = l.Id,
                    BrandName = l.BrandName
                }).ToList();
        }

        /// <summary>
        /// Fetches details of All departments in database.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DepartmentModel> GetAllDepartments()
        {
           // OrganisationContext oc = new OrganisationContext();
            return oc.Departments
                .Select(d => new DepartmentModel()
                {
                    Id = d.Id,
                    DeptartmentName = d.DeptartmentName
                }).ToList();
        }


        /// <summary>
        /// Fetches details of Department on the basis pf department name provided.
        /// </summary>
        /// <param name="deptName"></param>
        /// <returns></returns>
        public IEnumerable<DepartmentEmpLap> GetDepartmentDetailsWithEmpLap(string deptName)
        {
            //OrganisationContext oc = new OrganisationContext();
            return oc.Departments
                .Select(d => new DepartmentEmpLap()
                {
                    Id = d.Id,
                    DeptName = d.DeptartmentName,
                    EmpName = d.Employees.FirstOrDefault(e => e.DeptId == d.Id).EmpName,
                    EmployeeId = d.Employees.FirstOrDefault(e => e.DeptId == d.Id).Id,
                    LaptopId = d.Employees.FirstOrDefault(e => e.DeptId == d.Id)
                                .Laptops.FirstOrDefault(laptop => laptop.EmpId == d.Employees.FirstOrDefault(e => e.DeptId == d.Id).Id)
                                 .Id,
                    BrandName = d.Employees.FirstOrDefault(e => e.DeptId == d.Id)
                                .Laptops.FirstOrDefault(laptop => laptop.EmpId == d.Employees.FirstOrDefault(e => e.DeptId == d.Id).Id)
                                .BrandName
                }).Where(d =>d.DeptName == deptName).ToList();
        }


        /// <summary>
        /// Fetches details of Laptop by the ID provided of the Laptop.  
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<LaptopEmpDept> GetLaptopDetailsWithEmpDept(int id)
        {
           // OrganisationContext oc = new OrganisationContext();
            return oc.Laptops
                .Select(laptop => new LaptopEmpDept()
                {   
                    Id= laptop.Id,
                    BrandName =laptop.BrandName,
                    EmpId =laptop.EmpId,
                    EmpName= laptop.Employee.EmpName,
                    DeptId=laptop.Employee.DeptId,
                    DeptName= laptop.Employee.Department.DeptartmentName 
                }).Where(Laptop =>Laptop.Id == id).ToList();
        }


        /// <summary>
        /// Fetches employees page vise on the basis of page number and page size provided.
        /// </summary>
        /// <param name="paging"></param>
        /// <returns></returns>
        public IEnumerable<EmployeeModel> GetEmployeePageVise([FromUri]PagingModal paging)
        { 
             //OrganisationContext oc = new OrganisationContext();
             var employee = oc.Employees.Select(emp => new EmployeeModel()
                 {
                     Id=  emp.Id,
                     EmpName = emp.EmpName,
                     Email = emp.Email,
                     Salary = emp.Salary,
                     DeptId = emp.DeptId,
                 }).OrderBy(e =>e.Id);
             int count = employee.Count();

             int CurrentPage = paging.PageNumber;

             int PageSize = paging.PageSize;
            
             int TotalCount = count;
        
             int TotalPages = (int)Math.Ceiling(count / (double)PageSize);

             var employeeList = employee.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
             
             return employeeList;
        }
        
    }
}
