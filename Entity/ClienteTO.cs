using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaRecargaTarjeta.Entity
{
    public class ClienteTO
    {
        public int Cliente_id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public String DNI { get; set; }
        public String Telefono { get; set; }
        public int Edad { get; set; }
        public string Email { get; set; }
        public string Distrito { get; set; }


    }
}