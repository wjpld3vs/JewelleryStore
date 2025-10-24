using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace JewelleryStore.Data;

public partial class Reembolsos
{
    [Key]
    public int IdReembolso { get; set; }

    public int IdDevolucion { get; set; }

    public DateOnly FechaReembolso { get; set; }

    [StringLength(100)]
    public string MetodoReembolso { get; set; } = null!;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Monto { get; set; }

    [StringLength(100)]
    public string Estado { get; set; } = null!;

    [StringLength(500)]
    public string Observaciones { get; set; } = null!;

    [ForeignKey("IdDevolucion")]
    [InverseProperty("Reembolsos")]
    public virtual Devoluciones IdDevolucionNavigation { get; set; } = null!;
}
