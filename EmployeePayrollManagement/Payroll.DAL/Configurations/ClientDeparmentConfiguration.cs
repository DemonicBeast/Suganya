using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payroll.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.DAL.Configurations
{
    public class ClientDeparmentConfiguration : IEntityTypeConfiguration<ClientDepartment>
    {
        public void Configure(EntityTypeBuilder<ClientDepartment> builder)
        {
            builder.HasKey(cd => cd.ClientDepartmentID);
            builder.Property(cd => cd.ClientDepartmentID).UseIdentityColumn();

            builder.HasOne<Client>(c=>c.Client).WithMany(d => d.ClientDepartments).HasForeignKey(c => c.ClientID);
            builder.HasOne<Department>(d => d.Department).WithMany(cd => cd.ClientDepartments).HasForeignKey(d => d.DepartmentID);

            builder.ToTable("ClientDepartments");
        }
    }
}
