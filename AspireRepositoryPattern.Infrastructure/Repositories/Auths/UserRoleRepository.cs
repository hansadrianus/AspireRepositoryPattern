using Application.Interfaces.Persistence;
using Application.Interfaces.Persistence.Auths;
using Domain.Entities.Auth;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repositories.Auths
{
    public class UserRoleRepository : RepositoryBase<ApplicationUserRole>, IUserRoleRepository
    {
        public UserRoleRepository(IApplicationContext context, IDistributedCache distCache, IConfiguration configuration) : base(context, distCache, configuration)
        {
        }
    }
}
