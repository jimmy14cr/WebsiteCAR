using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegisterLoginCAR.Models
{
    public class RegistroModelo
    {
        public int IdRegistro { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Su número de Identificación es requerido.")]
        public int Identificacion { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Su nombre es requerido.")]
        public string Nombre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Su apellido es requerido.")]
        public string Apellidos { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La contraseña es requerida.")]
        public string Contrasena { get; set; }

        public string ConfirmarContrasena { get; set; }


    }
}