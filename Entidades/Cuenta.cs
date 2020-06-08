using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoginRegistro.Entidades
{
    public class Cuenta
    {
        [Key]
        public int CuentaId { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
    }
}
