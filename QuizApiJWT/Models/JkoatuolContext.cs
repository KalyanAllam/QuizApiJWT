using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QuizApiJWT.Models;

public partial class JkoatuolContext : DbContext
{
    public JkoatuolContext()
    {
    }

    public JkoatuolContext(DbContextOptions<JkoatuolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<QuestionsOk> QuestionsOks { get; set; }

    public virtual DbSet<RateCard> RateCards { get; set; }

    public virtual DbSet<Userdatum> Userdata { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=cornelius.db.elephantsql.com;Database=jkoatuol;Username=jkoatuol;Password=3LqjLUapg8Mk3XB2-KUoSlX0hjdj9EFR");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("btree_gin")
            .HasPostgresExtension("btree_gist")
            .HasPostgresExtension("citext")
            .HasPostgresExtension("cube")
            .HasPostgresExtension("dblink")
            .HasPostgresExtension("dict_int")
            .HasPostgresExtension("dict_xsyn")
            .HasPostgresExtension("earthdistance")
            .HasPostgresExtension("fuzzystrmatch")
            .HasPostgresExtension("hstore")
            .HasPostgresExtension("intarray")
            .HasPostgresExtension("ltree")
            .HasPostgresExtension("pg_stat_statements")
            .HasPostgresExtension("pg_trgm")
            .HasPostgresExtension("pgcrypto")
            .HasPostgresExtension("pgrowlocks")
            .HasPostgresExtension("pgstattuple")
            .HasPostgresExtension("tablefunc")
            .HasPostgresExtension("unaccent")
            .HasPostgresExtension("uuid-ossp")
            .HasPostgresExtension("xml2");

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Sno).HasName("pk_no");

            entity.Property(e => e.Sno).HasColumnName("SNo");
            entity.Property(e => e.Answer).HasMaxLength(50);
            entity.Property(e => e.Opt1).HasMaxLength(50);
            entity.Property(e => e.Opt2).HasMaxLength(50);
            entity.Property(e => e.Opt3).HasMaxLength(50);
            entity.Property(e => e.Opt4).HasMaxLength(50);
            entity.Property(e => e.QuestionTitle).HasMaxLength(500);
            entity.Property(e => e.Solution)
                .HasMaxLength(500)
                .HasColumnName("solution");
            entity.Property(e => e.Topic).HasMaxLength(500);
        });

        modelBuilder.Entity<QuestionsOk>(entity =>
        {
            entity.HasKey(e => e.Sno).HasName("pk_num");

            entity.ToTable("QuestionsOK");

            entity.Property(e => e.Sno).HasColumnName("SNo");
            entity.Property(e => e.Answer).HasMaxLength(50);
            entity.Property(e => e.Opt1).HasMaxLength(50);
            entity.Property(e => e.Opt2).HasMaxLength(50);
            entity.Property(e => e.Opt3).HasMaxLength(50);
            entity.Property(e => e.Opt4).HasMaxLength(50);
            entity.Property(e => e.QuestionTitle).HasMaxLength(500);
            entity.Property(e => e.Solution)
                .HasMaxLength(500)
                .HasColumnName("solution");
            entity.Property(e => e.Topic).HasMaxLength(500);
        });

        modelBuilder.Entity<RateCard>(entity =>
        {
            entity.HasKey(e => e.No).HasName("pk_number");

            entity.ToTable("RateCard");
        });

        modelBuilder.Entity<Userdatum>(entity =>
        {
            entity.HasKey(e => e.No).HasName("pk_uno");

            entity.Property(e => e.Email).HasMaxLength(500);
            entity.Property(e => e.Password).HasMaxLength(500);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
