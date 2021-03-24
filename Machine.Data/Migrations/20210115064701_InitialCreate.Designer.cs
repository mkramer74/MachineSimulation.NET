﻿// <auto-generated />
using System;
using Machine.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Machine.Data.Migrations
{
    [DbContext(typeof(MachineContext))]
    [Migration("20210115064701_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Machine.Data.Links.Link", b =>
                {
                    b.Property<int>("LinkID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Direction")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("LinkID");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("Machine.Data.MachineElements.Color", b =>
                {
                    b.Property<int>("ColorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte>("A")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("B")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("G")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("R")
                        .HasColumnType("INTEGER");

                    b.HasKey("ColorID");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("Machine.Data.MachineElements.MachineElement", b =>
                {
                    b.Property<int>("MachineElementID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ColorID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("LinkToParentLinkID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MachineElementID1")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ModelFile")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TransformationMatrixID")
                        .HasColumnType("INTEGER");

                    b.HasKey("MachineElementID");

                    b.HasIndex("ColorID");

                    b.HasIndex("LinkToParentLinkID");

                    b.HasIndex("MachineElementID1");

                    b.HasIndex("TransformationMatrixID");

                    b.ToTable("MachineElements");
                });

            modelBuilder.Entity("Machine.Data.MachineElements.Matrix", b =>
                {
                    b.Property<int>("MatrixID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("M11")
                        .HasColumnType("REAL");

                    b.Property<double>("M12")
                        .HasColumnType("REAL");

                    b.Property<double>("M13")
                        .HasColumnType("REAL");

                    b.Property<double>("M21")
                        .HasColumnType("REAL");

                    b.Property<double>("M22")
                        .HasColumnType("REAL");

                    b.Property<double>("M23")
                        .HasColumnType("REAL");

                    b.Property<double>("M31")
                        .HasColumnType("REAL");

                    b.Property<double>("M32")
                        .HasColumnType("REAL");

                    b.Property<double>("M33")
                        .HasColumnType("REAL");

                    b.Property<double>("OffsetX")
                        .HasColumnType("REAL");

                    b.Property<double>("OffsetY")
                        .HasColumnType("REAL");

                    b.Property<double>("OffsetZ")
                        .HasColumnType("REAL");

                    b.HasKey("MatrixID");

                    b.ToTable("Matrices");
                });

            modelBuilder.Entity("Machine.Data.MachineElements.Point", b =>
                {
                    b.Property<int>("PointID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ColliderElementMachineElementID")
                        .HasColumnType("INTEGER");

                    b.Property<double>("X")
                        .HasColumnType("REAL");

                    b.Property<double>("Y")
                        .HasColumnType("REAL");

                    b.Property<double>("Z")
                        .HasColumnType("REAL");

                    b.HasKey("PointID");

                    b.HasIndex("ColliderElementMachineElementID");

                    b.ToTable("Points");
                });

            modelBuilder.Entity("Machine.Data.MachineElements.Vector", b =>
                {
                    b.Property<int>("VectorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("X")
                        .HasColumnType("REAL");

                    b.Property<double>("Y")
                        .HasColumnType("REAL");

                    b.Property<double>("Z")
                        .HasColumnType("REAL");

                    b.HasKey("VectorID");

                    b.ToTable("Vectors");
                });

            modelBuilder.Entity("Machine.Data.Links.LinearLink", b =>
                {
                    b.HasBaseType("Machine.Data.Links.Link");

                    b.Property<double>("Max")
                        .HasColumnType("REAL");

                    b.Property<double>("Min")
                        .HasColumnType("REAL");

                    b.Property<double>("Pos")
                        .HasColumnType("REAL");

                    b.ToTable("LinearLink");
                });

            modelBuilder.Entity("Machine.Data.Links.PneumaticLink", b =>
                {
                    b.HasBaseType("Machine.Data.Links.Link");

                    b.Property<double>("OffPos")
                        .HasColumnType("REAL");

                    b.Property<double>("OnPos")
                        .HasColumnType("REAL");

                    b.Property<double>("TOff")
                        .HasColumnType("REAL");

                    b.Property<double>("TOn")
                        .HasColumnType("REAL");

                    b.Property<bool>("ToolActivator")
                        .HasColumnType("INTEGER");

                    b.ToTable("PneumaticLink");
                });

            modelBuilder.Entity("Machine.Data.MachineElements.ColliderElement", b =>
                {
                    b.HasBaseType("Machine.Data.MachineElements.MachineElement");

                    b.Property<double>("Radius")
                        .HasColumnType("REAL");

                    b.ToTable("ColliderElement");
                });

            modelBuilder.Entity("Machine.Data.MachineElements.InjectorElement", b =>
                {
                    b.HasBaseType("Machine.Data.MachineElements.MachineElement");

                    b.Property<int?>("DirectionVectorID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("InserterColorColorID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("InserterId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PositionVectorID")
                        .HasColumnType("INTEGER");

                    b.HasIndex("DirectionVectorID");

                    b.HasIndex("InserterColorColorID");

                    b.HasIndex("PositionVectorID");

                    b.ToTable("InjectorElement");
                });

            modelBuilder.Entity("Machine.Data.MachineElements.PanelHolderElement", b =>
                {
                    b.HasBaseType("Machine.Data.MachineElements.MachineElement");

                    b.Property<int>("Corner")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PanelHolderId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PanelHolderName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PositionVectorID")
                        .HasColumnType("INTEGER");

                    b.HasIndex("PositionVectorID");

                    b.ToTable("PanelHolderElement");
                });

            modelBuilder.Entity("Machine.Data.MachineElements.RootElement", b =>
                {
                    b.HasBaseType("Machine.Data.MachineElements.MachineElement");

                    b.Property<string>("AssemblyName")
                        .HasColumnType("TEXT");

                    b.Property<int>("RootType")
                        .HasColumnType("INTEGER");

                    b.ToTable("RootElement");
                });

            modelBuilder.Entity("Machine.Data.MachineElements.ToolholderElement", b =>
                {
                    b.HasBaseType("Machine.Data.MachineElements.MachineElement");

                    b.Property<int?>("DirectionVectorID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PositionVectorID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ToolHolderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ToolHolderType")
                        .HasColumnType("INTEGER");

                    b.HasIndex("DirectionVectorID");

                    b.HasIndex("PositionVectorID");

                    b.ToTable("ToolholderElement");
                });

            modelBuilder.Entity("Machine.Data.MachineElements.InserterElement", b =>
                {
                    b.HasBaseType("Machine.Data.MachineElements.InjectorElement");

                    b.Property<double>("Diameter")
                        .HasColumnType("REAL");

                    b.Property<int>("DischargerLinkId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Length")
                        .HasColumnType("REAL");

                    b.Property<int>("LoaderLinkId")
                        .HasColumnType("INTEGER");

                    b.ToTable("InserterElement");
                });

            modelBuilder.Entity("Machine.Data.MachineElements.MachineElement", b =>
                {
                    b.HasOne("Machine.Data.MachineElements.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorID");

                    b.HasOne("Machine.Data.Links.Link", "LinkToParent")
                        .WithMany()
                        .HasForeignKey("LinkToParentLinkID");

                    b.HasOne("Machine.Data.MachineElements.MachineElement", null)
                        .WithMany("Children")
                        .HasForeignKey("MachineElementID1");

                    b.HasOne("Machine.Data.MachineElements.Matrix", "Transformation")
                        .WithMany()
                        .HasForeignKey("TransformationMatrixID");

                    b.Navigation("Color");

                    b.Navigation("LinkToParent");

                    b.Navigation("Transformation");
                });

            modelBuilder.Entity("Machine.Data.MachineElements.Point", b =>
                {
                    b.HasOne("Machine.Data.MachineElements.ColliderElement", null)
                        .WithMany("Points")
                        .HasForeignKey("ColliderElementMachineElementID");
                });

            modelBuilder.Entity("Machine.Data.Links.LinearLink", b =>
                {
                    b.HasOne("Machine.Data.Links.Link", null)
                        .WithOne()
                        .HasForeignKey("Machine.Data.Links.LinearLink", "LinkID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Machine.Data.Links.PneumaticLink", b =>
                {
                    b.HasOne("Machine.Data.Links.Link", null)
                        .WithOne()
                        .HasForeignKey("Machine.Data.Links.PneumaticLink", "LinkID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Machine.Data.MachineElements.ColliderElement", b =>
                {
                    b.HasOne("Machine.Data.MachineElements.MachineElement", null)
                        .WithOne()
                        .HasForeignKey("Machine.Data.MachineElements.ColliderElement", "MachineElementID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Machine.Data.MachineElements.InjectorElement", b =>
                {
                    b.HasOne("Machine.Data.MachineElements.Vector", "Direction")
                        .WithMany()
                        .HasForeignKey("DirectionVectorID");

                    b.HasOne("Machine.Data.MachineElements.Color", "InserterColor")
                        .WithMany()
                        .HasForeignKey("InserterColorColorID");

                    b.HasOne("Machine.Data.MachineElements.MachineElement", null)
                        .WithOne()
                        .HasForeignKey("Machine.Data.MachineElements.InjectorElement", "MachineElementID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Machine.Data.MachineElements.Vector", "Position")
                        .WithMany()
                        .HasForeignKey("PositionVectorID");

                    b.Navigation("Direction");

                    b.Navigation("InserterColor");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("Machine.Data.MachineElements.PanelHolderElement", b =>
                {
                    b.HasOne("Machine.Data.MachineElements.MachineElement", null)
                        .WithOne()
                        .HasForeignKey("Machine.Data.MachineElements.PanelHolderElement", "MachineElementID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Machine.Data.MachineElements.Vector", "Position")
                        .WithMany()
                        .HasForeignKey("PositionVectorID");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("Machine.Data.MachineElements.RootElement", b =>
                {
                    b.HasOne("Machine.Data.MachineElements.MachineElement", null)
                        .WithOne()
                        .HasForeignKey("Machine.Data.MachineElements.RootElement", "MachineElementID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Machine.Data.MachineElements.ToolholderElement", b =>
                {
                    b.HasOne("Machine.Data.MachineElements.Vector", "Direction")
                        .WithMany()
                        .HasForeignKey("DirectionVectorID");

                    b.HasOne("Machine.Data.MachineElements.MachineElement", null)
                        .WithOne()
                        .HasForeignKey("Machine.Data.MachineElements.ToolholderElement", "MachineElementID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Machine.Data.MachineElements.Vector", "Position")
                        .WithMany()
                        .HasForeignKey("PositionVectorID");

                    b.Navigation("Direction");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("Machine.Data.MachineElements.InserterElement", b =>
                {
                    b.HasOne("Machine.Data.MachineElements.InjectorElement", null)
                        .WithOne()
                        .HasForeignKey("Machine.Data.MachineElements.InserterElement", "MachineElementID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Machine.Data.MachineElements.MachineElement", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("Machine.Data.MachineElements.ColliderElement", b =>
                {
                    b.Navigation("Points");
                });
#pragma warning restore 612, 618
        }
    }
}
