using muchik.market.security.domain.entities;
using muchik.market.security.domain.interfaces;
using muchik.market.security.infraestructure.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muchik.market.security.infraestructure.repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(SecurityContext context) : base(context) { }
    }
}
