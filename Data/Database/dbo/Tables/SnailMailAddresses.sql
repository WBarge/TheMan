CREATE TABLE [dbo].[SnailMailAddresses] (
    [objid]              INT          NOT NULL,
    [line1]              VARCHAR (40) NOT NULL,
    [line2]              VARCHAR (40) NULL,
    [city]               VARCHAR (40) NOT NULL,
    [stateObjId]         INT          NOT NULL,
    [countryObjid]       INT          NOT NULL,
    [zip]                CHAR (12)    NOT NULL,
    [snailMailTypeObjid] INT          NOT NULL,
    [deleted]            BIT          NOT NULL,
    CONSTRAINT [PK_SnailMailAddresses] PRIMARY KEY CLUSTERED ([objid] ASC),
    CONSTRAINT [FK_SnailMailAddresses_Country] FOREIGN KEY ([countryObjid]) REFERENCES [dbo].[Country] ([objid]),
    CONSTRAINT [FK_SnailMailAddresses_SnailMailType] FOREIGN KEY ([snailMailTypeObjid]) REFERENCES [dbo].[SnailMailType] ([objid]),
    CONSTRAINT [FK_SnailMailAddresses_States] FOREIGN KEY ([stateObjId]) REFERENCES [dbo].[States] ([objid])
);



