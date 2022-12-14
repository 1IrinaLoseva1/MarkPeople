// <auto-generated />
using System;
using MarkPeople.DBLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MarkPeople.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("MarkPeople.DBLayer.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("NameCountry")
                        .HasColumnType("text");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("MarkPeople.DBLayer.MarkQuality", b =>
                {
                    b.Property<int>("MarkQualityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Beauty")
                        .HasColumnType("integer");

                    b.Property<bool>("IsLikePizzaPineApple")
                        .HasColumnType("boolean");

                    b.Property<int>("Mind")
                        .HasColumnType("integer");

                    b.Property<int>("PeopleId")
                        .HasColumnType("integer");

                    b.Property<int>("Power")
                        .HasColumnType("integer");

                    b.HasKey("MarkQualityId");

                    b.HasIndex("PeopleId");

                    b.ToTable("MarkQualities");
                });

            modelBuilder.Entity("MarkPeople.DBLayer.People", b =>
                {
                    b.Property<int>("PeopleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("integer");

                    b.Property<int>("PeopleAge")
                        .HasColumnType("integer");

                    b.Property<DateTime>("PeopleBDay")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("PeopleName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.Property<string>("PeopleSurname")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.Property<int>("PeopleWeight")
                        .HasColumnType("integer");

                    b.HasKey("PeopleId");

                    b.HasIndex("CountryId");

                    b.ToTable("Peoples");
                });

            modelBuilder.Entity("MarkPeople.DBLayer.MarkQuality", b =>
                {
                    b.HasOne("MarkPeople.DBLayer.People", "People")
                        .WithMany()
                        .HasForeignKey("PeopleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("People");
                });

            modelBuilder.Entity("MarkPeople.DBLayer.People", b =>
                {
                    b.HasOne("MarkPeople.DBLayer.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });
#pragma warning restore 612, 618
        }
    }
}
