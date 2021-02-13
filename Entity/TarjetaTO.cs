using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaRecargaTarjeta.Entity
{
    public class TarjetaTO
    {
        public int Tarjeta_id { get; set; }
        public int Cliente_id { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public double Saldo { get; set; }
        public String NumeroTarjeta { get; set; }


    }
}