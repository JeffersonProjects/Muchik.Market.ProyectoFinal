using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muchik.market.infrasctructure.crosscutting.Jwt
{
    public interface IJwtManager
    {
        string GenerateToken(string username, string role);
    }
}
