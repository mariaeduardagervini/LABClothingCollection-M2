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

                entity.HasIndex(e => e.CpfCnpj, "Identificador")
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
                    .HasConversion<string>();
            });

            modelBuilder.Entity<Usuario>().HasData(
            new Usuario { Id = 1, Nome = "Maria da Silva", Genero= "F", CpfCnpj= "380.273.689-36", Telefone= "99819-7607", Email = "maria@example.com", Tipo= 0, Status=0 },
            new Usuario { Id = 2, Nome = "José Andrade", Genero = "M", CpfCnpj = "808.897.949-87", Telefone = "98772-8465", Email = "josee2@example.com", Tipo = 0, Status = 0 },
            new Usuario { Id = 3, Nome = "Bruna Lopez", Genero = "F", CpfCnpj = "125.475.619-13", Telefone = "99151-3437", Email = "bruna@example.com", Tipo = 0, Status = 0 },
            new Usuario { Id = 4, Nome = "Pedro Assis", Genero = "M", CpfCnpj = "047.634.239-24", Telefone = "98474-3877", Email = "pedro@example.com", Tipo = 0, Status = 0 },
            new Usuario { Id = 5, Nome = "Empresa Julia Ltda", Genero = "F", CpfCnpj = "20996384000151", Telefone = "3278-1022", Email = "julia@empresa.com", Tipo = 0, Status = 0 }
        );

            OnModelCreatingPartial(modelBuilder);
            

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

       

     
    }
}
