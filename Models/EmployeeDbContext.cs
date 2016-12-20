using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace easy.teste.Models
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext()
            : base()
        {
            Database.SetInitializer<EmployeeDbContext>(new EmployeeDbContextInitializer());
        }

        public DbSet<Employee> Employees { get; set; }
    }

    public class EmployeeDbContextInitializer : DropCreateDatabaseIfModelChanges<EmployeeDbContext>
    {
        protected override void Seed(EmployeeDbContext context)
        {
            var list = new List<Employee>
            {
                new Employee { FirstName = "Edgar", LastName = "Lopes da Silva", Description = "Edgar Lopes da Silva", DateofBirth = DateTime.Now.AddYears(-42), Country = "BR", State="SP", Salary = 1000000, IsActive = true },
                new Employee { FirstName = "Brian", LastName = "Lopes da Silva", Description = "Brian Lopes da Silva", DateofBirth = DateTime.Now.AddYears(-15), Country = "BR", State="SP", Salary = 500000, IsActive = true },
                new Employee { FirstName = "Yasmin", LastName = "Lopes da Silva", Description = "Yasmin Lopes da Silva", DateofBirth = DateTime.Now.AddYears(-7), Country = "BR", State="SP", Salary = 500000, IsActive = true },
            };

            list.ForEach(m =>
            {
                context.Employees.Add(m);
            });

            context.SaveChanges();

            base.Seed(context);
        }
    }
}