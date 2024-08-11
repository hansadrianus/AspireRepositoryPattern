using Domain.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspireRepositoryPattern.Domain.Entities.auth
{
    public class ApplicationRole : AuditableRoleEntity
    {
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
