﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SODbLoad;

namespace SODbLoad.Migrations
{
    [DbContext(typeof(SoDbContext))]
    partial class SoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SODbLoad.Item", b =>
                {
                    b.Property<int>("question_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("answer_count");

                    b.Property<int?>("closed_date");

                    b.Property<string>("closed_reason");

                    b.Property<int>("creation_date");

                    b.Property<bool>("is_answered");

                    b.Property<int>("last_activity_date");

                    b.Property<int?>("last_edit_date");

                    b.Property<string>("link");

                    b.Property<int?>("owneruser_id");

                    b.Property<int>("score");

                    b.Property<string>("tags");

                    b.Property<string>("title");

                    b.Property<int>("view_count");

                    b.HasKey("question_id");

                    b.HasIndex("owneruser_id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("SODbLoad.Owner", b =>
                {
                    b.Property<int>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("accept_rate");

                    b.Property<string>("display_name");

                    b.Property<string>("link");

                    b.Property<string>("profile_image");

                    b.Property<int>("reputation");

                    b.Property<string>("user_type");

                    b.HasKey("user_id");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("SODbLoad.Item", b =>
                {
                    b.HasOne("SODbLoad.Owner", "owner")
                        .WithMany()
                        .HasForeignKey("owneruser_id");
                });
#pragma warning restore 612, 618
        }
    }
}
