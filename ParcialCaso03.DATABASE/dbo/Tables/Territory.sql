CREATE TABLE [dbo].[Territory] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (100) NULL,
    [Area]        NVARCHAR (50)  NULL,
    [Population]  NCHAR (10)     NULL,
    CONSTRAINT [PK_Territory] PRIMARY KEY CLUSTERED ([Id] ASC)
);

