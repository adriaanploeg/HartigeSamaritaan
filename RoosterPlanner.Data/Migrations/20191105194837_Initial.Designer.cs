﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RoosterPlanner.Data.Context;

namespace RoosterPlanner.Data.Migrations
{
    [DbContext(typeof(RoosterPlannerContext))]
    [Migration("20191105194837_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RoosterPlanner.Models.Project", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<bool>("Closed");

                    b.Property<DateTime?>("EndDate");

                    b.Property<string>("LastEditBy")
                        .HasMaxLength(128);

                    b.Property<DateTime>("LastEditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("RoosterPlanner.Models.ProjectTask", b =>
                {
                    b.Property<Guid>("ProjectId");

                    b.Property<int>("TaskId");

                    b.Property<string>("LastEditBy")
                        .HasMaxLength(128);

                    b.Property<DateTime>("LastEditDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("ProjectId", "TaskId");

                    b.HasIndex("TaskId");

                    b.ToTable("ProjectTask");
                });

            modelBuilder.Entity("RoosterPlanner.Models.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DeletedDateTime");

                    b.Property<string>("LastEditBy")
                        .HasMaxLength(128);

                    b.Property<DateTime>("LastEditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("RoosterPlanner.Models.ProjectTask", b =>
                {
                    b.HasOne("RoosterPlanner.Models.Project", "Project")
                        .WithMany("ProjectTasks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RoosterPlanner.Models.Task", "Task")
                        .WithMany("TaskProjects")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}