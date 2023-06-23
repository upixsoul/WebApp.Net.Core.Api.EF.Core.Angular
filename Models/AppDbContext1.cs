using Microsoft.EntityFrameworkCore;
using WebApp.Net.Core.Api.EF.Core.Angular.Models.Configuraions;

namespace WebApp.Net.Core.Api.EF.Core.Angular.Models
{
    public class AppDbContext1 : DbContext
    {
        public AppDbContext1(DbContextOptions options) : base(options)
        {
        }

        //Fluent Api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new PersonDetailConfiguration());
            modelBuilder.ApplyConfiguration(new SocialNetworkConfiguration());
            modelBuilder.ApplyConfiguration(new SocialNetworkDetailConfiguration());
            modelBuilder.ApplyConfiguration(new SocialNetworkServiceConfiguration());
            modelBuilder.ApplyConfiguration(new SocialNetworkSocialNetworkDetailConfiguration());
        }

        public DbSet<Person> Personas { get; set; }
        public DbSet<PersonDetail> PersonasDetails { get; set; }
        public DbSet<SocialNetwork> SocialNetworks { get; set; }
        public DbSet<SocialNetworkDetail> SocialNetworkDetails { get; set; }
        public DbSet<SocialNetworkService> SocialNetworkServices { get; set; }
        public DbSet<SocialNetworkSocialNetworkDetail> SocialNetworkSocialNetworkDetails { get; set; }
        // Many to Many NON-skip Navigation
        //Now is an Entiy
    }
}
