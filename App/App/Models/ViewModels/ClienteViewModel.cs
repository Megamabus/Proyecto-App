using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models
{
    public class ClienteViewModel
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefeno { get; set; }
        public List<ClienteViewModel> GetClientes() 
        {
            List<ClienteViewModel> lista = new List<ClienteViewModel> ();

            lista.Add(new ClienteViewModel(){
                Id = 1,
                Nombre = "Jhonnatan",
                Direccion = "Calle 1 Norte 1000",
                Telefeno = "111111111111"
            });
            lista.Add(new ClienteViewModel()
            {
                Id = 2,
                Nombre = "Maria",
                Direccion = "Calle 2 Norte 2000",
                Telefeno = "2222222222222"
            });
            lista.Add(new ClienteViewModel()
            {
                Id = 3,
                Nombre = "Pedra",
                Direccion = "Calle 3 Norte 3000",
                Telefeno = "33333333333333"
            });
            lista.Add(new ClienteViewModel()
            {
                Id = 4,
                Nombre = "Adrian",
                Direccion = "Calle 4 Norte 4000",
                Telefeno = "44444444444444"

            });

            return lista;
        }
    }
}