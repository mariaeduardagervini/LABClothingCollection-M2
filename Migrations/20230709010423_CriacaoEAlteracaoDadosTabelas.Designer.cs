﻿// <auto-generated />
using System;
using LabClothingCollection.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LabClothingCollection.Migrations
{
    [DbContext(typeof(PessoaContext))]
    [Migration("20230709010423_CriacaoEAlteracaoDadosTabelas")]
    partial class CriacaoEAlteracaoDadosTabelas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LabClothingCollection.Models.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CpfCnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .IsUnicode(false)
                        .HasColumnType("varchar(14)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genero")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Telefone")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CpfCnpj" }, "Identificador")
                        .IsUnique();

                    b.ToTable("Pessoa", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("Pessoa");
                });

            modelBuilder.Entity("LabClothingCollection.Models.Usuario", b =>
                {
                    b.HasBaseType("LabClothingCollection.Models.Pessoa");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasAnnotation("RegularExpression", "\\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Z|a-z]{2,}\\b");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Usuario");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CpfCnpj = "380.273.689-36",
                            DataNascimento = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "F",
                            Nome = "Maria da Silva",
                            Telefone = "99819-7607",
                            Email = "maria@example.com",
                            Status = "ATIVO",
                            Tipo = "Administrador"
                        },
                        new
                        {
                            Id = 2,
                            CpfCnpj = "808.897.949-87",
                            DataNascimento = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "M",
                            Nome = "José Andrade",
                            Telefone = "98772-8465",
                            Email = "josee2@example.com",
                            Status = "ATIVO",
                            Tipo = "Administrador"
                        },
                        new
                        {
                            Id = 3,
                            CpfCnpj = "125.475.619-13",
                            DataNascimento = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "F",
                            Nome = "Bruna Lopez",
                            Telefone = "99151-3437",
                            Email = "bruna@example.com",
                            Status = "ATIVO",
                            Tipo = "Administrador"
                        },
                        new
                        {
                            Id = 4,
                            CpfCnpj = "047.634.239-24",
                            DataNascimento = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "M",
                            Nome = "Pedro Assis",
                            Telefone = "98474-3877",
                            Email = "pedro@example.com",
                            Status = "ATIVO",
                            Tipo = "Administrador"
                        },
                        new
                        {
                            Id = 5,
                            CpfCnpj = "20996384000151",
                            DataNascimento = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "F",
                            Nome = "Empresa Julia Ltda",
                            Telefone = "3278-1022",
                            Email = "julia@empresa.com",
                            Status = "ATIVO",
                            Tipo = "Administrador"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
