﻿// <auto-generated />
using System;
using EngineerApp.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EngineerApp.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20181217221652_ExtendedNewColumnsInDatabase")]
    partial class ExtendedNewColumnsInDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EngineerApp.API.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Add_Date");

                    b.Property<bool>("Blocked");

                    b.Property<string>("CardNumber");

                    b.Property<string>("CardNumber1");

                    b.Property<string>("CardNumber2");

                    b.Property<string>("CardNumber3");

                    b.Property<int>("IdUser");

                    b.Property<DateTime>("LastUse_Date");

                    b.Property<int>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Oct4_Card");

                    b.HasKey("Id");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("EngineerApp.API.Models.CardReader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Localization");

                    b.Property<string>("ReaderName");

                    b.HasKey("Id");

                    b.ToTable("CardReaders");
                });

            modelBuilder.Entity("EngineerApp.API.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmentName");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("EngineerApp.API.Models.IncidentHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("Hour");

                    b.Property<int>("IdCardReader");

                    b.Property<int>("IdUser");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("IncidentsHistory");
                });

            modelBuilder.Entity("EngineerApp.API.Models.Localization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Area");

                    b.HasKey("Id");

                    b.ToTable("Localizations");
                });

            modelBuilder.Entity("EngineerApp.API.Models.Presence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("IdUser");

                    b.Property<int>("PlannedPresence");

                    b.Property<int>("RealPresence");

                    b.HasKey("Id");

                    b.ToTable("Presences");
                });

            modelBuilder.Entity("EngineerApp.API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<int>("IdDepartment");

                    b.Property<int>("IdSuperior");

                    b.Property<string>("Login");

                    b.Property<int>("ModiefiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Surname");

                    b.Property<int>("TypePermission");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EngineerApp.API.Models.Value", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Values");
                });
#pragma warning restore 612, 618
        }
    }
}
