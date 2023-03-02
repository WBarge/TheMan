CREATE TABLE [dbo].[EMailAddresses] (
    [objid]          INT           NOT NULL,
    [contactObjid]   INT           NOT NULL,
    [address]        VARCHAR (255) NOT NULL,
    [defaultAddress] BIT           NOT NULL,
    [deleted]        BIT           NOT NULL,
    CONSTRAINT [PK_EMailAddresses] PRIMARY KEY CLUSTERED ([objid] ASC),
    CONSTRAINT [FK_EMailAddresses_Contacts] FOREIGN KEY ([contactObjid]) REFERENCES [dbo].[Contacts] ([objid])
);



