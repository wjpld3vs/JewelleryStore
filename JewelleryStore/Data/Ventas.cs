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

    [Column("ProductoID")]
    public int? ProductoId { get; set; }

    [Column("VendedorID")]
    public int? VendedorId { get; set; }

    [Column("ClienteID")]
    public int? ClienteId { get; set; }

    [Column("UbicacionID")]
    public int? UbicacionId { get; set; }

    public int? Cantidad { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? MontoTotal { get; set; }

    [ForeignKey("ClienteId")]
    [InverseProperty("Ventas")]
    public virtual Clientes? Cliente { get; set; }

    [ForeignKey("ProductoId")]
    [InverseProperty("Ventas")]
    public virtual Productos? Producto { get; set; }

    [ForeignKey("UbicacionId")]
    [InverseProperty("Ventas")]
    public virtual Ubicaciones? Ubicacion { get; set; }

    [ForeignKey("VendedorId")]
    [InverseProperty("Ventas")]
    public virtual Vendedores? Vendedor { get; set; }
}
