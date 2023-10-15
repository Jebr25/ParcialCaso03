using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ParcialCaso03.DOMAIN.Core.Entities;

namespace ParcialCaso03.DOMAIN.Infrastructure.Data;

public partial class Dpa202302parcialCaso0320200136Context : DbContext
{
    public Dpa202302parcialCaso0320200136Context()
    {
    }

    public Dpa202302parcialCaso0320200136Context(DbContextOptions<Dpa202302parcialCaso0320200136Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Territory> Territory { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=WS2302504;Database=DPA202302ParcialCaso0320200136;Integrated Security=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Territory>(entity =>
        {
            entity.Property(e => e.Area).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Population)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
