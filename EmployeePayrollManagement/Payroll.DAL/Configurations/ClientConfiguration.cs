using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payroll.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.DAL.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.ClientID);
            builder.Property(c => c.ClientID).UseIdentityColumn();
            builder.Property(c => c.Name).IsRequired().HasMaxLength(255);
            builder.Property(c => c.Description).IsRequired().HasMaxLength(500);
            builder.Property(c => c.PayrollDate).HasColumnType("DateTime");
            builder.ToTable("Clients");
        }
    }
}
