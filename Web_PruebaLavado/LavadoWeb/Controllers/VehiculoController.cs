using BLL;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace LavadoWeb.Controllers
{
    public class VehiculoController : Controller
    {
        public async Task<IActionResult> Index()
        {
            VehiculosBL vbl = new VehiculosBL();
            IEnumerable<Vehiculo> vehiculos = await vbl.GetVehiculos();

            return View(vehiculos);
        }

        //public async Task<IActionResult> Create()
        //{
        //    return View();
        //}

        public async Task<IActionResult> Create(Vehiculo vehiculo)
        {
            VehiculosBL vbl = new VehiculosBL();
            Vehiculo vehiculoRecibido = await vbl.AddVehiculo(vehiculo);
            return View(vehiculoRecibido);
        }
    }
}
