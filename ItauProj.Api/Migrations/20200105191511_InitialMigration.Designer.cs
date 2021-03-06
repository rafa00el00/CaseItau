﻿// <auto-generated />
using System;
using ItauProj.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ItauProj.Api.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20200105191511_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ItauProj.Api.Models.LancamentoFinanceiro", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DtHrLancamento");

                    b.Property<int>("Status");

                    b.Property<int>("Tipo");

                    b.Property<double>("Valor");

                    b.HasKey("Id");

                    b.ToTable("LancamentosFinanceiros");
                });
#pragma warning restore 612, 618
        }
    }
}
