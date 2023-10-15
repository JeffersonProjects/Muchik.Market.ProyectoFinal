using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muchik.market.security.application.dto
{
    public class UserDto
    {
        public int id_user { get; set; }
        public string username { get; set; } = null!;
        public string password { get; set; } = null!;
    }
}
