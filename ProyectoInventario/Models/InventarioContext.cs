using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoInventario.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProyectoInventario.Models
{
    public class InventarioContext : DbContext
    {
        public InventarioContext() : base("InventarioContext")
        {

        }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Almacen> Almacenes { get; set; }
        public DbSet<Transaccion> Transacciones { get; set; }
        public DbSet<TipoInventario> Tipo_Inventario { get; set; }

    }
}
