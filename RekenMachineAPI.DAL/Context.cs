using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Reflection;
using RekenMachineAPI.DAL.EntityTypeConfiguration;
using RekenMachineAPI.DAL.Migrations;
using RekenMachineAPI.Domain;

namespace RekenMachineAPI.DAL
{
    public class Context : DbContext
    {
//        public DbSet<Calculation> Calculations { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<CalculationType> CalculationTypes { get; set; }    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<string>()
                .Configure(configuration => configuration
                    .HasMaxLength(4000));

            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}