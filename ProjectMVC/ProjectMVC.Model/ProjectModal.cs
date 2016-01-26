using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjectMVC.Model
{
    public class ProjectModal
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Project Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Location")]
        public string Location { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
    }
}
