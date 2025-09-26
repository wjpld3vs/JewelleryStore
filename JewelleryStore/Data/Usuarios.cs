using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace JewelleryStore.Data;

[Index("CorreoUsuario", Name = "CorreoUnico", IsUnique = true)]
[Index("NombreUsuario", Name = "NombreUsuarioUnico", IsUnique = true)]
public partial class Usuarios
{
    [StringLength(500)]
    public string NombreUsuario { get; set; } = null!;

    [StringLength(500)]
    public string ContrasenaUsuario { get; set; } = null!;

    [Key]
    public int IdUsuario { get; set; }

    [StringLength(500)]
    public string CorreoUsuario { get; set; } = null!;

    public bool Recordar { get; set; }
}
