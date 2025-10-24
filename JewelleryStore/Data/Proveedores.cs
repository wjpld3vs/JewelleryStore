using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace JewelleryStore.Data;

public partial class Proveedores
{
    [Key]
    public int IdProveedor { get; set; }

    [StringLength(500)]
    public string NombreProveedor { get; set; } = null!;

    [StringLength(500)]
    public string TelefonoProveedor { get; set; } = null!;

    [StringLength(500)]
    public string DireccionProveedor { get; set; } = null!;

    public bool? Activo { get; set; }

    [InverseProperty("IdProveedorNavigation")]
    public virtual ICollection<Compras> Compras { get; set; } = new List<Compras>();
}
