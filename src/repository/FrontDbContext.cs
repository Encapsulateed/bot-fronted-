using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace front_bot.src.repository;

public partial class FrontDbContext : DbContext
{
    public FrontDbContext()
    {
    }

    public FrontDbContext(DbContextOptions<FrontDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("SQL_CONNECTION"));


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.ChatId).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.ChatId)
                .ValueGeneratedNever()
                .HasColumnName("chatId");
            entity.Property(e => e.Command)
                .HasMaxLength(128)
                .HasColumnName("command");
            entity.Property(e => e.Email)
                .HasMaxLength(128)
                .HasColumnName("email");
            entity.Property(e => e.Jwt)
                .HasMaxLength(512)
                .HasColumnName("JWT");
            entity.Property(e => e.Password)
                .HasMaxLength(512)
                .HasColumnName("password");
            entity.Property(e => e.Uuid)
                .HasMaxLength(36)
                .HasColumnName("uuid");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
