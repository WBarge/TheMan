CREATE TABLE [dbo].[PhoneNumbers] (
    [objid]           INT         NOT NULL,
    [numberTypeObjid] INT         NOT NULL,
    [number]          CHAR (16)   NOT NULL,
    [countryCode]     VARCHAR (5) NOT NULL,
    [deleted]         BIT         NOT NULL,
    CONSTRAINT [PK_PhoneNumbers] PRIMARY KEY CLUSTERED ([objid] ASC),
    CONSTRAINT [FK_PhoneNumbers_PhoneNumberType] FOREIGN KEY ([numberTypeObjid]) REFERENCES [dbo].[PhoneNumberType] ([objid])
);



