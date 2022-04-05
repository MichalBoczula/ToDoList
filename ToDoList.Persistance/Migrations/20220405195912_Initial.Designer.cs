﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoList.Persistance.Context;

namespace ToDoList.Persistance.Migrations
{
    [DbContext(typeof(ToDoDbContext))]
    [Migration("20220405195912_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ToDoList.Domain.Model.Dictionary.TaskProgressionLevels", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TaskProgressionLevels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "ToDo"
                        },
                        new
                        {
                            Id = 2,
                            Name = "InProgress"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Done"
                        });
                });

            modelBuilder.Entity("ToDoList.Domain.Model.Entities.Board", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Boards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Board"
                        });
                });

            modelBuilder.Entity("ToDoList.Domain.Model.Entities.ToDoList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BoardId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.ToTable("Lists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BoardId = 1,
                            Name = "House Duties"
                        },
                        new
                        {
                            Id = 2,
                            BoardId = 1,
                            Name = "Job"
                        },
                        new
                        {
                            Id = 3,
                            BoardId = 1,
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("ToDoList.Domain.Model.Entities.ToDoTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("Estimation")
                        .HasColumnType("int");

                    b.Property<int>("ListId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaskProgressionLevelsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ListId");

                    b.HasIndex("TaskProgressionLevelsId");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Duration = 5,
                            Estimation = 7,
                            ListId = 1,
                            Name = "First task",
                            TaskProgressionLevelsId = 2
                        },
                        new
                        {
                            Id = 2,
                            Duration = 0,
                            Estimation = 2,
                            ListId = 1,
                            Name = "Second task",
                            TaskProgressionLevelsId = 1
                        },
                        new
                        {
                            Id = 3,
                            Duration = 0,
                            Estimation = 3,
                            ListId = 1,
                            Name = "Third Task",
                            TaskProgressionLevelsId = 1
                        },
                        new
                        {
                            Id = 4,
                            Duration = 3,
                            Estimation = 10,
                            ListId = 2,
                            Name = "Fourth task",
                            TaskProgressionLevelsId = 2
                        },
                        new
                        {
                            Id = 5,
                            Duration = 0,
                            Estimation = 3,
                            ListId = 2,
                            Name = "Fifth task",
                            TaskProgressionLevelsId = 1
                        },
                        new
                        {
                            Id = 6,
                            Duration = 6,
                            Estimation = 4,
                            ListId = 2,
                            Name = "Sixth Task",
                            TaskProgressionLevelsId = 3
                        },
                        new
                        {
                            Id = 7,
                            Duration = 15,
                            Estimation = 15,
                            ListId = 3,
                            Name = "Seventh task",
                            TaskProgressionLevelsId = 2
                        },
                        new
                        {
                            Id = 8,
                            Duration = 5,
                            Estimation = 2,
                            ListId = 3,
                            Name = "Eighth task",
                            TaskProgressionLevelsId = 3
                        },
                        new
                        {
                            Id = 9,
                            Duration = 5,
                            Estimation = 6,
                            ListId = 3,
                            Name = "Nineth Task",
                            TaskProgressionLevelsId = 3
                        });
                });

            modelBuilder.Entity("ToDoList.Domain.Model.Entities.ToDoList", b =>
                {
                    b.HasOne("ToDoList.Domain.Model.Entities.Board", "Board")
                        .WithMany("ToDoLists")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Board");
                });

            modelBuilder.Entity("ToDoList.Domain.Model.Entities.ToDoTask", b =>
                {
                    b.HasOne("ToDoList.Domain.Model.Entities.ToDoList", "List")
                        .WithMany("ToDoTasks")
                        .HasForeignKey("ListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ToDoList.Domain.Model.Dictionary.TaskProgressionLevels", "Progress")
                        .WithMany("Tasks")
                        .HasForeignKey("TaskProgressionLevelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("List");

                    b.Navigation("Progress");
                });

            modelBuilder.Entity("ToDoList.Domain.Model.Dictionary.TaskProgressionLevels", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("ToDoList.Domain.Model.Entities.Board", b =>
                {
                    b.Navigation("ToDoLists");
                });

            modelBuilder.Entity("ToDoList.Domain.Model.Entities.ToDoList", b =>
                {
                    b.Navigation("ToDoTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
