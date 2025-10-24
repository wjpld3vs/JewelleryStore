using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace JewelleryStore.Data;

public partial class DetalleVentas
{
    [Key]
    public int IdDetalleVentas { get; set; }

    public int IdVenta { get; set; }

    public int IdProducto { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Cantidad { get; set; }

    public int PrecioUnitario { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Subtotal { get; set; }

    [InverseProperty("IdDetalleVentaNavigation")]
    public virtual ICollection<DetalleDevoluciones> DetalleDevoluciones { get; set; } = new List<DetalleDevoluciones>();

    [ForeignKey("IdProducto")]
    [InverseProperty("DetalleVentas")]
    public virtual Productos IdProductoNavigation { get; set; } = null!;

    [ForeignKey("IdVenta")]
    [InverseProperty("DetalleVentas")]
    public virtual Ventas IdVentaNavigation { get; set; } = null!;
}
