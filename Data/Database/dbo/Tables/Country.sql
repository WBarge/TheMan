CREATE TABLE [dbo].[Country] (
    [objid] INT NOT NULL,
    [name]  VARCHAR (50)     NOT NULL,
    [abrv]  VARCHAR (5)      NOT NULL,
    CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED ([objid] ASC)
);

