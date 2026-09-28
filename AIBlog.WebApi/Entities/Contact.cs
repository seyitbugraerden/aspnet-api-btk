using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIBlog.WebApi.Entities
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Address { get; set; }
        public string MapLocation { get; set; }
    }
}