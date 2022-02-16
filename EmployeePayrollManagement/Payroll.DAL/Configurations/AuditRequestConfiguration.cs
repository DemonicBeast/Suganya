using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payroll.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.DAL.Configurations
{
    public class AuditRequestConfiguration : IEntityTypeConfiguration<AuditRequest>
    {
        public void Configure(EntityTypeBuilder<AuditRequest> builder)
        {
            builder.HasKey(m => m.AuditRequestID);
            builder.Property(m => m.AuditRequestID).UseIdentityColumn();
            builder.Property(m => m.RequestedURL).HasMaxLength(1000);
            builder.Property(m => m.RequestedController).HasMaxLength(200);
            builder.Property(m => m.RequestedActionMethod).HasMaxLength(200);
            builder.Property(m => m.RequestedDateTime).HasColumnType("DateTime");
            builder.ToTable("AuditRequests");
        }
    }
}
