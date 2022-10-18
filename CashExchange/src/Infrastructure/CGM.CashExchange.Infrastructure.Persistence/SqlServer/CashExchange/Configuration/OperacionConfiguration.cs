using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGM.CashExchange.Core.Domain.Entities;

namespace CGM.Infrastructure.Persistence.SqlServer.Configuration
{


    public class OperacionConfiguration : IEntityTypeConfiguration<Operacion>
    {
        public void Configure(EntityTypeBuilder<Operacion> builder)
        {
            builder.ToTable("Operacion");
            builder.Property(t => t.IdFicha).ValueGeneratedOnAdd();
            builder.HasKey(t => t.IdFicha);

            builder.OwnsOne(x => x.Monto)
                .Property(x => x.Value)
                .HasColumnName("Monto")
             
                .IsRequired();


            builder.Property(x => x.FechaCreacion)
            .HasComment("Fecha de creación de la ficha.").IsRequired();

            builder.Property(x => x.FechaCancelacion)
            .HasComment("Fecha de cancelación de la ficha.");

            //builder.UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.IdCajero)
            .HasComment("Código identificador del cajero.").IsRequired();


            builder.Property(x => x.IdOperacionMaccord).HasComment("Código operación de operación maccord.").IsRequired();




            builder.Property(t => t.Estado)
               .HasColumnType("int")
               .HasComment("Estado de la ficha.");
        }
    }
}
