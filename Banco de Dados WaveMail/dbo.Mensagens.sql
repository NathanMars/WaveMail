CREATE TABLE [dbo].[Mensagens] (
    [ID]             INT            IDENTITY (1, 1) NOT NULL,
    [RemetenteID]    INT            NULL,
    [DestinatarioID] INT            NULL,
    [Assunto]        NVARCHAR (100) NOT NULL,
    [Corpo]          NVARCHAR (MAX) NOT NULL,
    [NaLixeiraR]     BIT            DEFAULT ((0)) NULL,
    [NaLixeiraD]     BIT            DEFAULT ((0)) NULL,
    [DeletadoR]      BIT            DEFAULT ((0)) NULL,
    [DeletadoD]      BIT            DEFAULT ((0)) NULL,
    [LidoR]          BIT            DEFAULT ((0)) NULL,
    [LidoD]          BIT            DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Sender] FOREIGN KEY ([RemetenteID]) REFERENCES [dbo].[Usuarios] ([ID]),
    CONSTRAINT [FK_Receiver] FOREIGN KEY ([DestinatarioID]) REFERENCES [dbo].[Usuarios] ([ID])
);

