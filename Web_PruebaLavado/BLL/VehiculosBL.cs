using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VehiculosBL
    {
        public VehiculosBL() { 
            
        }

        public async Task<List<Vehiculo>> GetVehiculos()
        {
            List<Vehiculo> reservationList = new List<Vehiculo>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7270/api/Vehiculos"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservationList = JsonConvert.DeserializeObject<List<Vehiculo>>(apiResponse);
                }
            }
            return reservationList;
        }

        public async Task<Vehiculo> AddVehiculo(Vehiculo vehiculo)
        {
            Vehiculo vehiculoRecibido = new Vehiculo();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(vehiculo), Encoding.UTF8, "application/json");
               
                using (var response = await httpClient.PostAsync("https://localhost:7270/api/Vehiculos", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    vehiculoRecibido = JsonConvert.DeserializeObject<Vehiculo>(apiResponse);
                }
            }
            return vehiculoRecibido;
        }
    }
}
