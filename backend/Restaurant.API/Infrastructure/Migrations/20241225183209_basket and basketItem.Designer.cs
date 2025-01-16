﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Restaurant.Infrastructure.DbContexts;

#nullable disable

namespace Restaurant.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241225183209_basket and basketItem")]
    partial class basketandbasketItem
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 1,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 1,
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Restaurant.Domain.Entities.BasketEntities.Basket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("Restaurant.Domain.Entities.BasketEntities.BasketItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<int>("BasketId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DrinkId")
                        .HasColumnType("integer");

                    b.Property<int?>("MealId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BasketId");

                    b.HasIndex("DrinkId");

                    b.HasIndex("MealId");

                    b.ToTable("BasketItems");
                });

            modelBuilder.Entity("Restaurant.Domain.Entities.DrinkEntities.Drink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsCategory")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ParentId")
                        .HasColumnType("integer");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Drinks", "restaurant");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            CreatedDate = new DateTime(2024, 12, 25, 18, 32, 9, 89, DateTimeKind.Utc).AddTicks(5959),
                            Description = "cola cola",
                            IsCategory = false,
                            Name = "Cola",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            CreatedDate = new DateTime(2024, 12, 25, 18, 32, 9, 89, DateTimeKind.Utc).AddTicks(5962),
                            Description = "pepsi pepsi",
                            IsCategory = false,
                            Name = "Pepsi",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            CreatedDate = new DateTime(2024, 12, 25, 18, 32, 9, 89, DateTimeKind.Utc).AddTicks(5963),
                            IsCategory = true,
                            Name = "Can",
                            ParentId = 1,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Active = true,
                            CreatedDate = new DateTime(2024, 12, 25, 18, 32, 9, 89, DateTimeKind.Utc).AddTicks(5964),
                            IsCategory = true,
                            Name = "Bottle",
                            ParentId = 2,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            Active = true,
                            CreatedDate = new DateTime(2024, 12, 25, 18, 32, 9, 89, DateTimeKind.Utc).AddTicks(5965),
                            IsCategory = false,
                            Name = "500ml",
                            ParentId = 1,
                            Price = 12000m,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            Active = true,
                            CreatedDate = new DateTime(2024, 12, 25, 18, 32, 9, 89, DateTimeKind.Utc).AddTicks(5967),
                            IsCategory = false,
                            Name = "1L",
                            ParentId = 2,
                            Price = 11000m,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Restaurant.Domain.Entities.FilesEntities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<int?>("DrinkId")
                        .HasColumnType("integer");

                    b.Property<int?>("MealId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.HasKey("Id");

                    b.HasIndex("DrinkId");

                    b.HasIndex("MealId");

                    b.ToTable("Images", "restaurant");
                });

            modelBuilder.Entity("Restaurant.Domain.Entities.Identity.ApplicationRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "1",
                            Name = "manager",
                            NormalizedName = "MANAGER"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "2",
                            Name = "suplier",
                            NormalizedName = "SUPLIER"
                        },
                        new
                        {
                            Id = 3,
                            ConcurrencyStamp = "3",
                            Name = "student",
                            NormalizedName = "STUDENT"
                        });
                });

            modelBuilder.Entity("Restaurant.Domain.Entities.Identity.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<int>("CountOfEnter")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("LastActive")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("MainRoleId")
                        .HasColumnType("integer");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "0d44e766-a6b9-4c94-88af-376f0c71c393",
                            CountOfEnter = 0,
                            Email = "wuit00016777@gmail.com",
                            EmailConfirmed = true,
                            FullName = "Hayitbek MIrsoatov",
                            ImageUrl = "",
                            LastActive = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LockoutEnabled = false,
                            MainRoleId = 1,
                            NormalizedEmail = "WUIT00016777@GMAIL.COM",
                            NormalizedUserName = "HAYITBEK",
                            PasswordHash = "AQAAAAIAAYagAAAAEHVcwtDDNIDGjKM69DeZ54NYpgA7tvxC/Eaq0gbITU1UA/0WZiB/xX0XejutWZJWuw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "1",
                            TwoFactorEnabled = false,
                            UserName = "Hayitbek"
                        });
                });

            modelBuilder.Entity("Restaurant.Domain.Entities.MealEntities.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsCategory")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ParentId")
                        .HasColumnType("integer");

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Meals", "restaurant");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            CreatedDate = new DateTime(2024, 12, 25, 18, 32, 9, 89, DateTimeKind.Utc).AddTicks(5894),
                            IsCategory = true,
                            Name = "Osh",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            CreatedDate = new DateTime(2024, 12, 25, 18, 32, 9, 89, DateTimeKind.Utc).AddTicks(5900),
                            IsCategory = true,
                            Name = "Somsa",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            CreatedDate = new DateTime(2024, 12, 25, 18, 32, 9, 89, DateTimeKind.Utc).AddTicks(5901),
                            IsCategory = false,
                            Name = "Cheeseburger",
                            Price = 30000m,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Active = true,
                            CreatedDate = new DateTime(2024, 12, 25, 18, 32, 9, 89, DateTimeKind.Utc).AddTicks(5907),
                            IsCategory = true,
                            Name = "Samarkand Osh",
                            ParentId = 1,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            Active = true,
                            CreatedDate = new DateTime(2024, 12, 25, 18, 32, 9, 89, DateTimeKind.Utc).AddTicks(5908),
                            IsCategory = true,
                            Name = "Andijon Osh",
                            ParentId = 1,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            Active = true,
                            CreatedDate = new DateTime(2024, 12, 25, 18, 32, 9, 89, DateTimeKind.Utc).AddTicks(5909),
                            IsCategory = false,
                            Name = "Tandir Somsa",
                            ParentId = 2,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 7,
                            Active = true,
                            CreatedDate = new DateTime(2024, 12, 25, 18, 32, 9, 89, DateTimeKind.Utc).AddTicks(5910),
                            IsCategory = false,
                            Name = "To'y Osh",
                            ParentId = 4,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 8,
                            Active = true,
                            CreatedDate = new DateTime(2024, 12, 25, 18, 32, 9, 89, DateTimeKind.Utc).AddTicks(5911),
                            IsCategory = false,
                            Name = "Choyxona Osh",
                            ParentId = 5,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Restaurant.Domain.Entities.OrderEntities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<byte>("Status")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders", "restaurant");
                });

            modelBuilder.Entity("Restaurant.Domain.Entities.OrderEntities.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("MealId")
                        .HasColumnType("integer");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("MealId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails", "restaurant");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Restaurant.Domain.Entities.Identity.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Restaurant.Domain.Entities.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Restaurant.Domain.Entities.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Restaurant.Domain.Entities.Identity.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Restaurant.Domain.Entities.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Restaurant.Domain.Entities.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Restaurant.Domain.Entities.BasketEntities.Basket", b =>
                {
                    b.HasOne("Restaurant.Domain.Entities.Identity.ApplicationUser", "User")
                        .WithMany("Baskets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Restaurant.Domain.Entities.BasketEntities.BasketItem", b =>
                {
                    b.HasOne("Restaurant.Domain.Entities.BasketEntities.Basket", "Basket")
                        .WithMany("BasketItems")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Restaurant.Domain.Entities.DrinkEntities.Drink", "Drink")
                        .WithMany()
                        .HasForeignKey("DrinkId");

                    b.HasOne("Restaurant.Domain.Entities.MealEntities.Meal", "Meal")
                        .WithMany("BasketItems")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Basket");

                    b.Navigation("Drink");

                    b.Navigation("Meal");
                });

            modelBuilder.Entity("Restaurant.Domain.Entities.DrinkEntities.Drink", b =>
                {
                    b.HasOne("Restaurant.Domain.Entities.DrinkEntities.Drink", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Restaurant.Domain.Entities.FilesEntities.Image", b =>
                {
                    b.HasOne("Restaurant.Domain.Entities.DrinkEntities.Drink", "Drink")
                        .WithMany("Images")
                        .HasForeignKey("DrinkId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Restaurant.Domain.Entities.MealEntities.Meal", "Meal")
                        .WithMany("Images")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Drink");

                    b.Navigation("Meal");
                });

            modelBuilder.Entity("Restaurant.Domain.Entities.MealEntities.Meal", b =>
                {
                    b.HasOne("Restaurant.Domain.Entities.MealEntities.Meal", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Restaurant.Domain.Entities.OrderEntities.Order", b =>
                {
                    b.HasOne("Restaurant.Domain.Entities.Identity.ApplicationUser", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Restaurant.Domain.Entities.OrderEntities.OrderDetail", b =>
                {
                    b.HasOne("Restaurant.Domain.Entities.MealEntities.Meal", "Meal")
                        .WithMany("OrderDetails")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Restaurant.Domain.Entities.OrderEntities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meal");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Restaurant.Domain.Entities.BasketEntities.Basket", b =>
                {
                    b.Navigation("BasketItems");
                });

            modelBuilder.Entity("Restaurant.Domain.Entities.DrinkEntities.Drink", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("Images");
                });

            modelBuilder.Entity("Restaurant.Domain.Entities.Identity.ApplicationUser", b =>
                {
                    b.Navigation("Baskets");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Restaurant.Domain.Entities.MealEntities.Meal", b =>
                {
                    b.Navigation("BasketItems");

                    b.Navigation("Children");

                    b.Navigation("Images");

                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Restaurant.Domain.Entities.OrderEntities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
