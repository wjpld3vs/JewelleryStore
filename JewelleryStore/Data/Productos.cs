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

    public int? StockActual { get; set; }

    public bool? Activo { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Precio { get; set; }

    [ForeignKey("CategoriaId")]
    [InverseProperty("Productos")]
    public virtual Categorias? Categoria { get; set; }

    [InverseProperty("IdProductoNavigation")]
    public virtual ICollection<DetalleCompras> DetalleCompras { get; set; } = new List<DetalleCompras>();

    [InverseProperty("IdProductoNavigation")]
    public virtual ICollection<DetalleDevoluciones> DetalleDevoluciones { get; set; } = new List<DetalleDevoluciones>();

    [InverseProperty("IdProductoNavigation")]
    public virtual ICollection<DetalleVentas> DetalleVentas { get; set; } = new List<DetalleVentas>();

    [InverseProperty("Producto")]
    public virtual ICollection<Imagenes> Imagenes { get; set; } = new List<Imagenes>();
}
