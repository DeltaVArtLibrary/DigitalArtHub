using ArtHub.Models;
using ArtHub.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ArtHub.Data
{
    public class ArtHubDbContext : IdentityDbContext<ApplicationUser>
    {
        public ArtHubDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Collection> Collections { get; set; }        
        public DbSet<Art> Art { get; set; }
        public DbSet<ArtCollection> ArtCollections { get; set; }
        public DbSet<ProfileMember> ProfileMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ArtCollection>().HasKey(artCollection => new
            {
                artCollection.ArtId,
                artCollection.CollectionId
            });
            builder.Entity<ProfileMember>()
                .HasKey(profileMember => new
                {
                    profileMember.ProfileId,
                    profileMember.UserId
                });
        }
    }
}
