using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace JewelleryStore.Data;

[Index("NombreUsuario", Name = "NombreUsuarioUnico", IsUnique = true)]
public partial class Usuario
{
    [StringLength(500)]
    public string NombreUsuario { get; set; } = null!;

    [StringLength(500)]
    public string ContrasenaUsuario { get; set; } = null!;

    [Key]
    public int IdUsuario { get; set; }
}
