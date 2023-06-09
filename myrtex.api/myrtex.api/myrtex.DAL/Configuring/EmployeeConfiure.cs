using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using myrtex.Domain.Models;

namespace myrtex.DAL.Configuring
{
    /// <summary>
    /// Конфигурация модели для БД
    /// </summary>
    public class EmployeeConfiure: IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("employees");
            builder.HasKey(k => k.Id);
            
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Birthday).HasColumnName("birthday");
            builder.Property(p => p.Department).HasColumnName("department");
            builder.Property(p => p.Salary).HasColumnName("salary");
            builder.Property(p => p.FullName).HasColumnName("fullname");
            builder.Property(p => p.JobStart).HasColumnName("jobstart");
        }
    }
}