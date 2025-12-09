

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevConnectTorloni.Models;

[Table("tb_publi")]
public partial class TbPubli
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("descricao")]
    [StringLength(255)]
    public string Descricao { get; set; } = null!;

    [Column("imagem_url")]
    [StringLength(255)]
    public string? ImagemUrl { get; set; }

    [Column("data_publi")]
    public DateOnly DataPubli { get; set; }

    [Column("id_usuario")]
    public int? IdUsuario { get; set; }

    [Column("quantidade_curtidas")]
    public int? QuantidadeCurtidas { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("TbPubli")]
    public virtual TbUsuario? IdUsuarioNavigation { get; set; }

    [InverseProperty("IdPubliNavigation")]
    public virtual ICollection<TbComentario> TbComentario { get; set; } = new List<TbComentario>();

    [InverseProperty("IdPubliNavigation")]
    public virtual ICollection<TbCurtida> TbCurtida { get; set; } = new List<TbCurtida>();
}
