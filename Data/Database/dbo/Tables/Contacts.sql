CREATE TABLE [dbo].[Contacts] (
    [objid]     INT          NOT NULL,
    [firstName] VARCHAR (40) NOT NULL,
    [lastName]  VARCHAR (40) NOT NULL,
    [deleted]   BIT          NOT NULL,
    CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED ([objid] ASC),
    CONSTRAINT [FK_Contacts_Users] FOREIGN KEY ([objid]) REFERENCES [dbo].[Users] ([objid]) ON UPDATE CASCADE
);


GO
ALTER TABLE [dbo].[Contacts] NOCHECK CONSTRAINT [FK_Contacts_Users];



