using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace JewelleryStore.Data;

public partial class Ventas
{
    [Key]
    [Column("VentaID")]
    public int VentaId { get; set; }

    public DateOnly? Fecha { get; set; }

    [Column("VendedorID")]
    public int? VendedorId { get; set; }

    [Column("ClienteID")]
    public int? ClienteId { get; set; }

    [Column("UbicacionID")]
    public int? UbicacionId { get; set; }

    public int? Cantidad { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Subtotal { get; set; }

    [Column("IVA", TypeName = "decimal(18, 2)")]
    public decimal? Iva { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Total { get; set; }

    [StringLength(100)]
    public string? Estado { get; set; }

    [ForeignKey("ClienteId")]
    [InverseProperty("Ventas")]
    public virtual Clientes? Cliente { get; set; }

    [InverseProperty("IdVentaNavigation")]
    public virtual ICollection<DetalleVentas> DetalleVentas { get; set; } = new List<DetalleVentas>();

    [ForeignKey("UbicacionId")]
    [InverseProperty("Ventas")]
    public virtual Ubicaciones? Ubicacion { get; set; }

    [ForeignKey("VendedorId")]
    [InverseProperty("Ventas")]
    public virtual Vendedores? Vendedor { get; set; }
}
