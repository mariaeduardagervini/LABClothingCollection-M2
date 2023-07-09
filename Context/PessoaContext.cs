using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LabClothingCollection.Models;

namespace LabClothingCollection.Context
{
    public partial class PessoaContext : DbContext
    {
        public PessoaContext()
        {
        }

        public PessoaContext(DbContextOptions<PessoaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pessoa> Pessoas { get; set; } = null!;
        public virtual DbSet<Usuario>? Usuarios { get; set; }

        public virtual DbSet<Colecao> Colecao { get; set; } = null!;

        public virtual DbSet<Modelo> Modelos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("ServerConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.ToTable("Pessoa");

                entity.HasIndex(e => e.CpfCnpj, "CpfCnpj")
                    .IsUnique();

                entity.Property(e => e.CpfCnpj)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento).HasColumnType("date");

                entity.Property(e => e.Genero)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(20)
                    .IsUnicode(false);


            });

            modelBuilder.Entity<Pessoa>()
               .HasDiscriminator<string>("Discriminator")
               .HasValue<Pessoa>("Pessoa");

            modelBuilder.Entity<Usuario>()
                .HasBaseType<Pessoa>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<Usuario>("Usuario");

            modelBuilder.Entity<Usuario>(entity =>
            {

                entity.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasAnnotation("MaxLength", 255)
                    .HasAnnotation("RegularExpression", @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b");

                entity.Property(u => u.Tipo)
                .HasConversion<string>();

                entity.Property(u => u.Status)
                .HasColumnName("Status")
                .HasConversion<string>();
            });

           
            modelBuilder.Entity<Colecao>(entity =>
            {
                entity.HasKey(c => c.IdColecao);
                


                entity.Property(c => c.NomeColecao)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(c => c.IdResponsavel)
                    .IsRequired();

                entity.Property(c => c.Marca)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(c => c.Orcamento)
                    .IsRequired();

                entity.Property(c => c.AnoLancamento)
                    .IsRequired()
                    .HasColumnType("date");

                entity.Property(c => c.Estacao)
                    .IsRequired()
                    .HasConversion<string>()
                    .HasMaxLength(10);

                entity.Property(c => c.Estado)
                    .IsRequired()
                    .HasConversion<string>()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Colecao>()
        .       HasOne<Pessoa>()
                .WithMany()
                .HasForeignKey(c => c.IdResponsavel)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Modelo>()
                .HasKey(m => m.IdModelo);

            modelBuilder.Entity<Modelo>()
                .Property(m => m.NomeModelo)
                .IsRequired();

            modelBuilder.Entity<Modelo>()
                .Property(m => m.ColecaoId)
                .IsRequired();

            modelBuilder.Entity<Modelo>()
                .Property(m => m.Tipo)
                .IsRequired()
                .HasConversion<string>();

            modelBuilder.Entity<Modelo>()
                .Property(m => m.Layout)
                .IsRequired()
                .HasConversion<string>();

            modelBuilder.Entity<Modelo>()
                .HasOne<Colecao>()
                .WithMany()
                .HasForeignKey(m => m.ColecaoId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Colecao>()
             .Property(c => c.IdColecao)
             .ValueGeneratedOnAdd();

            modelBuilder.Entity<Modelo>()
                .Property(m => m.IdModelo)
                .ValueGeneratedOnAdd();


            OnModelCreatingPartial(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }
}