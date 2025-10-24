using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace JewelleryStore.Data;

public partial class DetalleDevoluciones
{
    [Key]
    public int IdDetalleDevolucion { get; set; }

    public int IdDevolucion { get; set; }

    public int IdDetalleVenta { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal PrecioUnitario { get; set; }

    [StringLength(500)]
    public string MorivoDevolucion { get; set; } = null!;

    [StringLength(500)]
    public string EstadoDevolucion { get; set; } = null!;

    [ForeignKey("IdDetalleVenta")]
    [InverseProperty("DetalleDevoluciones")]
    public virtual DetalleVentas IdDetalleVentaNavigation { get; set; } = null!;

    [ForeignKey("IdDevolucion")]
    [InverseProperty("DetalleDevoluciones")]
    public virtual Devoluciones IdDevolucionNavigation { get; set; } = null!;

    [ForeignKey("IdProducto")]
    [InverseProperty("DetalleDevoluciones")]
    public virtual Productos IdProductoNavigation { get; set; } = null!;
}
