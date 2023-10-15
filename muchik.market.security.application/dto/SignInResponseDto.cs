using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muchik.market.security.application.dto
{
    public class SignInResponseDto
    {
        public string Token { get; set; } = null!;
        public string Username { get; set; } = null!;
        public int Id { get; set; }
    }
}
