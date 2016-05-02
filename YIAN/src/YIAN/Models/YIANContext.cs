using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace YIAN.Models
{
    public class YIANContext:IdentityDbContext<User,IdentityRole<long>,long>
    {
        public DbSet<Family> Familys { get; set; }
        public DbSet<FamilyMember> FamilyMembers { get; set; }
        public DbSet<FamilySituation> FamilySituations { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<LowLine> LowLines { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Family>(e =>
            {
                e.HasIndex(x => x.Id);
            });
            builder.Entity<Town>(e =>
            {
                e.HasIndex(x => x.Id);
                e.HasIndex(x => x.CreateTime);
            });
            builder.Entity<FamilyMember>(e =>
            {
                e.HasIndex(x => x.Id);
            });
            builder.Entity<FamilySituation>(e =>
            {
                e.HasIndex(x => x.Id);
            });
            builder.Entity<LowLine>(e =>
            {
                e.HasIndex(x => x.Id);
            });
        }
    }
}
