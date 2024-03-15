﻿// <auto-generated />
using Invoice_Inventory_mgmt.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Invoice_Inventory_mgmt.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Invoice_Inventory_mgmt.Model.CityMaster", b =>
                {
                    b.Property<int>("CityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityID"));

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StateID")
                        .HasColumnType("int");

                    b.HasKey("CityID");

                    b.HasIndex("StateID");

                    b.ToTable("CityMasters");
                });

            modelBuilder.Entity("Invoice_Inventory_mgmt.Model.StateMaster", b =>
                {
                    b.Property<int>("StateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StateID"));

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StateID");

                    b.ToTable("StateMasters");
                });

            modelBuilder.Entity("Invoice_Inventory_mgmt.Model.CityMaster", b =>
                {
                    b.HasOne("Invoice_Inventory_mgmt.Model.StateMaster", "stateMaster")
                        .WithMany("CityMasters")
                        .HasForeignKey("StateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("stateMaster");
                });

            modelBuilder.Entity("Invoice_Inventory_mgmt.Model.StateMaster", b =>
                {
                    b.Navigation("CityMasters");
                });
#pragma warning restore 612, 618
        }
    }
}
