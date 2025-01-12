﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Test_Case.Models;

#nullable disable

namespace Test_Case.Migrations
{
    [DbContext(typeof(LZ_Context))]
    [Migration("20250108192011_AddedCommentModel1")]
    partial class AddedCommentModel1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Offer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Blurb")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("OfferPrice")
                        .HasColumnType("int");

                    b.Property<int>("RequestId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.HasIndex("UserId");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("Test_Case.Models.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ToUserId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("Test_Case.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("RecipientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("RecipientId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Test_Case.Models.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AveragePrice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("bit");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("Test_Case.Models.RequestDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RequestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.ToTable("RequestDetails");
                });

            modelBuilder.Entity("Test_Case.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProviderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Test_Case.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreditCardCvvCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreditCardLastMonth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreditCardLastYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreditCardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isVerified")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 1, 8, 19, 20, 11, 682, DateTimeKind.Utc).AddTicks(4390),
                            CreditCardCvvCode = "",
                            CreditCardLastMonth = "",
                            CreditCardLastYear = "",
                            CreditCardNumber = "",
                            Email = "admin@admin.com",
                            Name = "admin",
                            Password = "admin",
                            Role = "Admin",
                            UpdatedAt = new DateTime(2025, 1, 8, 19, 20, 11, 682, DateTimeKind.Utc).AddTicks(4390),
                            isVerified = true
                        });
                });

            modelBuilder.Entity("Offer", b =>
                {
                    b.HasOne("Test_Case.Models.Request", "Request")
                        .WithMany()
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Test_Case.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Request");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Test_Case.Models.Comment", b =>
                {
                    b.HasOne("Test_Case.Models.User", "Author")
                        .WithMany("SentComments")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Test_Case.Models.User", "Recipient")
                        .WithMany("ReceivedComments")
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Recipient");
                });

            modelBuilder.Entity("Test_Case.Models.Request", b =>
                {
                    b.HasOne("Test_Case.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Test_Case.Models.RequestDetails", b =>
                {
                    b.HasOne("Test_Case.Models.Request", null)
                        .WithMany("Details")
                        .HasForeignKey("RequestId");
                });

            modelBuilder.Entity("Test_Case.Models.Request", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("Test_Case.Models.User", b =>
                {
                    b.Navigation("ReceivedComments");

                    b.Navigation("SentComments");
                });
#pragma warning restore 612, 618
        }
    }
}
