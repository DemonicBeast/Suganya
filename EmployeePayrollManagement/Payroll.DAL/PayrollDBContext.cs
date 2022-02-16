using Microsoft.EntityFrameworkCore;
using Payroll.BL.Models;
using Payroll.DAL.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.DAL
{
    public class PayrollDBContext:DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }
        public DbSet<ClientDepartment> ClientDepartments { get; set; }
        public DbSet<AuditRequest> AuditRequests { get; set; }

        public PayrollDBContext(DbContextOptions<PayrollDBContext>opt)
            :base(opt)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DepartmentConfiguration());
            builder.ApplyConfiguration(new ClientConfiguration());
            builder.ApplyConfiguration(new ClientDeparmentConfiguration());
            builder.ApplyConfiguration(new EmployeeConfiguration());
            builder.ApplyConfiguration(new EmployeeDepartmentConfiguration());
            builder.ApplyConfiguration(new AuditRequestConfiguration());
        }
    }
}
