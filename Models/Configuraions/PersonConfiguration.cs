using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApp.Net.Core.Api.EF.Core.Angular.Models.Configuraions
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Age).IsRequired();

            /*modelBuilder.Entity<Persona>().ToTable(name:"PersonaTable", schema:"entities")
                .Property(p => p.Name).HasColumnName("personaName");*/
        }
    }
}
