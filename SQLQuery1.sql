CREATE TABLE [dbo].[Medicos] (
    [IdMedico]      INT            IDENTITY (1, 1) NOT NULL,
    [Cpf]           NVARCHAR (MAX) NULL,
    [RG]           NVARCHAR (MAX) NULL,
	[Crm]           NVARCHAR (MAX) NULL,
	[Telefone]      NVARCHAR (MAX) NULL,
    [Email]         NVARCHAR (MAX) NULL,
    [Nascimento] NVARCHAR (MAX) NULL,
	[Especialidade] NVARCHAR (MAX) NULL,
    [CriadoEm]      DATETIME2 (7)  NOT NULL,
    [Bairro]        NVARCHAR (MAX) NULL,
    [Cep]           NVARCHAR (MAX) NULL,
    [Cidade]        NVARCHAR (MAX) NULL,
    [Estado]        NVARCHAR (MAX) NULL,
    [Nome]          NVARCHAR (MAX) NULL,
    [Numero]        NVARCHAR (MAX) NULL,
    [Rua]           NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Medicos] PRIMARY KEY CLUSTERED ([IdMedico] ASC)
);
