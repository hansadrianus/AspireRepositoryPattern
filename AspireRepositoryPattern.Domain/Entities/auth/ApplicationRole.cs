﻿using Domain.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Auth
{
    public class ApplicationRole : AuditableRoleEntity
    {
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
