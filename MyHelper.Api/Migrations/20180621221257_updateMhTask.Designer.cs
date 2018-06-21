﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyHelper.Api.DAL.Context;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MyHelper.Api.Migrations
{
    [DbContext(typeof(MyHelperContext))]
    [Migration("20180621221257_updateMhTask")]
    partial class updateMhTask
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("MyHelper.Api.DAL.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Avatar");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<int>("UserRole");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("MyHelper.Api.DAL.Entities.Friend", b =>
                {
                    b.Property<int>("RequestedById");

                    b.Property<int>("RequestedToId");

                    b.Property<DateTime?>("BecameFriendsTime");

                    b.Property<int>("FriendRequestFlag");

                    b.Property<DateTime?>("RequestTime");

                    b.HasKey("RequestedById", "RequestedToId");

                    b.HasIndex("RequestedToId");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("MyHelper.Api.DAL.Entities.MhTask", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AppUserId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("FinishDate");

                    b.Property<bool>("IsRecurring");

                    b.Property<int>("MhTaskState");

                    b.Property<int>("MhTaskStatus");

                    b.Property<int>("MhTaskVisibleType");

                    b.Property<string>("Name");

                    b.Property<long?>("ParentId");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("ParentId");

                    b.ToTable("MhTasks");
                });

            modelBuilder.Entity("MyHelper.Api.DAL.Entities.MhTaskTag", b =>
                {
                    b.Property<long>("MhTaskId");

                    b.Property<long>("TagId");

                    b.HasKey("MhTaskId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("MhTaskTags");
                });

            modelBuilder.Entity("MyHelper.Api.DAL.Entities.Note", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AppUserId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("MyHelper.Api.DAL.Entities.NoteTag", b =>
                {
                    b.Property<long>("NoteId");

                    b.Property<long>("TagId");

                    b.HasKey("NoteId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("NoteTags");
                });

            modelBuilder.Entity("MyHelper.Api.DAL.Entities.ScheduleMhTask", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("MaxCount");

                    b.Property<long>("MhTaskId");

                    b.Property<int>("ScheduleMhTaskType");

                    b.HasKey("Id");

                    b.HasIndex("MhTaskId")
                        .IsUnique();

                    b.ToTable("ScheduleMhTasks");
                });

            modelBuilder.Entity("MyHelper.Api.DAL.Entities.Tag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("MyHelper.Api.DAL.Entities.UpdateMhTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<long>("MhTaskId");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("Id");

                    b.HasIndex("MhTaskId");

                    b.ToTable("UpdateMhTasks");
                });

            modelBuilder.Entity("MyHelper.Api.DAL.Entities.Friend", b =>
                {
                    b.HasOne("MyHelper.Api.DAL.Entities.AppUser", "RequestedBy")
                        .WithMany("SentFriendRequests")
                        .HasForeignKey("RequestedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MyHelper.Api.DAL.Entities.AppUser", "RequestedTo")
                        .WithMany("ReceievedFriendRequests")
                        .HasForeignKey("RequestedToId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("MyHelper.Api.DAL.Entities.MhTask", b =>
                {
                    b.HasOne("MyHelper.Api.DAL.Entities.AppUser", "AppUser")
                        .WithMany("MhTasks")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MyHelper.Api.DAL.Entities.MhTask", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("MyHelper.Api.DAL.Entities.MhTaskTag", b =>
                {
                    b.HasOne("MyHelper.Api.DAL.Entities.MhTask", "MhTask")
                        .WithMany("MhTaskTags")
                        .HasForeignKey("MhTaskId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyHelper.Api.DAL.Entities.Tag", "Tag")
                        .WithMany("MhTaskTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyHelper.Api.DAL.Entities.Note", b =>
                {
                    b.HasOne("MyHelper.Api.DAL.Entities.AppUser", "AppUser")
                        .WithMany("Notes")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyHelper.Api.DAL.Entities.NoteTag", b =>
                {
                    b.HasOne("MyHelper.Api.DAL.Entities.Note", "Note")
                        .WithMany("NoteTags")
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyHelper.Api.DAL.Entities.Tag", "Tag")
                        .WithMany("NoteTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyHelper.Api.DAL.Entities.ScheduleMhTask", b =>
                {
                    b.HasOne("MyHelper.Api.DAL.Entities.MhTask", "MhTask")
                        .WithOne("ScheduleMhTask")
                        .HasForeignKey("MyHelper.Api.DAL.Entities.ScheduleMhTask", "MhTaskId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyHelper.Api.DAL.Entities.UpdateMhTask", b =>
                {
                    b.HasOne("MyHelper.Api.DAL.Entities.MhTask", "MhTask")
                        .WithMany("Updates")
                        .HasForeignKey("MhTaskId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
