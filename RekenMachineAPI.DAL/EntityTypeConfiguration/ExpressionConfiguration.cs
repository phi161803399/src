using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RekenMachineAPI.Domain;

namespace RekenMachineAPI.DAL.EntityTypeConfiguration
{
    class ExpressionConfiguration: EntityTypeConfiguration<Expression>
    {
        public ExpressionConfiguration()
        {
            ToTable("Calculations");

            Ignore(e => e.LeftHand)
            .Ignore(e => e.RightHand);

            Property(e => e.ExpressionAsString)
            .HasColumnName("Calculation")
            .IsRequired();

            Property(e => e.DateCreated)
            .HasColumnName("Date");

            Property(e => e.Operation)
            .HasColumnName("Operation");
            
            Property(e => e.Val)
            .HasColumnName("Result");
        }
    }
}
