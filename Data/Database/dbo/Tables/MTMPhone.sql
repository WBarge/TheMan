CREATE TABLE [dbo].[MTMPhone] (
    [objid]            INT NOT NULL,
    [contactObjid]     INT NOT NULL,
    [phoneNumberObjid] INT NOT NULL,
    [defaultNumber]    BIT NOT NULL,
    CONSTRAINT [PK_MTMPhone] PRIMARY KEY CLUSTERED ([objid] ASC),
    CONSTRAINT [FK_MTMPhone_Contacts] FOREIGN KEY ([contactObjid]) REFERENCES [dbo].[Contacts] ([objid]),
    CONSTRAINT [FK_MTMPhone_PhoneNumbers] FOREIGN KEY ([phoneNumberObjid]) REFERENCES [dbo].[PhoneNumbers] ([objid])
);



