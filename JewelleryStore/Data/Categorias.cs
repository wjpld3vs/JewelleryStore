using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace JewelleryStore.Data;

public partial class Categorias
{
    [Key]
    [Column("CategoriaID")]
    public int CategoriaId { get; set; }

    [StringLength(50)]
    public string NombreCategoria { get; set; } = null!;

    [InverseProperty("Categoria")]
    public virtual ICollection<Productos> Productos { get; set; } = new List<Productos>();
}
