using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace JewelleryStore.Data;

[Keyless]
public partial class DetallesCompletosVentasImagenes
{
    [Column("VentaID")]
    public int VentaId { get; set; }

    public DateOnly? Fecha { get; set; }

    [StringLength(100)]
    public string? NombreCliente { get; set; }

    [StringLength(100)]
    public string? NombreVendedor { get; set; }

    [StringLength(100)]
    public string NombreProducto { get; set; } = null!;

    public int? Cantidad { get; set; }

    [Column("MontoTotalEnDOP", TypeName = "numeric(15, 4)")]
    public decimal? MontoTotalEnDop { get; set; }

    [StringLength(100)]
    public string? Ciudad { get; set; }

    [StringLength(100)]
    public string? Pais { get; set; }

    [Column("URL")]
    [StringLength(255)]
    public string? Url { get; set; }
}
