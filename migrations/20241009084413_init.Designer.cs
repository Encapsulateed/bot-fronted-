﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using front_bot.src.repository;

#nullable disable

namespace front_bot.Migrations
{
    [DbContext(typeof(FrontDbContext))]
    [Migration("20241009084413_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.7.24405.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("front_bot.src.repository.User", b =>
                {
                    b.Property<long>("ChatId")
                        .HasColumnType("bigint")
                        .HasColumnName("chatId");

                    b.Property<string>("Command")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("command");

                    b.Property<string>("Email")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("email");

                    b.Property<string>("Jwt")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)")
                        .HasColumnName("JWT");

                    b.Property<string>("Password")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)")
                        .HasColumnName("password");

                    b.Property<string>("Uuid")
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)")
                        .HasColumnName("uuid");

                    b.HasKey("ChatId")
                        .HasName("users_pkey");

                    b.ToTable("users", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
