using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO
{
    public class UserDto
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
        public string eMail { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string password { get; set; }
    }
}
