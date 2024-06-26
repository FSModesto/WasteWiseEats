﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WasteWiseEats_API.Data.BaseContext;

#nullable disable

namespace WasteWiseEatsAPI.Data.Migrations
{
    [DbContext(typeof(WasteWiseEatsContext))]
    [Migration("20240508034602_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WasteWiseEats_API.Domain.Entities.DonationCenter", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("BeginTime")
                        .HasColumnType("time");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerDocument")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("DonationCenters");
                });

            modelBuilder.Entity("WasteWiseEats_API.Domain.Entities.DonationCenterAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DonationCenterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DonationCenterId")
                        .IsUnique();

                    b.ToTable("DonationCenterAddresses");
                });

            modelBuilder.Entity("WasteWiseEats_API.Domain.Entities.DonationProposal", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DonationCenterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("HasAccepted")
                        .HasColumnType("bit");

                    b.Property<TimeSpan>("RemovalTime")
                        .HasColumnType("time");

                    b.Property<string>("Restaurant")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("WasteRegisterId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DonationCenterId");

                    b.HasIndex("WasteRegisterId")
                        .IsUnique();

                    b.ToTable("DonationProposals");
                });

            modelBuilder.Entity("WasteWiseEats_API.Domain.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Job")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("WasteWiseEats_API.Domain.Entities.Food", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<bool>("HasPrepared")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPerishable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quantity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("WasteRegisterId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("WasteRegisterId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("WasteWiseEats_API.Domain.Entities.Restaurant", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("DonationTime")
                        .HasColumnType("time");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerDocument")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Restaurant");
                });

            modelBuilder.Entity("WasteWiseEats_API.Domain.Entities.RestaurantAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId")
                        .IsUnique();

                    b.ToTable("RestaurantAddresses");
                });

            modelBuilder.Entity("WasteWiseEats_API.Domain.Entities.SecurityProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("SecurityProfile");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Acesso irrestrito ao sistema.",
                            Name = "Super Usuário",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("361a6151-97ee-470e-b901-6c9160b974a9"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Gerenciamento de funcionários e demandas do restaurante.",
                            Name = "Proprietário do restaurante",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("cc0be4a1-a29d-43d8-97d9-0151015a4147"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Gerenciamento de desperdícios e cadastro de doações.",
                            Name = "Atendente do restaurante",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("100f0e52-f543-4586-bc1e-f2741f56b535"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Gerenciamento de propostas de doação",
                            Name = "Proprietário do centro de doação",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("WasteWiseEats_API.Domain.Entities.SecurityProfileRole", b =>
                {
                    b.Property<Guid>("ProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("ProfileId", "Role");

                    b.ToTable("SecurityProfileRole");

                    b.HasData(
                        new
                        {
                            ProfileId = new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"),
                            Role = 1
                        },
                        new
                        {
                            ProfileId = new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"),
                            Role = 2
                        },
                        new
                        {
                            ProfileId = new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"),
                            Role = 3
                        },
                        new
                        {
                            ProfileId = new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"),
                            Role = 4
                        },
                        new
                        {
                            ProfileId = new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"),
                            Role = 5
                        },
                        new
                        {
                            ProfileId = new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"),
                            Role = 6
                        },
                        new
                        {
                            ProfileId = new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"),
                            Role = 7
                        },
                        new
                        {
                            ProfileId = new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"),
                            Role = 8
                        },
                        new
                        {
                            ProfileId = new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"),
                            Role = 9
                        },
                        new
                        {
                            ProfileId = new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"),
                            Role = 10
                        },
                        new
                        {
                            ProfileId = new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"),
                            Role = 11
                        },
                        new
                        {
                            ProfileId = new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"),
                            Role = 12
                        },
                        new
                        {
                            ProfileId = new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"),
                            Role = 13
                        },
                        new
                        {
                            ProfileId = new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"),
                            Role = 14
                        },
                        new
                        {
                            ProfileId = new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"),
                            Role = 15
                        },
                        new
                        {
                            ProfileId = new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"),
                            Role = 16
                        },
                        new
                        {
                            ProfileId = new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"),
                            Role = 17
                        },
                        new
                        {
                            ProfileId = new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"),
                            Role = 18
                        },
                        new
                        {
                            ProfileId = new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"),
                            Role = 19
                        },
                        new
                        {
                            ProfileId = new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"),
                            Role = 20
                        },
                        new
                        {
                            ProfileId = new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"),
                            Role = 21
                        },
                        new
                        {
                            ProfileId = new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"),
                            Role = 22
                        },
                        new
                        {
                            ProfileId = new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"),
                            Role = 23
                        },
                        new
                        {
                            ProfileId = new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"),
                            Role = 24
                        },
                        new
                        {
                            ProfileId = new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"),
                            Role = 25
                        },
                        new
                        {
                            ProfileId = new Guid("100f0e52-f543-4586-bc1e-f2741f56b535"),
                            Role = 4
                        },
                        new
                        {
                            ProfileId = new Guid("100f0e52-f543-4586-bc1e-f2741f56b535"),
                            Role = 5
                        },
                        new
                        {
                            ProfileId = new Guid("100f0e52-f543-4586-bc1e-f2741f56b535"),
                            Role = 3
                        },
                        new
                        {
                            ProfileId = new Guid("100f0e52-f543-4586-bc1e-f2741f56b535"),
                            Role = 6
                        },
                        new
                        {
                            ProfileId = new Guid("100f0e52-f543-4586-bc1e-f2741f56b535"),
                            Role = 7
                        },
                        new
                        {
                            ProfileId = new Guid("100f0e52-f543-4586-bc1e-f2741f56b535"),
                            Role = 8
                        },
                        new
                        {
                            ProfileId = new Guid("100f0e52-f543-4586-bc1e-f2741f56b535"),
                            Role = 10
                        },
                        new
                        {
                            ProfileId = new Guid("cc0be4a1-a29d-43d8-97d9-0151015a4147"),
                            Role = 2
                        },
                        new
                        {
                            ProfileId = new Guid("cc0be4a1-a29d-43d8-97d9-0151015a4147"),
                            Role = 9
                        },
                        new
                        {
                            ProfileId = new Guid("cc0be4a1-a29d-43d8-97d9-0151015a4147"),
                            Role = 11
                        },
                        new
                        {
                            ProfileId = new Guid("cc0be4a1-a29d-43d8-97d9-0151015a4147"),
                            Role = 23
                        },
                        new
                        {
                            ProfileId = new Guid("cc0be4a1-a29d-43d8-97d9-0151015a4147"),
                            Role = 24
                        },
                        new
                        {
                            ProfileId = new Guid("cc0be4a1-a29d-43d8-97d9-0151015a4147"),
                            Role = 25
                        },
                        new
                        {
                            ProfileId = new Guid("cc0be4a1-a29d-43d8-97d9-0151015a4147"),
                            Role = 22
                        },
                        new
                        {
                            ProfileId = new Guid("cc0be4a1-a29d-43d8-97d9-0151015a4147"),
                            Role = 21
                        },
                        new
                        {
                            ProfileId = new Guid("361a6151-97ee-470e-b901-6c9160b974a9"),
                            Role = 1
                        },
                        new
                        {
                            ProfileId = new Guid("361a6151-97ee-470e-b901-6c9160b974a9"),
                            Role = 2
                        },
                        new
                        {
                            ProfileId = new Guid("361a6151-97ee-470e-b901-6c9160b974a9"),
                            Role = 3
                        },
                        new
                        {
                            ProfileId = new Guid("361a6151-97ee-470e-b901-6c9160b974a9"),
                            Role = 9
                        },
                        new
                        {
                            ProfileId = new Guid("361a6151-97ee-470e-b901-6c9160b974a9"),
                            Role = 11
                        },
                        new
                        {
                            ProfileId = new Guid("361a6151-97ee-470e-b901-6c9160b974a9"),
                            Role = 14
                        },
                        new
                        {
                            ProfileId = new Guid("361a6151-97ee-470e-b901-6c9160b974a9"),
                            Role = 15
                        },
                        new
                        {
                            ProfileId = new Guid("361a6151-97ee-470e-b901-6c9160b974a9"),
                            Role = 13
                        },
                        new
                        {
                            ProfileId = new Guid("361a6151-97ee-470e-b901-6c9160b974a9"),
                            Role = 12
                        },
                        new
                        {
                            ProfileId = new Guid("361a6151-97ee-470e-b901-6c9160b974a9"),
                            Role = 16
                        },
                        new
                        {
                            ProfileId = new Guid("361a6151-97ee-470e-b901-6c9160b974a9"),
                            Role = 18
                        },
                        new
                        {
                            ProfileId = new Guid("361a6151-97ee-470e-b901-6c9160b974a9"),
                            Role = 20
                        },
                        new
                        {
                            ProfileId = new Guid("361a6151-97ee-470e-b901-6c9160b974a9"),
                            Role = 17
                        });
                });

            modelBuilder.Entity("WasteWiseEats_API.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsExpired")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFirstAccess")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("WasteWiseEats_API.Domain.Entities.WasteRegister", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Employee")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasDonated")
                        .HasColumnType("bit");

                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("WasteRegisters");
                });

            modelBuilder.Entity("WasteWiseEats_API.Domain.Entities.DonationCenter", b =>
                {
                    b.HasOne("WasteWiseEats_API.Domain.Entities.User", "User")
                        .WithOne("DonationCenter")
                        .HasForeignKey("WasteWiseEats_API.Domain.Entities.DonationCenter", "UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WasteWiseEats_API.Domain.Entities.DonationCenterAddress", b =>
                {
                    b.HasOne("WasteWiseEats_API.Domain.Entities.DonationCenter", "DonationCenter")
                        .WithOne("Address")
                        .HasForeignKey("WasteWiseEats_API.Domain.Entities.DonationCenterAddress", "DonationCenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonationCenter");
                });

            modelBuilder.Entity("WasteWiseEats_API.Domain.Entities.DonationProposal", b =>
                {
                    b.HasOne("WasteWiseEats_API.Domain.Entities.DonationCenter", "DonationCenter")
                        .WithMany("DonationProposals")
                        .HasForeignKey("DonationCenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WasteWiseEats_API.Domain.Entities.WasteRegister", "WasteRegister")
                        .WithOne("DonationProposal")
                        .HasForeignKey("WasteWiseEats_API.Domain.Entities.DonationProposal", "WasteRegisterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonationCenter");

                    b.Navigation("WasteRegister");
                });

            modelBuilder.Entity("WasteWiseEats_API.Domain.Entities.Employee", b =>
                {
                    b.HasOne("WasteWiseEats_API.Domain.Entities.Restaurant", "Restaurant")
                        .WithMany("Employees")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WasteWiseEats_API.Domain.Entities.User", "User")
                        .WithOne("Employee")
                        .HasForeignKey("WasteWiseEats_API.Domain.Entities.Employee", "UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Restaurant");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WasteWiseEats_API.Domain.Entities.Food", b =>
                {
                    b.HasOne("WasteWiseEats_API.Domain.Entities.WasteRegister", "WasteRegister")
                        .WithMany("Foods")
                        .HasForeignKey("WasteRegisterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WasteRegister");
                });

            modelBuilder.Entity("WasteWiseEats_API.Domain.Entities.Restaurant", b =>
                {
                    b.HasOne("WasteWiseEats_API.Domain.Entities.User", "User")
                        .WithOne("Restaurant")
                        .HasForeignKey("WasteWiseEats_API.Domain.Entities.Restaurant", "UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WasteWiseEats_API.Domain.Entities.RestaurantAddress", b =>
                {
                    b.HasOne("WasteWiseEats_API.Domain.Entities.Restaurant", "Restaurant")
                        .WithOne("Address")
                        .HasForeignKey("WasteWiseEats_API.Domain.Entities.RestaurantAddress", "RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("WasteWiseEats_API.Domain.Entities.SecurityProfileRole", b =>
                {
                    b.HasOne("WasteWiseEats_API.Domain.Entities.SecurityProfile", "Profile")
                        .WithMany("Roles")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("WasteWiseEats_API.Domain.Entities.User", b =>
                {
                    b.HasOne("WasteWiseEats_API.Domain.Entities.SecurityProfile", "Profile")
                        .WithMany("Users")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("WasteWiseEats_API.Domain.Entities.WasteRegister", b =>
                {
                    b.HasOne("WasteWiseEats_API.Domain.Entities.Restaurant", "Restaurant")
                        .WithMany("WasteRegisters")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("WasteWiseEats_API.Domain.Entities.DonationCenter", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("DonationProposals");
                });

            modelBuilder.Entity("WasteWiseEats_API.Domain.Entities.Restaurant", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Employees");

                    b.Navigation("WasteRegisters");
                });

            modelBuilder.Entity("WasteWiseEats_API.Domain.Entities.SecurityProfile", b =>
                {
                    b.Navigation("Roles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("WasteWiseEats_API.Domain.Entities.User", b =>
                {
                    b.Navigation("DonationCenter");

                    b.Navigation("Employee");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("WasteWiseEats_API.Domain.Entities.WasteRegister", b =>
                {
                    b.Navigation("DonationProposal")
                        .IsRequired();

                    b.Navigation("Foods");
                });
#pragma warning restore 612, 618
        }
    }
}
