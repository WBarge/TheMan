CREATE TABLE [dbo].[PhoneNumberType] (
    [objid]           INT NOT NULL,
    [phoneNumbertype] VARCHAR (10)     NOT NULL,
    [deleted]         BIT          NOT NULL,
    CONSTRAINT [PK_PhoneNumberType] PRIMARY KEY CLUSTERED ([objid] ASC)
);

