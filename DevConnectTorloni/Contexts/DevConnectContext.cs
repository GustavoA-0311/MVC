using System;
using System.Collections.Generic;
using DevConnect.Models;
using Microsoft.EntityFrameworkCore;

namespace DevConnectTorloni.Models
{
    public partial class DevConnectContext : DbContext
    {
        public DevConnectContext()
        {
        }

        public DevConnectContext(DbContextOptions<DevConnectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbComentarios> TbComentarios { get; set; }
        public virtual DbSet<TbCurtidas> TbCurtidas { get; set; }
        public virtual DbSet<TbPublicacao> TbPublicacao { get; set; }
        public virtual DbSet<TbUsuario> TbUsuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Name=DevCon_SA");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbComentarios>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tb_comentarios");

                entity.HasOne(d => d.IdPublicacaoNavigation)
                    .WithMany(p => p.TbComentarios)
                    .HasConstraintName("FK_tb_comentarios_publicacao");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.TbComentarios)
                    .HasConstraintName("FK_tb_comentarios_usuario");
            });

            modelBuilder.Entity<TbCurtidas>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tb_curtidas");

                entity.HasOne(d => d.IdPublicacaoNavigation)
                    .WithMany(p => p.TbCurtidas)
                    .HasConstraintName("FK_tb_curtidas_publicacao");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.TbCurtidas)
                    .HasConstraintName("FK_tb_curtidas_usuario");
            });

            modelBuilder.Entity<TbPublicacao>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tb_publicacao");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.TbPublicacao)
                    .HasConstraintName("FK_tb_publicacao_usuario");
            });

            modelBuilder.Entity<TbUsuario>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tb_usuario");

                // RELACIONAMENTO MANY-TO-MANY — TABELA tb_seguidor
                entity.HasMany(d => d.IdUsuarioSeguir)
                    .WithMany(p => p.IdUsuarioSeguida)
                    .UsingEntity<Dictionary<string, object>>(
                        "TbSeguidor",
                        r => r.HasOne<TbUsuario>()
                            .WithMany()
                            .HasForeignKey("IdUsuarioSeguir")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_tb_seguidor_seguir"),

                        l => l.HasOne<TbUsuario>()
                            .WithMany()
                            .HasForeignKey("IdUsuarioSeguida")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_tb_seguidor_seguida"),

                        j =>
                        {
                            j.HasKey("IdUsuarioSeguir", "IdUsuarioSeguida")
                                .HasName("PK_tb_seguidor");

                            j.ToTable("tb_seguidor");

                            j.IndexerProperty<int>("IdUsuarioSeguir")
                                .HasColumnName("id_usuario_seguir");

                            j.IndexerProperty<int>("IdUsuarioSeguida")
                                .HasColumnName("id_usuario_seguida");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
