﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Whats_Cookin.Server;

#nullable disable

namespace Whats_Cookin.Server.Migrations
{
    [DbContext(typeof(ServerContext))]
    [Migration("20250320071751_Hoja")]
    partial class Hoja
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Whats_Cookin.Server.Models.Food_Items", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FoodCategory")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FoodName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Food_Items");
                });

            modelBuilder.Entity("Whats_Cookin.Server.Models.Likes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("FoodId")
                        .HasColumnType("int");

                    b.Property<int?>("Food_ItemsId")
                        .HasColumnType("int");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Food_ItemsId");

                    b.HasIndex("UserId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("Whats_Cookin.Server.Models.Prebookings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BookingTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<int?>("RestaurantsId")
                        .HasColumnType("int");

                    b.Property<string>("TransactionId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantsId");

                    b.HasIndex("UserId");

                    b.ToTable("Prebookings");
                });

            modelBuilder.Entity("Whats_Cookin.Server.Models.Ratings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("FoodId")
                        .HasColumnType("int");

                    b.Property<int?>("Food_ItemsId")
                        .HasColumnType("int");

                    b.Property<int>("RatingValue")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<int?>("RestaurantsId")
                        .HasColumnType("int");

                    b.Property<string>("ReviewComment")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Food_ItemsId");

                    b.HasIndex("RestaurantsId");

                    b.HasIndex("UserId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("Whats_Cookin.Server.Models.Restaurants", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BuildingName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Capacity")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CurrentOccupancy")
                        .HasColumnType("int");

                    b.Property<string>("Landmark")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int>("Pincode")
                        .HasMaxLength(6)
                        .HasColumnType("int");

                    b.Property<string>("ShopNo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("Whats_Cookin.Server.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("User_Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Whats_Cookin.Server.Models.Food_Items", b =>
                {
                    b.HasOne("Whats_Cookin.Server.Models.Restaurants", "Restaurant")
                        .WithMany("FoodItems")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Whats_Cookin.Server.Models.Likes", b =>
                {
                    b.HasOne("Whats_Cookin.Server.Models.Food_Items", null)
                        .WithMany("Likes")
                        .HasForeignKey("Food_ItemsId");

                    b.HasOne("Whats_Cookin.Server.Models.Users", "User")
                        .WithMany("Likes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Whats_Cookin.Server.Models.Prebookings", b =>
                {
                    b.HasOne("Whats_Cookin.Server.Models.Restaurants", null)
                        .WithMany("Prebookings")
                        .HasForeignKey("RestaurantsId");

                    b.HasOne("Whats_Cookin.Server.Models.Users", "User")
                        .WithMany("Prebookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Whats_Cookin.Server.Models.Ratings", b =>
                {
                    b.HasOne("Whats_Cookin.Server.Models.Food_Items", null)
                        .WithMany("Ratings")
                        .HasForeignKey("Food_ItemsId");

                    b.HasOne("Whats_Cookin.Server.Models.Restaurants", null)
                        .WithMany("Ratings")
                        .HasForeignKey("RestaurantsId");

                    b.HasOne("Whats_Cookin.Server.Models.Users", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Whats_Cookin.Server.Models.Restaurants", b =>
                {
                    b.HasOne("Whats_Cookin.Server.Models.Users", "Owner")
                        .WithMany("Restaurants")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Whats_Cookin.Server.Models.Food_Items", b =>
                {
                    b.Navigation("Likes");

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("Whats_Cookin.Server.Models.Restaurants", b =>
                {
                    b.Navigation("FoodItems");

                    b.Navigation("Prebookings");

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("Whats_Cookin.Server.Models.Users", b =>
                {
                    b.Navigation("Likes");

                    b.Navigation("Prebookings");

                    b.Navigation("Ratings");

                    b.Navigation("Restaurants");
                });
#pragma warning restore 612, 618
        }
    }
}
