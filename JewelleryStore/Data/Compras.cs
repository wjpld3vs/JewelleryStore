using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace JewelleryStore.Data;

public partial class Compras
{
    [Key]
    [Column("CompraID")]
    public int CompraId { get; set; }

    public int IdProveedor { get; set; }

    [StringLength(500)]
    public string NumeroFactura { get; set; } = null!;

    public DateOnly FechaCompras { get; set; }

    public DateOnly FechaRegistro { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Subtotal { get; set; }

    [Column("IVA", TypeName = "decimal(18, 2)")]
    public decimal Iva { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Total { get; set; }

    [StringLength(100)]
    public string Estado { get; set; } = null!;

    [InverseProperty("IdCompraNavigation")]
    public virtual ICollection<DetalleCompras> DetalleCompras { get; set; } = new List<DetalleCompras>();

    [ForeignKey("IdProveedor")]
    [InverseProperty("Compras")]
    public virtual Proveedores? IdProveedorNavigation { get; set; }
}
