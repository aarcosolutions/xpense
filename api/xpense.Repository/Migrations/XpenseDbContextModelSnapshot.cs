using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using xpense.Repository;
using xpense.DataModel;

namespace xpense.Repository.Migrations
{
    [DbContext(typeof(XpenseDbContext))]
    partial class XpenseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("xpense.DataModel.Employee", b =>
                {
                    b.Property<long>("EmployeeId")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<DateTime>("DateOfJoining");

                    b.Property<DateTime>("DateOfLeaving");

                    b.Property<string>("EmployeeNumber")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(75);

                    b.Property<bool>("IsArchived");

                    b.Property<Guid>("Key");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(75);

                    b.Property<string>("MiddleName");

                    b.Property<long?>("ModifiedBy");

                    b.Property<string>("NiNumber")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<long>("OrganisationId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.HasKey("EmployeeId");

                    b.HasIndex("OrganisationId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("xpense.DataModel.EmployeeContactDetail", b =>
                {
                    b.Property<long>("EmployeeContactDetailId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("AddressLine2")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<long?>("CityId");

                    b.Property<int>("ContactType");

                    b.Property<long?>("CountryId");

                    b.Property<long?>("CountyId");

                    b.Property<string>("Email")
                        .HasMaxLength(75);

                    b.Property<long>("EmployeeId");

                    b.Property<string>("Fax")
                        .HasMaxLength(75);

                    b.Property<Guid>("Key");

                    b.Property<string>("Phone1")
                        .HasMaxLength(75);

                    b.Property<string>("Phone2")
                        .HasMaxLength(10);

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("EmployeeContactDetailId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeContactDetail");
                });

            modelBuilder.Entity("xpense.DataModel.Organisation", b =>
                {
                    b.Property<long>("OrganisationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyNumber")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<long?>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<DateTime?>("IncorporationDate");

                    b.Property<bool>("IsArchived");

                    b.Property<Guid>("Key");

                    b.Property<long?>("ModifiedBy");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("PayeReference")
                        .HasMaxLength(30);

                    b.Property<string>("PayeTaxOfficeReference")
                        .HasMaxLength(30);

                    b.Property<string>("RegisteredAddress")
                        .HasMaxLength(500);

                    b.Property<string>("UniqueTaxpayerReference")
                        .HasMaxLength(15);

                    b.Property<string>("VatNumber")
                        .HasMaxLength(10);

                    b.HasKey("OrganisationId");

                    b.ToTable("Organisation");
                });

            modelBuilder.Entity("xpense.DataModel.Employee", b =>
                {
                    b.HasOne("xpense.DataModel.Organisation", "Organisation")
                        .WithMany()
                        .HasForeignKey("OrganisationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("xpense.DataModel.EmployeeContactDetail", b =>
                {
                    b.HasOne("xpense.DataModel.Employee", "Employee")
                        .WithMany("ContactDetails")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
