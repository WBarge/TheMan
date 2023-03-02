CREATE TABLE [dbo].[States] (
    [objid] INT NOT NULL,
    [name]  VARCHAR (20)     NOT NULL,
    [abrv]  CHAR (2)         NOT NULL,
    CONSTRAINT [PK_States] PRIMARY KEY CLUSTERED ([objid] ASC)
);

