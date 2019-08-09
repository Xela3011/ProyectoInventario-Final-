using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using ProyectoInventario.Models;

namespace ProyectoInventario.Controllers
{
    public class asientosController : Controller
    {
        InventarioContext context = new InventarioContext();
        // GET: asientos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: asientos/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "descripcionAsiento,fechaDesde,fechaHasta")]asientoModel asiento)
        {
            try
            {
                string fechaDesdeFormateada = asiento.fechaDesde.ToString("yyyy-dd-MM");
                string fechaHastaFormateada = asiento.fechaHasta.ToString("yyyy-dd-MM");

                var montoTransacciones = context.Transacciones.SqlQuery("Select * from transaccion" +
                    " where fecha between '" + fechaDesdeFormateada + "' and '" + fechaHastaFormateada + "' ").ToList();

                Decimal sumaMontos = 0;
                foreach(var item in montoTransacciones)
                {
                    sumaMontos += item.monto;
                }
                
                if(sumaMontos <= 0)
                {
                    asientoModel asientoModel = new asientoModel();
                    asientoModel.ErrorMessage = "No se encontraron transacciones en este rango de fecha";
                    return View(asientoModel);
                }
                else
                {
                    jsonAsiento jsonAsiento = new jsonAsiento();
                    cuentaAsiento cuentaAsiento1 = new cuentaAsiento();
                    cuentaAsiento cuentaAsiento2 = new cuentaAsiento();
                    List<cuentaAsiento> listaCuentaAsiento = new List<cuentaAsiento>();

                    cuentaAsiento1.id = 6;
                    cuentaAsiento1.cuenta = "Inventario";
                    cuentaAsiento1.tipo = "DB";
                    cuentaAsiento1.monto = sumaMontos;

                    listaCuentaAsiento.Add(cuentaAsiento1);

                    cuentaAsiento2.id = 82;
                    cuentaAsiento2.cuenta = "Cuentas x Pagar Proveedor X";
                    cuentaAsiento2.tipo = "CR";
                    cuentaAsiento2.monto = sumaMontos;

                    listaCuentaAsiento.Add(cuentaAsiento2);

                    jsonAsiento.Cuentas = listaCuentaAsiento;
                    jsonAsiento.Descripcion = asiento.descripcionAsiento;
                    jsonAsiento.Auxiliar = 4;

                    string JsonResult = JsonConvert.SerializeObject(jsonAsiento);
                    CreateAsync(JsonResult).Wait();

                }
               

                return RedirectToAction("Index");
            }
            catch
            {
                return View(asiento);
            }
        }

        public async System.Threading.Tasks.Task<ActionResult> CreateAsync(string JsonResult)
        {
                 
                HttpClient cliente = new HttpClient();
                //This would be the like http://www.uber.com
                //client.BaseAddress = new Uri("https://sistemacontabilidad20190808055834.azurewebsites.net");
                //serialize your json using newtonsoft json serializer then add it to the StringContent
                var content = new StringContent(JsonResult, Encoding.UTF8, "application/json");
            //method address would be like api/callUber:SomePort for example
            var response = await cliente.PostAsync("https://sistemacontabilidad20190808055834.azurewebsites.net/api/asientocontable", content);
            string resultContent = await response.Content.ReadAsStringAsync();


            if (response.IsSuccessStatusCode)
            {
                asientoModel asientoModel = new asientoModel();
                asientoModel.ErrorMessage = "asiento registrado correctamente";
                return View(asientoModel);
            }
            else
            {
                asientoModel asientoModel = new asientoModel();
                asientoModel.ErrorMessage = "No se pudo enviar el asiento";
                return View(asientoModel);
            }




        }



    }
}
