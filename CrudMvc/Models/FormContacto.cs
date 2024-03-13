using System;
using System.Collections.Generic;

namespace CrudMvc.Models;

public partial class FormContacto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Mensaje { get; set; } = null!;
}
