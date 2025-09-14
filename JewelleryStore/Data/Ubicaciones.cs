using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace JewelleryStore.Data;

public partial class Ubicaciones
{
    [Key]
    [Column("UbicacionID")]
    public int UbicacionId { get; set; }

    [StringLength(100)]
    public string? Ciudad { get; set; }

    [StringLength(100)]
    public string? Pais { get; set; }

    [InverseProperty("Ubicacion")]
    public virtual ICollection<Ventas> Ventas { get; set; } = new List<Ventas>();
}
