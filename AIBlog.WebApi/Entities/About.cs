using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIBlog.WebApi.Entities
{
    public class About
    {
        public int AboutId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}