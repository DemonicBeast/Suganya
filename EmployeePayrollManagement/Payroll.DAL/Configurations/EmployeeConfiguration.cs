using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payroll.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.DAL.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.EmployeeID);
            builder.Property(e => e.EmployeeID).UseIdentityColumn();

            builder.Property(e => e.EmployeeName).IsRequired().HasMaxLength(255);
            builder.Property(e => e.EmployeeCode).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Designation).IsRequired().HasMaxLength(255);
            builder.Property(e => e.Address).HasMaxLength(1000);
            builder.Property(e => e.Salary).HasColumnType("Decimal(18,2)");
            builder.Property(e => e.JoiningDate).HasColumnType("DateTime");

            builder.ToTable("Employees");
        }
    }
}
