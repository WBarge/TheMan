CREATE TABLE [dbo].[SnailMailType] (
    [objid]       INT NOT NULL,
    [addressType] VARCHAR (50)     NOT NULL,
    CONSTRAINT [PK_SnailMailType] PRIMARY KEY CLUSTERED ([objid] ASC)
);

