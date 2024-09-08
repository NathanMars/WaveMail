CREATE TABLE [dbo].[UsuarioMensagemRelacionamento] (
    [ID]           INT           IDENTITY (1, 1) NOT NULL,
    [UsuarioID]    INT           NULL,
    [MensagemID]   INT           NULL,
    [Destinatario] NVARCHAR (50) NOT NULL,
    [Entrada]      BIT           DEFAULT ((0)) NULL,
    [Saida]        BIT           DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_User] FOREIGN KEY ([UsuarioID]) REFERENCES [dbo].[Usuarios] ([ID]),
    CONSTRAINT [FK_Message] FOREIGN KEY ([MensagemID]) REFERENCES [dbo].[Mensagens] ([ID])
);

