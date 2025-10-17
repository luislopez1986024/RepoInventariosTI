using System;

namespace InventarioTI.Shared.Models
{
    public class Equipo
    {
        public int Id_Equip { get; set; }   // PK
        public int Placa { get; set; }
        public string Serial { get; set; } = string.Empty;
        public DateTime Fecha_Creacion { get; set; }
        public bool Estado { get; set; }
    }
}