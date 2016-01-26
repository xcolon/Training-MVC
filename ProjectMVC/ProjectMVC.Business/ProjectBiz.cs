using AutoMapper;
using ProjectMVC.DataAccess;
using ProjectMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMVC.Business
{
    public class ProjectBiz
    {
        public static void Add(Model.ProjectModal project)
        {
            using (DataAccess.TeamDBEntities context = new DataAccess.TeamDBEntities())
            {
                Mapper.CreateMap<Model.ProjectModal, Project>();
                Project projectAdd = Mapper.Map<Project>(project);

                context.Projects.Add(projectAdd);

                context.SaveChanges();
            }
        }

        public static List<Model.DepartmentModel> BindDepartmentName()
        {
            using (DataAccess.TeamDBEntities context = new DataAccess.TeamDBEntities())
            {
                var listOfItem = context.Departments.Select(d => new DepartmentModel
                {
                    Name = d.Name,
                    Code = d.Code
                }).ToList();
                return listOfItem;
            }
        }

        public static List<Model.ProjectModal> ListOfProject()
        {
            using (DataAccess.TeamDBEntities context = new DataAccess.TeamDBEntities())
            {
                var listItem = (from p in context.Projects
                                select p).ToList();

                Mapper.CreateMap<Project, Model.ProjectModal>();
                List<Model.ProjectModal> item = Mapper.Map<List<ProjectModal>>(listItem);

                return item;
            }
        }

        public static Model.ProjectModal Edit(int id)
        {
            using (DataAccess.TeamDBEntities context = new DataAccess.TeamDBEntities())
            {
                var detail = (from d in context.Projects
                              where d.ID == id
                              select d).ToList();

                Mapper.CreateMap<Project, Model.ProjectModal>();
                ProjectModal projectDetail = Mapper.Map<Project, ProjectModal>(detail.FirstOrDefault());

                return projectDetail;
            }
        }

        public static void Update(Model.ProjectModal project)
        {
            using (DataAccess.TeamDBEntities context = new DataAccess.TeamDBEntities())
            {
                Project item = (from p in context.Projects
                                where p.ID == project.ID
                                select p).FirstOrDefault();

                Mapper.CreateMap<Model.ProjectModal, Project>();
                Mapper.Map(project, item);

                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (DataAccess.TeamDBEntities context = new DataAccess.TeamDBEntities())
            {
                var project = (from p in context.Projects
                               where p.ID == id
                               select p).FirstOrDefault();
                context.Projects.Attach(project);
                context.Projects.Remove(project);

                context.SaveChanges();
            }
        }

        public static List<Model.ProjectModal> Search(string name, string location)
        {
            List<Model.ProjectModal> queryData = ListOfProject();
            using (DataAccess.TeamDBEntities context = new DataAccess.TeamDBEntities())
            {
                if (!string.IsNullOrEmpty(name))
                {
                    queryData = queryData.Where(p => p.Name.Contains(name)).ToList();
                }
                if (!string.IsNullOrEmpty(location))
                {
                    queryData = queryData.Where(l => l.Location.Contains(location)).ToList();
                }
            }
            return queryData;
        }

    }
}

