using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevConnectTorloni.Models;

[PrimaryKey("IdUsuario", "IdPubli")]
[Table("tb_curtida")]
[Index("IdUsuario", "IdPubli", Name = "UQ__tb_curti__B502648D6CCD35E8", IsUnique = true)]
[Index("IdUsuario", "IdPubli", Name = "UQ__tb_curti__B502648D9969E497", IsUnique = true)]
public partial class TbCurtida
{
    [Column("id")]
    public int Id { get; set; }

    [Key]
    [Column("id_usuario")]
    public int IdUsuario { get; set; }

    [Key]
    [Column("id_publi")]
    public int IdPubli { get; set; }

    [ForeignKey("IdPubli")]
    [InverseProperty("TbCurtida")]
    public virtual TbPubli IdPubliNavigation { get; set; } = null!;

    [ForeignKey("IdUsuario")]
    [InverseProperty("TbCurtida")]
    public virtual TbUsuario IdUsuarioNavigation { get; set; } = null!;
}

