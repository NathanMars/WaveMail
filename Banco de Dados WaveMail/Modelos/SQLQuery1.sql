CREATE TABLE Usuarios (
    ID INTEGER PRIMARY KEY,
    Usuario NVARCHAR (50),
    Senha NVARCHAR (50)
);

CREATE TABLE Mensagens (
    ID INTEGER PRIMARY KEY,
    RemetenteID INTEGER,
    DestinatarioID INTEGER,
    Assunto NVARCHAR (100),
    Corpo NVARCHAR (MAX),
    NaLixeiraR BIT,
    NaLixeiraD BIT,
    DeletadoR BIT,
    DeletadoD BIT,
    LidoR BIT,
    LidoD BIT
);

CREATE TABLE UsuarioMensagemRelacionamento (
    ID INTEGER PRIMARY KEY,
    UsuarioID INTEGER,
    MensagemID INTEGER,
    Destinatario NVARCHAR (50),
    Entrada BIT,
    Saida BIT
);
 
ALTER TABLE UsuarioMensagemRelacionamento ADD CONSTRAINT FK_UsuarioMensagemRelacionamento_2
    FOREIGN KEY (UsuarioID)
    REFERENCES Usuarios (ID)
    ON DELETE CASCADE;
 
ALTER TABLE UsuarioMensagemRelacionamento ADD CONSTRAINT FK_UsuarioMensagemRelacionamento_3
    FOREIGN KEY (MensagemID)
    REFERENCES Mensagens (ID)
    ON DELETE CASCADE;