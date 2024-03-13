using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CrudMvc.Models;

public partial class FormContactoDbContext : DbContext
{
    public FormContactoDbContext()
    {
    }

    public FormContactoDbContext(DbContextOptions<FormContactoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FormContacto> FormContactos { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("server=localhost; database=FormContactoDB; integrated security=true; TrustServerCertificate=Yes");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FormContacto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FormCont__3214EC07B0866D3A");

            entity.ToTable("FormContacto");

            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
