using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWithAungular.Models
{
    public class UserDetails
    {
        
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserType { get; set; }
        public string EmailId { get; set; }
    }
}
