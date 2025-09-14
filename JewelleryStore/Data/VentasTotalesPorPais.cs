using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace JewelleryStore.Data;

[Keyless]
public partial class VentasTotalesPorPais
{
    [StringLength(100)]
    public string? Pais { get; set; }

    [Column(TypeName = "decimal(38, 2)")]
    public decimal? TotalVentas { get; set; }
}
