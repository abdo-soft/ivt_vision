using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{


 public class DataC : DbContext


{
    public DataC(DbContextOptions<DataC> options)
       : base(options)
    {


    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>().Property(x => x.id).HasDefaultValueSql("NEWID()");
        modelBuilder.Entity<CServices>().Property(x => x.id).HasDefaultValueSql("NEWID()");
           // modelBuilder.Entity<ٍSubServices>().Property(x => x.id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Partners>().Property(x => x.id).HasDefaultValueSql("NEWID()");
       /* modelBuilder.Entity<Category>().HasData(
            new Category()
            {
                id = Guid.NewGuid(),
                Cname = "Technology",
                Description = "desc Technology",
                ImageUrl = "avatar.jpg"
            }
            );*/
    }
    public DbSet<Category> Category { get; set; }
    public DbSet<CServices> CServices { get; set; }
        //public DbSet<CServices> SubServices { get; set; }
        public DbSet<Partners> Partners { get; set; }


}
}