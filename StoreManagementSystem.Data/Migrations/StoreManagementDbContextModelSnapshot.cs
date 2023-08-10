﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreManagementSystem.Data.Contexts;

#nullable disable

namespace StoreManagementSystem.Data.Migrations
{
    [DbContext(typeof(StoreManagementDbContext))]
    partial class StoreManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("StoreManagementSystem.Data.Entities.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "T-Shirt"
                        });
                });

            modelBuilder.Entity("StoreManagementSystem.Data.Entities.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Sofia"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Plovdiv"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Varna"
                        },
                        new
                        {
                            Id = 4,
                            Title = "Burgas"
                        },
                        new
                        {
                            Id = 5,
                            Title = "Ruse"
                        },
                        new
                        {
                            Id = 6,
                            Title = "Stara Zagora"
                        },
                        new
                        {
                            Id = 7,
                            Title = "Pleven"
                        },
                        new
                        {
                            Id = 8,
                            Title = "Sliven"
                        },
                        new
                        {
                            Id = 9,
                            Title = "Pazardzhik"
                        },
                        new
                        {
                            Id = 10,
                            Title = "Pernik"
                        },
                        new
                        {
                            Id = 11,
                            Title = "Dobrich"
                        },
                        new
                        {
                            Id = 12,
                            Title = "Shumen"
                        },
                        new
                        {
                            Id = 13,
                            Title = "Veliko Tarnovo"
                        },
                        new
                        {
                            Id = 14,
                            Title = "Haskovo"
                        },
                        new
                        {
                            Id = 15,
                            Title = "Blagoevgrad"
                        },
                        new
                        {
                            Id = 16,
                            Title = "Yambol"
                        },
                        new
                        {
                            Id = 17,
                            Title = "Kazanlak"
                        },
                        new
                        {
                            Id = 18,
                            Title = "Asenovgrad"
                        },
                        new
                        {
                            Id = 19,
                            Title = "Vratsa"
                        },
                        new
                        {
                            Id = 20,
                            Title = "Kyustendil"
                        },
                        new
                        {
                            Id = 21,
                            Title = "Gabrovo"
                        },
                        new
                        {
                            Id = 22,
                            Title = "Targovishte"
                        },
                        new
                        {
                            Id = 23,
                            Title = "Kardzhali"
                        },
                        new
                        {
                            Id = 24,
                            Title = "Vidin"
                        },
                        new
                        {
                            Id = 25,
                            Title = "Razgrad"
                        },
                        new
                        {
                            Id = 26,
                            Title = "Svishtov"
                        },
                        new
                        {
                            Id = 27,
                            Title = "Silistra"
                        },
                        new
                        {
                            Id = 28,
                            Title = "Lovech"
                        },
                        new
                        {
                            Id = 29,
                            Title = "Montana"
                        },
                        new
                        {
                            Id = 30,
                            Title = "Dimitrovgrad"
                        },
                        new
                        {
                            Id = 31,
                            Title = "Dupnitsa"
                        },
                        new
                        {
                            Id = 32,
                            Title = "Smolyan"
                        },
                        new
                        {
                            Id = 33,
                            Title = "Gorna Oryahovitsa"
                        },
                        new
                        {
                            Id = 34,
                            Title = "Petrich"
                        },
                        new
                        {
                            Id = 35,
                            Title = "Gotse Delchev"
                        },
                        new
                        {
                            Id = 36,
                            Title = "Aytos"
                        },
                        new
                        {
                            Id = 37,
                            Title = "Omurtag"
                        },
                        new
                        {
                            Id = 38,
                            Title = "Velingrad"
                        },
                        new
                        {
                            Id = 39,
                            Title = "Karlovo"
                        },
                        new
                        {
                            Id = 40,
                            Title = "Lom"
                        },
                        new
                        {
                            Id = 41,
                            Title = "Panagyurishte"
                        },
                        new
                        {
                            Id = 42,
                            Title = "Botevgrad"
                        },
                        new
                        {
                            Id = 43,
                            Title = "Peshtera"
                        },
                        new
                        {
                            Id = 44,
                            Title = "Rakovski"
                        },
                        new
                        {
                            Id = 45,
                            Title = "Pomorie"
                        },
                        new
                        {
                            Id = 46,
                            Title = "Novi Pazar"
                        },
                        new
                        {
                            Id = 47,
                            Title = "Provadia"
                        },
                        new
                        {
                            Id = 48,
                            Title = "Zlatograd"
                        },
                        new
                        {
                            Id = 49,
                            Title = "Kozloduy"
                        },
                        new
                        {
                            Id = 50,
                            Title = "Bankya"
                        });
                });

            modelBuilder.Entity("StoreManagementSystem.Data.Entities.Models.Condition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("Id");

                    b.ToTable("Conditions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "New"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Used"
                        });
                });

            modelBuilder.Entity("StoreManagementSystem.Data.Entities.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ConditionId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(18,2)");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ConditionId");

                    b.HasIndex("StoreId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            ConditionId = 1,
                            Description = "Made with 100% cotton",
                            ImageUrl = "https://d010205.bibloo.bg/_galerie/varianty/190/1902771-z.jpg",
                            IsDeleted = false,
                            Price = 50.99m,
                            StoreId = 1,
                            Title = "T-Shirt - GUESS"
                        });
                });

            modelBuilder.Entity("StoreManagementSystem.Data.Entities.Models.Province", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Provinces");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Blagoevgrad"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Burgas"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Dobrich"
                        },
                        new
                        {
                            Id = 4,
                            Title = "Gabrovo"
                        },
                        new
                        {
                            Id = 5,
                            Title = "Haskovo"
                        },
                        new
                        {
                            Id = 6,
                            Title = "Kardzhali"
                        },
                        new
                        {
                            Id = 7,
                            Title = "Kyustendil"
                        },
                        new
                        {
                            Id = 8,
                            Title = "Lovech"
                        },
                        new
                        {
                            Id = 9,
                            Title = "Montana"
                        },
                        new
                        {
                            Id = 10,
                            Title = "Pazardzhik"
                        },
                        new
                        {
                            Id = 11,
                            Title = "Pernik"
                        },
                        new
                        {
                            Id = 12,
                            Title = "Pleven"
                        },
                        new
                        {
                            Id = 13,
                            Title = "Plovdiv"
                        },
                        new
                        {
                            Id = 14,
                            Title = "Razgrad"
                        },
                        new
                        {
                            Id = 15,
                            Title = "Ruse"
                        },
                        new
                        {
                            Id = 16,
                            Title = "Shumen"
                        },
                        new
                        {
                            Id = 17,
                            Title = "Silistra"
                        },
                        new
                        {
                            Id = 18,
                            Title = "Sliven"
                        },
                        new
                        {
                            Id = 19,
                            Title = "Smolyan"
                        },
                        new
                        {
                            Id = 20,
                            Title = "Sofia City"
                        },
                        new
                        {
                            Id = 21,
                            Title = "Sofia (province)"
                        },
                        new
                        {
                            Id = 22,
                            Title = "Stara Zagora"
                        },
                        new
                        {
                            Id = 23,
                            Title = "Targovishte"
                        },
                        new
                        {
                            Id = 24,
                            Title = "Varna"
                        },
                        new
                        {
                            Id = 25,
                            Title = "Veliko Tarnovo"
                        },
                        new
                        {
                            Id = 26,
                            Title = "Vidin"
                        },
                        new
                        {
                            Id = 27,
                            Title = "Vratsa"
                        },
                        new
                        {
                            Id = 28,
                            Title = "Yambol"
                        });
                });

            modelBuilder.Entity("StoreManagementSystem.Data.Entities.Models.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("int");

                    b.Property<decimal>("Rating")
                        .HasColumnType("DECIMAL(4,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Stores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "ul. Petko R. Slaveikov 36",
                            CityId = 22,
                            DateCreated = new DateTime(2023, 8, 10, 19, 54, 41, 87, DateTimeKind.Utc).AddTicks(6390),
                            Description = "This store is made for designer's brands",
                            ImageUrl = "https://cdn.shopify.com/s/files/1/0635/0815/files/claremont-store-iamge_1000x.jpg?v=1667541605",
                            IsDeleted = false,
                            OwnerId = new Guid("f1cca3df-6437-423b-6256-08db7ee9be60"),
                            ProvinceId = 23,
                            Rating = 0m,
                            Title = "Gosho's designer store"
                        },
                        new
                        {
                            Id = 2,
                            Address = "ul. Asen Hristoforov 6",
                            CityId = 2,
                            DateCreated = new DateTime(2023, 8, 10, 19, 54, 41, 87, DateTimeKind.Utc).AddTicks(6402),
                            Description = "This store has different types of clothing",
                            ImageUrl = "https://bigsee.eu/wp-content/uploads/2022/04/DSC4685.jpg",
                            IsDeleted = false,
                            OwnerId = new Guid("f1cca3df-6437-423b-6256-08db7ee9be60"),
                            ProvinceId = 13,
                            Rating = 0m,
                            Title = "Gosho's store"
                        },
                        new
                        {
                            Id = 3,
                            Address = "bul. Cherni Vrah 47",
                            CityId = 1,
                            DateCreated = new DateTime(2023, 8, 10, 19, 54, 41, 87, DateTimeKind.Utc).AddTicks(6405),
                            Description = "This store has different types of sneakers",
                            ImageUrl = "https://planomagazine.com/wp-content/uploads/2021/04/Plano-Magazine-Prized-Kicks-sneaker-store-now-open_feature-1170x556.jpg",
                            IsDeleted = false,
                            OwnerId = new Guid("f1cca3df-6437-423b-6256-08db7ee9be60"),
                            ProvinceId = 20,
                            Rating = 0m,
                            Title = "Gosho's sneaker store"
                        },
                        new
                        {
                            Id = 4,
                            Address = "ul. Mara Buneva 52",
                            CityId = 1,
                            DateCreated = new DateTime(2023, 8, 10, 19, 54, 41, 87, DateTimeKind.Utc).AddTicks(6406),
                            Description = "This store has different types of designer wear",
                            ImageUrl = "https://media.architecturaldigest.com/photos/56045fcfcbec99cc0f9f7574/16:9/w_1280,c_limit/dam-images-daily-2014-10-jill-stuart-jill-stuart-soho.jpg",
                            IsDeleted = false,
                            OwnerId = new Guid("96521533-2970-4085-b6d0-08db81187eb1"),
                            ProvinceId = 20,
                            Rating = 0m,
                            Title = "Vanko's designer store"
                        });
                });

            modelBuilder.Entity("StoreManagementSystem.Data.Entities.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasDefaultValue("Test");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasDefaultValue("Test");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("StoreManagementSystem.Data.Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("StoreManagementSystem.Data.Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreManagementSystem.Data.Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("StoreManagementSystem.Data.Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StoreManagementSystem.Data.Entities.Models.Product", b =>
                {
                    b.HasOne("StoreManagementSystem.Data.Entities.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("StoreManagementSystem.Data.Entities.Models.Condition", "Condition")
                        .WithMany("Products")
                        .HasForeignKey("ConditionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("StoreManagementSystem.Data.Entities.Models.Store", "Store")
                        .WithMany("Products")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Condition");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("StoreManagementSystem.Data.Entities.Models.Store", b =>
                {
                    b.HasOne("StoreManagementSystem.Data.Entities.Models.City", "City")
                        .WithMany("Stores")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("StoreManagementSystem.Data.Entities.Models.User", "Owner")
                        .WithMany("Stores")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreManagementSystem.Data.Entities.Models.Province", "Province")
                        .WithMany("Stores")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Owner");

                    b.Navigation("Province");
                });

            modelBuilder.Entity("StoreManagementSystem.Data.Entities.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("StoreManagementSystem.Data.Entities.Models.City", b =>
                {
                    b.Navigation("Stores");
                });

            modelBuilder.Entity("StoreManagementSystem.Data.Entities.Models.Condition", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("StoreManagementSystem.Data.Entities.Models.Province", b =>
                {
                    b.Navigation("Stores");
                });

            modelBuilder.Entity("StoreManagementSystem.Data.Entities.Models.Store", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("StoreManagementSystem.Data.Entities.Models.User", b =>
                {
                    b.Navigation("Stores");
                });
#pragma warning restore 612, 618
        }
    }
}
