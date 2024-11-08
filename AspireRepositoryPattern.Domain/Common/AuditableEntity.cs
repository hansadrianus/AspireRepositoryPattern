﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class AuditableEntity : IAuditableEntity, IUidAuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Uid { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTimeUTC { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedTimeUTC { get; set; }
        [Timestamp, ConcurrencyCheck]
        public byte[] RowVersion { get; set; }
        public short RowStatus { get; set; }
    }
}
