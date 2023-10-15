using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muchik.market.security.application.dto
{
    public class SignInRequestDto
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
