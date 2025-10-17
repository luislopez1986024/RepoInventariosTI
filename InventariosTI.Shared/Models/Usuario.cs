
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace InventarioTI.Shared.Models
{
    public class Usuario
    {
        public int Id_Usuarios { get; set; }   // PK
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Contraseña { get; set; } = string.Empty; // 👈 hashed idealmente
        public bool? Estado { get; set; }   // Puede ser NULL
        public DateTime? Fecha_Creacion { get; set; }
        public DateTime? Fecha_Fin { get; set; }

        // FK → Relación con tipo de usuario
        public int Id_TipoU { get; set; }
        // public TipoUsuario? TipoUsuario { get; set; }   // 👈 si luego creas la tabla TipoUsuario
    }
}