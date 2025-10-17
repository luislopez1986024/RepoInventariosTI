using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventarioTI.Shared.Models;

namespace InventarioTI.Shared.Models
{
    public class Area
    {
       public int Id_Area { get; set; }   // PK
       public string Nombre { get; set; } = string.Empty;
       public bool Estado { get; set; }
       public DateTime Fecha_Creacion { get; set; }
       public DateTime Fecha_Fin { get; set; }
       public string Centro_costos { get; set; } = string.Empty;

    }

}
