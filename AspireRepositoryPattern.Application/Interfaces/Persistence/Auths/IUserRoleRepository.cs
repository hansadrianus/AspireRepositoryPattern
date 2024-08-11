﻿using AspireRepositoryPattern.Domain.Entities.auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Persistence.Auths
{
    public interface IUserRoleRepository : IRepositoryBase<ApplicationUserRole>
    {
    }
}
