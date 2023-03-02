CREATE TABLE [dbo].[CustomItemAttributes] (
    [objid]          INT            NOT NULL,
    [orderItemObjid] INT            NOT NULL,
    [attributeObjid] INT            NOT NULL,
    [value]          NVARCHAR (150) NOT NULL,
    CONSTRAINT [PK_CustomItemAttributes] PRIMARY KEY CLUSTERED ([objid] ASC),
    CONSTRAINT [FK_CustomItemAttributes_OrderItem] FOREIGN KEY ([orderItemObjid]) REFERENCES [dbo].[OrderItem] ([objid])
);



