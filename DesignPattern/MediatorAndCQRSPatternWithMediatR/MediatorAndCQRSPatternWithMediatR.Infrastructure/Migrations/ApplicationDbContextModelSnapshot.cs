﻿// <auto-generated />
using MediatorAndCQRSPatternWithMediatR.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MediatorAndCQRSPatternWithMediatR.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MediatorAndCQRSPatternWithMediatR.Core.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Shelly Marshall"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Christine Soto"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Angela Mcpherson"
                        },
                        new
                        {
                            Id = 4,
                            Name = "David Quinn"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Yvonne Mccoy"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Samantha Webb"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Karina Clay"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Frank Davidson"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Haley Tate"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Stacey Sawyer"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
