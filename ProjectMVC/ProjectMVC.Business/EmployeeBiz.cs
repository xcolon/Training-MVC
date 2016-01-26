using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMVC.Model;
using ProjectMVC.DataAccess;

namespace ProjectMVC.Business
{
    public class EmployeeBiz
    {
        public static List<Model.EmployeeModel> AllEmployee(DataTableModel datatableData)
        {
            using (DataAccess.TeamDBEntities context = new DataAccess.TeamDBEntities())
            {
                var emp = (from e in context.Employees
                           select e).ToList();

                Mapper.CreateMap<Employee, Model.EmployeeModel>();
                List<Model.EmployeeModel> item = Mapper.Map<List<EmployeeModel>>(emp);
                item = SortingColumn(datatableData, item);
                item = Page(datatableData.start, datatableData.length, item).ToList();
                item = SearchData(datatableData, item);
                return item;
            }
        }

        public static List<Model.EmployeeModel> Page(int start, int length, List<EmployeeModel> item)
        {
            return item.Skip(start).Take(length).ToList();
        }

        public static List<Model.EmployeeModel> SortingColumn(DataTableModel datatableData, List<EmployeeModel> item)
        {
            for (int i = 0; i < datatableData.order.Count; i++)
            {
                var columnName = datatableData.columns[int.Parse(datatableData.order[i]["column"])]["data"];

                switch (columnName)
                {
                    case "SSN":
                        item= (datatableData.order[i]["dir"] == "asc") ? item.OrderBy(a => a.SSN).ToList(): item.OrderByDescending(a => a.SSN).ToList();
                    //if (datatableData.order[i]["dir"] == "asc")
                    //{
                    //    item = item.OrderBy(a => a.SSN).ToList();
                    //}
                    //else
                    //{
                    //    item = item.OrderByDescending(a => a.SSN).ToList();
                    //}
                    break;

                    case "FirstName":
                        if (datatableData.order[i]["dir"] == "asc")
                        {
                            item = item.OrderBy(a => a.FirstName).ToList();
                        }
                        else
                        {
                            item = item.OrderByDescending(a => a.FirstName).ToList();
                        }
                        break;
                    case "LastName":
                        if (datatableData.order[i]["dir"] == "asc")
                        {
                            item = item.OrderBy(a => a.LastName).ToList();
                        }
                        else
                        {
                            item = item.OrderByDescending(a => a.LastName).ToList();
                        }
                        break;

                    case "MidName":
                        if (datatableData.order[i]["dir"] == "asc")
                        {
                            item = item.OrderBy(a => a.MidName).ToList();
                        }
                        else
                        {
                            item = item.OrderByDescending(a => a.MidName).ToList();
                        }
                        break;

                    case "Address":
                        if (datatableData.order[i]["dir"] == "asc")
                        {
                            item = item.OrderBy(a => a.Address).ToList();
                        }
                        else
                        {
                            item = item.OrderByDescending(a => a.Address).ToList();
                        }
                        break;

                    case "Gender":
                        if (datatableData.order[i]["dir"] == "asc")
                        {
                            item = item.OrderBy(a => a.Gender).ToList();
                        }
                        else
                        {
                            item = item.OrderByDescending(a => a.Gender).ToList();
                        }
                        break;

                    case "DepartmentName":
                        if (datatableData.order[i]["dir"] == "asc")
                        {
                            item = item.OrderBy(a => a.DepartmentName).ToList();
                        }
                        else
                        {
                            item = item.OrderByDescending(a => a.DepartmentName).ToList();
                        }
                        break;

                    case "Salary":
                        if (datatableData.order[i]["dir"] == "asc")
                        {
                            item = item.OrderBy(a => a.Salary).ToList();
                        }
                        else
                        {
                            item = item.OrderByDescending(a => a.Salary).ToList();
                        }
                        break;

                    case "Birthday":
                        if (datatableData.order[i]["dir"] == "asc")
                        {
                            item = item.OrderBy(a => a.Birthday).ToList();
                        }
                        else
                        {
                            item = item.OrderByDescending(a => a.Birthday).ToList();
                        }
                        break;
                }
            }
            return item;
        }

        public static List<Model.EmployeeModel> SearchData(DataTableModel datatableData, List<EmployeeModel> item)
        {
            return item.Where(d => d.SSN.Contains(datatableData.search["value"]) 
                    || d.FirstName.Contains(datatableData.search["value"]) 
                    || d.LastName.Contains(datatableData.search["value"])).ToList(); 
        }

        public static List<Model.EmployeeModel> BindDepartment()
        {
            using (DataAccess.TeamDBEntities context = new DataAccess.TeamDBEntities())
            {
                var listOfItem = context.Departments.Select(d => new EmployeeModel
                {
                    DepartmentName = d.Name,
                    DepartmentCode = d.Code
                }).ToList();
                return listOfItem;
            }
        }

        public static void Add(Model.EmployeeModel employee)
        {
            using(DataAccess.TeamDBEntities context = new DataAccess.TeamDBEntities())
            {
                Mapper.CreateMap<Model.EmployeeModel, Employee>();
                Employee employeeAdd = Mapper.Map<Employee>(employee);

                context.Employees.Add(employeeAdd);

                context.SaveChanges();
            }
        }
    }
}