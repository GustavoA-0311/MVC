using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevConnectTorloni.Models;

[Table("tb_comentario")]
public partial class TbComentario
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("texto")]
    [StringLength(255)]
    public string Texto { get; set; } = null!;

    [Column("data_comentario")]
    public DateOnly DataComentario { get; set; }
}
