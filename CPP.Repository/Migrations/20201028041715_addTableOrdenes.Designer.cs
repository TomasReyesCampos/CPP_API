﻿// <auto-generated />
using System;
using CPP.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CPP.Repository.Migrations
{
    [DbContext(typeof(CPPContext))]
    [Migration("20201028041715_addTableOrdenes")]
    partial class addTableOrdenes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CPP.Entities.Data.EstadoOrden", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("estado_orden_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("estado_orden")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("estado_orden");
                });

            modelBuilder.Entity("CPP.Entities.Data.EstadoRemision", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("estado_remision")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("estado_remision");
                });

            modelBuilder.Entity("CPP.Entities.Data.FormaPago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("forma_pago_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("activo")
                        .HasColumnType("bit");

                    b.Property<string>("forma_pago")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("forma_pago");
                });

            modelBuilder.Entity("CPP.Entities.Data.Ordenes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("orden_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("estado_orden_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecha_alta")
                        .HasColumnType("datetime2");

                    b.Property<int>("proveedor_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("estado_orden_id")
                        .IsUnique();

                    b.HasIndex("proveedor_id");

                    b.ToTable("orden");
                });

            modelBuilder.Entity("CPP.Entities.Data.Proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("proveedor_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("activo")
                        .HasColumnType("bit");

                    b.Property<string>("codigo_postal")
                        .HasColumnType("nvarchar(6)")
                        .HasMaxLength(6);

                    b.Property<int>("dias_credito")
                        .HasColumnType("int");

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int>("forma_pago_id")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("rfc")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<int>("tipo_proveedor_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("forma_pago_id")
                        .IsUnique();

                    b.HasIndex("tipo_proveedor_id")
                        .IsUnique();

                    b.ToTable("proveedor");
                });

            modelBuilder.Entity("CPP.Entities.Data.ProveedorContacto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("proveedor_contacto_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ProveedorId")
                        .HasColumnType("int");

                    b.Property<string>("activo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("tipo_contacto_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProveedorId");

                    b.HasIndex("tipo_contacto_id")
                        .IsUnique();

                    b.ToTable("proveedor_contacto");
                });

            modelBuilder.Entity("CPP.Entities.Data.Remision", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("remision_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("OrdenesId")
                        .HasColumnType("int");

                    b.Property<bool>("activo")
                        .HasColumnType("bit");

                    b.Property<float>("cantidad")
                        .HasColumnType("real");

                    b.Property<string>("comentarios")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("estado_remision_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecha_pago")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fecha_remision")
                        .HasColumnType("datetime2");

                    b.Property<int>("proveedor_id")
                        .HasColumnType("int");

                    b.Property<int>("sucursal_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrdenesId");

                    b.HasIndex("estado_remision_id")
                        .IsUnique();

                    b.HasIndex("proveedor_id");

                    b.HasIndex("sucursal_id");

                    b.ToTable("remision");
                });

            modelBuilder.Entity("CPP.Entities.Data.Sucursal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("sucursal_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("activo")
                        .HasColumnType("bit");

                    b.Property<string>("encargado")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("sucursal");
                });

            modelBuilder.Entity("CPP.Entities.Data.TipoContacto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("activo")
                        .HasColumnType("bit");

                    b.Property<string>("tipo_contacto")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("tipo_contacto");
                });

            modelBuilder.Entity("CPP.Entities.Data.TipoProveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("tipo_proveedor_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("activo")
                        .HasColumnType("bit");

                    b.Property<string>("tipo_proveedor")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("tipo_proveedor");
                });

            modelBuilder.Entity("CPP.Entities.Data.Ordenes", b =>
                {
                    b.HasOne("CPP.Entities.Data.EstadoOrden", "estado_remision")
                        .WithOne("orden")
                        .HasForeignKey("CPP.Entities.Data.Ordenes", "estado_orden_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CPP.Entities.Data.Proveedor", "proveedor")
                        .WithMany()
                        .HasForeignKey("proveedor_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CPP.Entities.Data.Proveedor", b =>
                {
                    b.HasOne("CPP.Entities.Data.FormaPago", "forma_pago")
                        .WithOne("proveedor")
                        .HasForeignKey("CPP.Entities.Data.Proveedor", "forma_pago_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CPP.Entities.Data.TipoProveedor", "tipo_proveedor")
                        .WithOne("proveedor")
                        .HasForeignKey("CPP.Entities.Data.Proveedor", "tipo_proveedor_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CPP.Entities.Data.ProveedorContacto", b =>
                {
                    b.HasOne("CPP.Entities.Data.Proveedor", "Proveedor")
                        .WithMany("proveedor_contacto")
                        .HasForeignKey("ProveedorId");

                    b.HasOne("CPP.Entities.Data.TipoContacto", "TipoContacto")
                        .WithOne("proveedor_contacto")
                        .HasForeignKey("CPP.Entities.Data.ProveedorContacto", "tipo_contacto_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CPP.Entities.Data.Remision", b =>
                {
                    b.HasOne("CPP.Entities.Data.Ordenes", null)
                        .WithMany("remisiones")
                        .HasForeignKey("OrdenesId");

                    b.HasOne("CPP.Entities.Data.EstadoRemision", "estado_remision")
                        .WithOne("remision")
                        .HasForeignKey("CPP.Entities.Data.Remision", "estado_remision_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CPP.Entities.Data.Proveedor", "proveedor")
                        .WithMany("remisiones")
                        .HasForeignKey("proveedor_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CPP.Entities.Data.Sucursal", "sucursal")
                        .WithMany()
                        .HasForeignKey("sucursal_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
