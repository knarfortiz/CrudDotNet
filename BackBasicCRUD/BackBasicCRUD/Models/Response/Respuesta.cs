using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackBasicCRUD.Models.Response
{
    public class Respuesta
    {
        public int Exito { get; set; }
        public string Mensaje { get; set; }
        //public List<Cerveza> Data { get; set; }
        public object Data { get; set; }

        public Respuesta()
        {
            Exito = 0;
        }
    }
}
