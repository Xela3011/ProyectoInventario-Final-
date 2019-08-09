
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProyectoInventario.Models;

namespace ProyectoInventario.Models
{
    public class InitInventario : System.Data.Entity.DropCreateDatabaseIfModelChanges<InventarioContext>
    {
        protected override void Seed(InventarioContext context)
        {
            //var students = new List<Articulo>
            //{
            //new Articulo{descripcion_articulo="Cosa",existencia= 10,id_tipo_inventario= 1},

            //};
        }


    }
}