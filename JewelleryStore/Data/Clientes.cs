using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace JewelleryStore.Data;

public partial class Clientes
{
    [Key]
    [Column("ClienteID")]
    public int ClienteId { get; set; }

    [StringLength(100)]
    public string? NombreCliente { get; set; }

    [StringLength(100)]
    public string? Pais { get; set; }

    [InverseProperty("Cliente")]
    public virtual ICollection<Ventas> Ventas { get; set; } = new List<Ventas>();
}
