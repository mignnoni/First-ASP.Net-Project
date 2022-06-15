﻿// <auto-generated />
using System;
using APIWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APIWeb.Migrations
{
    [DbContext(typeof(HeroContext))]
    [Migration("20220615031556_heroesbattles")]
    partial class heroesbattles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APIWeb.Models.Battle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("Battles");
                });

            modelBuilder.Entity("APIWeb.Models.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Heroes");
                });

            modelBuilder.Entity("APIWeb.Models.HeroBattle", b =>
                {
                    b.Property<int>("BattleId");

                    b.Property<int>("HeroId");

                    b.HasKey("BattleId", "HeroId");

                    b.HasIndex("HeroId");

                    b.ToTable("HeroesBattles");
                });

            modelBuilder.Entity("APIWeb.Models.SecretIdentity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HeroId");

                    b.Property<string>("RealName");

                    b.HasKey("Id");

                    b.HasIndex("HeroId")
                        .IsUnique();

                    b.ToTable("SecretIdentities");
                });

            modelBuilder.Entity("APIWeb.Models.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HeroId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("HeroId");

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("APIWeb.Models.HeroBattle", b =>
                {
                    b.HasOne("APIWeb.Models.Battle", "Battle")
                        .WithMany("HeroesBattles")
                        .HasForeignKey("BattleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("APIWeb.Models.Hero", "Hero")
                        .WithMany("HeroesBattles")
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("APIWeb.Models.SecretIdentity", b =>
                {
                    b.HasOne("APIWeb.Models.Hero", "Hero")
                        .WithOne("SecretIdentity")
                        .HasForeignKey("APIWeb.Models.SecretIdentity", "HeroId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("APIWeb.Models.Weapon", b =>
                {
                    b.HasOne("APIWeb.Models.Hero", "Hero")
                        .WithMany("Weapons")
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}