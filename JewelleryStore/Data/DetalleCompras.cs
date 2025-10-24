using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace JewelleryStore.Data;

public partial class DetalleCompras
{
    [Key]
    public int IdDetalleComras { get; set; }

    public int IdCompra { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal PrecioUnitario { get; set; }

    [Column(TypeName = "decimal(18, 3)")]
    public decimal Subtotal { get; set; }

    [ForeignKey("IdCompra")]
    [InverseProperty("DetalleCompras")]
    public virtual Compras IdCompraNavigation { get; set; } = null!;

    [ForeignKey("IdProducto")]
    [InverseProperty("DetalleCompras")]
    public virtual Productos IdProductoNavigation { get; set; } = null!;
}
