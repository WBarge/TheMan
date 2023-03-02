CREATE TABLE [dbo].[PredefinedProductDetail] (
    [objid]                  INT            NOT NULL,
    [predefinedProductObjid] INT            NOT NULL,
    [attributeObjid]         INT            NOT NULL,
    [value]                  NVARCHAR (150) NOT NULL,
    [deleted]                BIT            NOT NULL,
    CONSTRAINT [PK_ProductDetail] PRIMARY KEY CLUSTERED ([objid] ASC),
    CONSTRAINT [FK_PredefinedProductDetail_Attributes] FOREIGN KEY ([attributeObjid]) REFERENCES [dbo].[Attributes] ([objid]),
    CONSTRAINT [FK_PredefinedProductDetail_PredefinedProducts] FOREIGN KEY ([predefinedProductObjid]) REFERENCES [dbo].[PredefinedProducts] ([objid])
);



