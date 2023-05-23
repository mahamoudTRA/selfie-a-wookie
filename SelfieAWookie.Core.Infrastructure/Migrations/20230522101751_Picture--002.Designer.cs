﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SelfieAWookie.Core.Infrastructure.Data;

#nullable disable

namespace SelfieAWookie.Core.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230522101751_Picture--002")]
    partial class Picture002
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SelfieAWookie.Core.Domain.Models.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly>("CreateDate")
                        .HasColumnType("date");

                    b.Property<string>("Url")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Picture", (string)null);
                });

            modelBuilder.Entity("SelfieAWookie.Core.Domain.Models.Selfie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .HasColumnType("longtext");

                    b.Property<int>("PictureId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<int>("WookieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PictureId");

                    b.HasIndex("WookieId");

                    b.ToTable("Selfie", (string)null);
                });

            modelBuilder.Entity("SelfieAWookie.Core.Domain.Models.Wookie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Wookie", (string)null);
                });

            modelBuilder.Entity("SelfieAWookie.Core.Domain.Models.Selfie", b =>
                {
                    b.HasOne("SelfieAWookie.Core.Domain.Models.Picture", "Picture")
                        .WithMany("Selfies")
                        .HasForeignKey("PictureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SelfieAWookie.Core.Domain.Models.Wookie", "Wookie")
                        .WithMany("Selfies")
                        .HasForeignKey("WookieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Picture");

                    b.Navigation("Wookie");
                });

            modelBuilder.Entity("SelfieAWookie.Core.Domain.Models.Picture", b =>
                {
                    b.Navigation("Selfies");
                });

            modelBuilder.Entity("SelfieAWookie.Core.Domain.Models.Wookie", b =>
                {
                    b.Navigation("Selfies");
                });
#pragma warning restore 612, 618
        }
    }
}
