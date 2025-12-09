using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevConnectTorloni.Models;

[Table("tb_usuario")]
[Index("Email", Name = "UQ__tb_usuar__AB6E616414857829", IsUnique = true)]
public partial class TbUsuario
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nome_completo")]
    [StringLength(255)]
    public string NomeCompleto { get; set; } = null!;

    [Column("nome_usuario")]
    [StringLength(50)]
    public string NomeUsuario { get; set; } = null!;

    [Column("email")]
    [StringLength(255)]
    public string Email { get; set; } = null!;

    [Column("senha")]
    [StringLength(50)]
    public string Senha { get; set; } = null!;

    [Column("foto_perfil_url")]
    [StringLength(150)]
    public string? FotoPerfilUrl { get; set; }

    [ForeignKey("IdUsuarioSeguidor")]
    [InverseProperty("IdUsuarioSeguidor")]
    public virtual ICollection<TbUsuario> IdUsuarioSeguido { get; set; } = new List<TbUsuario>();

    [ForeignKey("IdUsuarioSeguido")]
    [InverseProperty("IdUsuarioSeguido")]
    public virtual ICollection<TbUsuario> IdUsuarioSeguidor { get; set; } = new List<TbUsuario>();
}
