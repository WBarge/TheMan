CREATE TABLE [dbo].[CustomItemOptionAttributes] (
    [objid]                 INT            NOT NULL,
    [customItemOptionObjid] INT            NOT NULL,
    [attributeObjid]        INT            NOT NULL,
    [value]                 NVARCHAR (150) NOT NULL,
    CONSTRAINT [PK_CustomItemOptionAttributes] PRIMARY KEY CLUSTERED ([objid] ASC),
    CONSTRAINT [FK_CustomItemOptionAttributes_CustomItemOptions] FOREIGN KEY ([customItemOptionObjid]) REFERENCES [dbo].[CustomItemOptions] ([objid])
);



