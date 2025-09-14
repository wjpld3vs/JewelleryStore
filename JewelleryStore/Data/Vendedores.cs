using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace JewelleryStore.Data;

public partial class Vendedores
{
    [Key]
    [Column("VendedorID")]
    public int VendedorId { get; set; }

    [StringLength(100)]
    public string? NombreVendedor { get; set; }

    [StringLength(100)]
    public string? Pais { get; set; }

    [InverseProperty("Vendedor")]
    public virtual ICollection<Ventas> Ventas { get; set; } = new List<Ventas>();
}
