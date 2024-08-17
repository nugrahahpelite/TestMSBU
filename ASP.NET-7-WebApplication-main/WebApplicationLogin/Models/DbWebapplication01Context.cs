using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationLogin.Models;

public partial class MSBU : DbContext
{
    public MSBU()
    {
    }

    public MSBU(DbContextOptions<MSBU> options)
        : base(options)
    {
    }

    public virtual DbSet<User> User { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){ }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            //entity.HasKey(e => e.userid).HasName("PK__users__B51D3DEAB1A558D6");

            entity.ToTable("user");

            entity.Property(e => e.userid).HasColumnName("userid");
          
           
            entity.Property(e => e.username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
            entity.Property(e => e.password)
             .HasMaxLength(50)
             .IsUnicode(false)
             .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
