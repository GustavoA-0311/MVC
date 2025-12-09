USE db_devcon;


ALTER TABLE Publicacao
ALTER COLUMN IdUsuario INT NULL;

ALTER TABLE Curtida
ADD UNIQUE(IdUsuario, IdPublicacao)



CREATE TABLE tb_seguidor (
    id_usuario_seguido  INT NOT NULL,
    id_usuario_seguidor INT NOT NULL,

    PRIMARY KEY (id_usuario_seguido, id_usuario_seguidor),

    FOREIGN KEY (id_usuario_seguido)  REFERENCES tb_usuario(id),
    FOREIGN KEY (id_usuario_seguidor) REFERENCES tb_usuario(id)
);

