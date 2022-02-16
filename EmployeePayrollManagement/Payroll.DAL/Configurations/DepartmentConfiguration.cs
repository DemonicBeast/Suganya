using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payroll.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.DAL.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.DepartmentID);
            builder.Property(d => d.DepartmentID).UseIdentityColumn();
            builder.Property(d => d.Name).IsRequired().HasMaxLength(255);
            builder.Property(d => d.Description).IsRequired().HasMaxLength(500);
            builder.ToTable("Departments");
        }
    }
}
