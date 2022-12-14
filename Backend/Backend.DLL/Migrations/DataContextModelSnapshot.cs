// <auto-generated />
using System;
using Backend.DLL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend.DLL.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Backend.DLL.Models.CountingData", b =>
                {
                    b.Property<int>("CountingDataId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CountingDataId"));

                    b.Property<DateTime>("FromTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("JoCount")
                        .HasColumnType("integer");

                    b.Property<int>("OlajosCount")
                        .HasColumnType("integer");

                    b.Property<int>("RepedtCount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ToTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("TorottSzelCount")
                        .HasColumnType("integer");

                    b.Property<int>("TotalCount")
                        .HasColumnType("integer");

                    b.HasKey("CountingDataId");

                    b.ToTable("countingDatas");
                });
#pragma warning restore 612, 618
        }
    }
}
