using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class AuditableUserClaimEntity : IdentityUserClaim<int>, IAuditableEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedTimeUTC { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedTimeUTC { get; set; }
        [Timestamp, ConcurrencyCheck]
        public byte[] RowVersion { get; set; }
        public short RowStatus { get; set; }
    }
}
