using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIBlog.WebApi.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
    }
}