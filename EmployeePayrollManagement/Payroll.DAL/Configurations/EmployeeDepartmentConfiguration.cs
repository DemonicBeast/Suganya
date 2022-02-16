using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payroll.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.DAL.Configurations
{
    public class EmployeeDepartmentConfiguration : IEntityTypeConfiguration<EmployeeDepartment>
    {
        public void Configure(EntityTypeBuilder<EmployeeDepartment> builder)
        {
            builder.HasKey(ed => ed.EmployeeDepartmentID);
            builder.Property(ed => ed.EmployeeDepartmentID).UseIdentityColumn();

            builder.HasOne<Employee>(e => e.Employee).WithMany(ed => ed.EmployeeDepartments).HasForeignKey(e => e.EmployeeID);
            builder.HasOne<Department>(d => d.Department).WithMany(ed => ed.EmployeeDepartments).HasForeignKey(e => e.DepartmentID);

            builder.ToTable("EmployeeDepartments");
        }
    }
}
