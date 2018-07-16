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
        public DbSet<Calculation> Calculations { get; set; }
        public DbSet<Person> Persons { get; set; }

        public DbSet<CalculationType> CalculationTypes { get; set; }    
//        public DbSet<ExpressionDto> ExpressionDtos { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expression>()
                .ToTable("Calculations");

//            modelBuilder.Entity<Expression>()
//                .Ignore(e => e.LeftHand)
//                .Ignore(e => e.RightHand);

            modelBuilder.Entity<Expression>()
                .Property(e => e.ExpressionAsString)
                .HasColumnName("Calculation")
                .IsRequired()
                .HasColumnOrder(2);

            modelBuilder.Entity<Expression>()
                .Property(e => e.DateCreated)
                .HasColumnName("Date")
                .HasColumnOrder(5);

            modelBuilder.Entity<Expression>()
                .Property(e => e.Operation)
                .HasColumnOrder(3)
                .HasColumnName("Operation");

            modelBuilder.Entity<Expression>()
                .Property(e => e.Val)
                .HasColumnOrder(4)
                .HasColumnName("Result");

            modelBuilder.Entity<Expression>()
                .HasRequired(e => e.LeftHand)
                .WithRequiredDependent();

            modelBuilder.Entity<Expression>()
                .HasRequired(e => e.RightHand)
                .WithRequiredDependent();

            modelBuilder.Properties<string>()
                .Configure(configuration => configuration
                    .HasMaxLength(4000));

            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());

//            modelBuilder.Configurations.Add(new EntityTypeConfiguration.ExpressionConfiguration());
        }
    }
}