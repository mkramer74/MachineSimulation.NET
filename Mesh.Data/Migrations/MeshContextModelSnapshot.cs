﻿// <auto-generated />
using System;
using Mesh.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mesh.Data.Migrations
{
    [DbContext(typeof(MeshContext))]
    partial class MeshContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Mesh.Data.Mesh", b =>
                {
                    b.Property<int>("MeshID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Data")
                        .HasColumnType("BLOB");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("MeshID");

                    b.ToTable("Meshes");
                });
#pragma warning restore 612, 618
        }
    }
}
