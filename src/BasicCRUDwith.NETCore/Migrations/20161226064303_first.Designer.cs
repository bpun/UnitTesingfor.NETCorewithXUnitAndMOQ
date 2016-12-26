using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BasicCRUDwith.NETCore.DbContexts;

namespace BasicCRUDwith.NETCore.Migrations
{
    [DbContext(typeof(StudentContext))]
    [Migration("20161226064303_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BasicCRUDwith.NETCore.Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Contact");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Students");
                });
        }
    }
}
