using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace JewelleryStore.Data;

public partial class Productos
{
    [Key]
    [Column("ProductoID")]
    public int ProductoId { get; set; }

    [StringLength(100)]
    public string NombreProducto { get; set; } = null!;

    [Column("CategoriaID")]
    public int? CategoriaId { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Precio { get; set; }

    [ForeignKey("CategoriaId")]
    [InverseProperty("Productos")]
    public virtual Categorias? Categoria { get; set; }

    [InverseProperty("Producto")]
    public virtual ICollection<Imagenes> Imagenes { get; set; } = new List<Imagenes>();

    [InverseProperty("Producto")]
    public virtual ICollection<Ventas> Ventas { get; set; } = new List<Ventas>();
}
