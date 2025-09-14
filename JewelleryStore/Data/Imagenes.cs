using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace JewelleryStore.Data;

public partial class Imagenes
{
    [Key]
    [Column("ImagenID")]
    public int ImagenId { get; set; }

    [Column("ProductoID")]
    public int? ProductoId { get; set; }

    [Column("URL")]
    [StringLength(255)]
    public string? Url { get; set; }

    [ForeignKey("ProductoId")]
    [InverseProperty("Imagenes")]
    public virtual Productos? Producto { get; set; }
}
