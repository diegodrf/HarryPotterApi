﻿// <auto-generated />
using System;
using HarryPotterApi.Data.Connections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HarryPotterApi.Migrations
{
    [DbContext(typeof(HarryPotterApiDbContext))]
    [Migration("20221005023545_Remove Users")]
    partial class RemoveUsers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HarryPotterApi.Models.Data.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Actor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Ancestry")
                        .HasColumnType("text");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Eye")
                        .HasColumnType("text");

                    b.Property<int?>("GenderId")
                        .HasColumnType("integer");

                    b.Property<string>("Hair")
                        .HasColumnType("text");

                    b.Property<int?>("HouseId")
                        .HasColumnType("integer");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<bool>("IsAlive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsHogwartsStaff")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsHogwartsStudent")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsWizard")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronus")
                        .HasColumnType("text");

                    b.Property<int?>("SpeciesId")
                        .HasColumnType("integer");

                    b.Property<int?>("WandId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("HouseId");

                    b.HasIndex("SpeciesId");

                    b.HasIndex("WandId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("HarryPotterApi.Models.Data.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("HarryPotterApi.Models.Data.House", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Houses");
                });

            modelBuilder.Entity("HarryPotterApi.Models.Data.Species", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Species");
                });

            modelBuilder.Entity("HarryPotterApi.Models.Data.Wand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Core")
                        .HasColumnType("text");

                    b.Property<double?>("Length")
                        .HasColumnType("double precision");

                    b.Property<string>("Wood")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Wands");
                });

            modelBuilder.Entity("HarryPotterApi.Models.Data.Character", b =>
                {
                    b.HasOne("HarryPotterApi.Models.Data.Gender", "Gender")
                        .WithMany("Characters")
                        .HasForeignKey("GenderId");

                    b.HasOne("HarryPotterApi.Models.Data.House", "House")
                        .WithMany("Characters")
                        .HasForeignKey("HouseId");

                    b.HasOne("HarryPotterApi.Models.Data.Species", "Species")
                        .WithMany("Characters")
                        .HasForeignKey("SpeciesId");

                    b.HasOne("HarryPotterApi.Models.Data.Wand", "Wand")
                        .WithMany("Characters")
                        .HasForeignKey("WandId");

                    b.Navigation("Gender");

                    b.Navigation("House");

                    b.Navigation("Species");

                    b.Navigation("Wand");
                });

            modelBuilder.Entity("HarryPotterApi.Models.Data.Gender", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("HarryPotterApi.Models.Data.House", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("HarryPotterApi.Models.Data.Species", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("HarryPotterApi.Models.Data.Wand", b =>
                {
                    b.Navigation("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}
