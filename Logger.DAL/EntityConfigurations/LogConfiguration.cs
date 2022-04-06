using Logger.Entities.Log;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Logger.DAL.EntityConfigurations
{
    public class LogConfiguration : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable("Logs");

            builder.HasKey(l => l.Id);


            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.Message)
                .HasColumnName("Message")
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            builder.Property(p => p.LogLevel)
                .HasColumnName("LogLevel")
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            builder.Property(p => p.Timestamp)
                .HasColumnName("Timestamp")
                .HasColumnType("smalldatetime")
                .IsRequired();
        }
    }
}
