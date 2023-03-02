CREATE TABLE [dbo].[OptionsAttributeValues] (
    [objid]                  INT            NOT NULL,
    [value]                  NVARCHAR (150) NOT NULL,
    [description]            NVARCHAR (255) NOT NULL,
    [defaultValue]           BIT            NOT NULL,
    [deleted]                BIT            NOT NULL,
    [optionsAttributesObjid] INT            NOT NULL,
    CONSTRAINT [PK_OptionsAttributeValues] PRIMARY KEY CLUSTERED ([objid] ASC),
    CONSTRAINT [FK_OptionsAttributeValues_MTMOptionAttributes] FOREIGN KEY ([optionsAttributesObjid]) REFERENCES [dbo].[MTMOptionAttributes] ([objid])
);



