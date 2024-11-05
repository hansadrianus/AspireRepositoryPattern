using Application.Interfaces.Persistence;
using Application.Interfaces.Persistence.Auths;
using Domain.Entities.Auth;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Auths
{
    public class RoleRepository : RepositoryBase<ApplicationRole>, IRoleRepository
    {
        public RoleRepository(IApplicationContext context, IDistributedCache distCache, IConfiguration configuration) : base(context, distCache, configuration)
        {
        }
    }
}
