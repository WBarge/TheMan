CREATE TABLE [dbo].[ProductAttributeValues] (
    [objid]                  INT            NOT NULL,
    [value]                  NVARCHAR (150) NOT NULL,
    [description]            NVARCHAR (255) NOT NULL,
    [defaultValue]           BIT            NOT NULL,
    [deleted]                BIT            NOT NULL,
    [productAttributesObjid] INT            NOT NULL,
    CONSTRAINT [PK_AttributeValues] PRIMARY KEY CLUSTERED ([objid] ASC),
    CONSTRAINT [FK_ProductAttributeValues_Attributes] FOREIGN KEY ([productAttributesObjid]) REFERENCES [dbo].[MTMProductAttributes] ([objid])
);





