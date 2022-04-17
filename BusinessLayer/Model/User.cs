using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class User
    {
        public Guid UserId { get; set; }
        public String UserName { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        
        public UserType Type { get; set; }

        public string Password { get; set; }
    }
}
