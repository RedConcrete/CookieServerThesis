﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Server.Data;

#nullable disable

namespace Server.Migrations
{
    [DbContext(typeof(ServerContext))]
    [Migration("20240613081200_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Server.Data.KVN", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("ButterKV")
                        .HasColumnType("integer");

                    b.Property<int>("ButterN")
                        .HasColumnType("integer");

                    b.Property<int>("ChocolateKV")
                        .HasColumnType("integer");

                    b.Property<int>("ChocolateN")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("EggsKV")
                        .HasColumnType("integer");

                    b.Property<int>("EggsN")
                        .HasColumnType("integer");

                    b.Property<int>("FlourKV")
                        .HasColumnType("integer");

                    b.Property<int>("FlourN")
                        .HasColumnType("integer");

                    b.Property<int>("MilkKV")
                        .HasColumnType("integer");

                    b.Property<int>("MilkN")
                        .HasColumnType("integer");

                    b.Property<int>("SugarKV")
                        .HasColumnType("integer");

                    b.Property<int>("SugarN")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("KVN");
                });

            modelBuilder.Entity("Server.Data.Market", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<float>("ButterPrice")
                        .HasColumnType("real");

                    b.Property<float>("ChocolatePrice")
                        .HasColumnType("real");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float>("EggsPrice")
                        .HasColumnType("real");

                    b.Property<float>("FlourPrice")
                        .HasColumnType("real");

                    b.Property<float>("MilkPrice")
                        .HasColumnType("real");

                    b.Property<float>("SugarPrice")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Markets");
                });

            modelBuilder.Entity("Server.Data.Player", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<float>("Butter")
                        .HasColumnType("real");

                    b.Property<float>("Chocolate")
                        .HasColumnType("real");

                    b.Property<float>("Cookies")
                        .HasColumnType("real");

                    b.Property<float>("Eggs")
                        .HasColumnType("real");

                    b.Property<float>("Flour")
                        .HasColumnType("real");

                    b.Property<float>("Milk")
                        .HasColumnType("real");

                    b.Property<float>("Sugar")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
