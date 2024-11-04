using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public interface IAuditableEntity
    {
        string CreatedBy { get; set; }
        DateTime CreatedTimeUTC { get; set; }
        string? ModifiedBy { get; set; }
        DateTime? ModifiedTimeUTC { get; set; }
        byte[] RowVersion { get; set; }
        short RowStatus { get; set; }
    }
}
