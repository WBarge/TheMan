CREATE TABLE [dbo].[MTMProductAttributes] (
    [objid]          INT NOT NULL,
    [productObjid]   INT NOT NULL,
    [attributeObjid] INT NOT NULL,
    CONSTRAINT [PK_MTMProductAttributes] PRIMARY KEY CLUSTERED ([objid] ASC),
    CONSTRAINT [FK_MTMProductAttributes_Attributes] FOREIGN KEY ([attributeObjid]) REFERENCES [dbo].[Attributes] ([objid]),
    CONSTRAINT [FK_MTMProductAttributes_Products] FOREIGN KEY ([productObjid]) REFERENCES [dbo].[Products] ([objid])
);



