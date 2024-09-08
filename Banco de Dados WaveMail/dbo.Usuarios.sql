CREATE TABLE [dbo].[Usuarios] (
    [ID]      INT           IDENTITY (1, 1) NOT NULL,
    [Usuario] NVARCHAR (50) NOT NULL,
    [Senha]   NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

