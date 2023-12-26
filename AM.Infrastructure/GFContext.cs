using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AM.Infrastructure
{
    public class GFContext: DbContext
    {
        public DbSet<Artiste> Artistes { get; set; }
        public DbSet<Chanson> Chansons { get; set; }
        public DbSet<Festival> Festivals { get; set; }
        public DbSet<Concert> Concerts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
              Initial Catalog=FestDB;Integrated Security=true;
              MultipleActiveResultSets=true");
                 
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
              modelBuilder.ApplyConvention(new MaxLengthStringPropertyConvention());

            builder.HasOne(t => t.Fete).WithMany(f => f.Invitations).HasForeignKey(t => t.FeteFk);
            builder.HasOne(t => t.Invite).WithMany(p => p.Invitations).HasForeignKey(t => t.InviteFk);
           builder.HasKey(t => new
            {
                t.FeteFk,
                t.InviteFk,
                t.DateInvitation,

            });

                base.OnModelCreating(modelBuilder);


        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            //    // Pre-convention model configuration goes here
            //    configurationBuilder
            //        .Properties<string>()
            //        .HaveMaxLength(50);
            //configurationBuilder
            //    .Properties<decimal>()
            //        .HavePrecision(8,3);
            configurationBuilder
              .Properties<string>().HaveMaxLength(30);
        }



    }
}
