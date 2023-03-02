CREATE TABLE [dbo].[MTMSnailMail] (
    [objid]                INT NOT NULL,
    [contactObjid]         INT NOT NULL,
    [snailMailAddessObjid] INT NOT NULL,
    [defaultAddress]       BIT NOT NULL,
    CONSTRAINT [PK_MTMSnailMail] PRIMARY KEY CLUSTERED ([objid] ASC),
    CONSTRAINT [FK_MTMSnailMail_Contacts] FOREIGN KEY ([contactObjid]) REFERENCES [dbo].[Contacts] ([objid]),
    CONSTRAINT [FK_MTMSnailMail_SnailMailAddresses] FOREIGN KEY ([snailMailAddessObjid]) REFERENCES [dbo].[SnailMailAddresses] ([objid])
);



