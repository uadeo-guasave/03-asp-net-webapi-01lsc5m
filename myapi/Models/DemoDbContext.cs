using System;
using Microsoft.EntityFrameworkCore;

namespace myapi.Models
{
  public class DemoDbContext : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data Source=Db/demo.db");
      base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // FLUENT API
      modelBuilder.Entity<User>(user =>
      {
        user.Property(u => u.Id).HasColumnName("id");
        user.Property(u => u.Firstname).HasColumnName("firstname");
        user.Property(u => u.Lastname).HasColumnName("lastname");
        user.Property(u => u.Email).HasColumnName("email");
        user.Property(u => u.Gender).HasColumnName("gender");
        user.Property(u => u.Name).HasColumnName("name");
        user.Property(u => u.Password).HasColumnName("password");

        user.HasIndex(u => u.Email).IsUnique();
        user.HasIndex(u => u.Name).IsUnique();

        // user.Property(u => u.Gender)
        //   .HasConversion(
        //     v => v.ToString(),
        //     v => (gender)Enum.Parse(typeof(gender), v)
        //   );
      });
      base.OnModelCreating(modelBuilder);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Editorial> Editorials { get; set; }

  }
}