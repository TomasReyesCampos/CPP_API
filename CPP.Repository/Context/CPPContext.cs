using CPP.Entities.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPP.Repository.Context
{
    public class CPPContext : DbContext
    {
        public CPPContext(DbContextOptions<CPPContext> options) : base(options)
        {
        }
        public DbSet<FormaPago> forma_pago { get; set; }
        public DbSet<Sucursal> sucursal { get; set; }
        public DbSet<EstadoRemision> estado_remision { get; set; }
        public DbSet<TipoProveedor> tipo_proveedor { get; set; }
        public DbSet<TipoContacto> tipo_contacto { get; set; }
        public DbSet<Proveedor> proveedor { get; set; }
        public DbSet<ProveedorContacto> proveedor_contacto { get; set; }
        public DbSet<Remision> remision { get; set; }
        public DbSet<Ordenes> orden { get; set; }
        public DbSet<EstadoOrden> estado_orden { get; set; }
        public DbSet<Usuario> usuario { get; set; }
        public DbSet<Rol> rol { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FormaPago>()
                .HasOne(a => a.proveedor)
                .WithOne(b => b.forma_pago)
                .HasForeignKey<Proveedor>(b => b.forma_pago_id);

            modelBuilder.Entity<TipoProveedor>()
               .HasOne(a => a.proveedor)
               .WithOne(b => b.tipo_proveedor)
               .HasForeignKey<Proveedor>(b => b.tipo_proveedor_id);

            modelBuilder.Entity<TipoContacto>()
               .HasOne(a => a.proveedor_contacto)
               .WithOne(b => b.TipoContacto)
               .HasForeignKey<ProveedorContacto>(b => b.tipo_contacto_id);

            modelBuilder.Entity<Proveedor>()
                .HasMany(a => a.proveedor_contacto)
                .WithOne(b => b.Proveedor);

            modelBuilder.Entity<EstadoRemision>()
               .HasOne(a => a.remision)
               .WithOne(b => b.estado_remision)
               .HasForeignKey<Remision>(b => b.estado_remision_id);

             modelBuilder.Entity<Proveedor>()
                .HasMany(a => a.remisiones)
                .WithOne(b => b.proveedor);

            modelBuilder.Entity<Sucursal>()
                .HasOne(a => a.usuario).WithOne(b=> b.sucursal)
                .HasForeignKey<Usuario>(b => b.sucursal_id);

            modelBuilder.Entity<Rol>()
                .HasOne(a => a.usuario).WithOne(b => b.rol)
                .HasForeignKey<Usuario>(b => b.rol_id);


        }
    }
}
