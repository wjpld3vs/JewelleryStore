using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace JewelleryStore.Data;

public partial class Devoluciones
{
    [Key]
    public int IdDevolucion { get; set; }

    public int IdVenta { get; set; }

    public DateOnly FechaDevolucion { get; set; }

    public DateOnly FechaRegistro { get; set; }

    [StringLength(500)]
    public string Motivo { get; set; } = null!;

    [StringLength(100)]
    public string Estado { get; set; } = null!;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal TotalReembolso { get; set; }

    [InverseProperty("IdDevolucionNavigation")]
    public virtual ICollection<DetalleDevoluciones> DetalleDevoluciones { get; set; } = new List<DetalleDevoluciones>();

    [InverseProperty("IdDevolucionNavigation")]
    public virtual ICollection<Reembolsos> Reembolsos { get; set; } = new List<Reembolsos>();
}
