CREATE TABLE [dbo].[ApplicationConfiguration] (
    [objid]         INT NOT NULL,
    [type]          NVARCHAR (MAX)   NOT NULL,
    [configuration] TEXT             NOT NULL,
    CONSTRAINT [PK_ApplicationConfiguration] PRIMARY KEY CLUSTERED ([objid] ASC)
);

