﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OneMoreGame.Models;

namespace OneMoreGame.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191010172003_AddPlayerToDatabase")]
    partial class AddPlayerToDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OneMoreGame.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<bool>("Fifa20");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<bool>("PubG");

                    b.Property<string>("SelectedPaymentMethod");

                    b.Property<bool>("Tekken");

                    b.Property<int>("Total");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
