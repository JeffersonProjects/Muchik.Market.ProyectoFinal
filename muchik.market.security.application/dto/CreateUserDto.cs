using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muchik.market.security.application.dto
{
    public class CreateUserDto
    {
        public string username { get; set; } = null!;
        public string password { get; set; } = null!;
    }
}
