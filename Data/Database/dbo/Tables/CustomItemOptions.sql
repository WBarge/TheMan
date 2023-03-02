CREATE TABLE [dbo].[CustomItemOptions] (
    [objid]              INT  NOT NULL,
    [orderItemObjid]     INT  NOT NULL,
    [productOptionObjid] INT  NOT NULL,
    [note]               TEXT NULL,
    CONSTRAINT [PK_CustomItemOptions] PRIMARY KEY CLUSTERED ([objid] ASC),
    CONSTRAINT [FK_CustomItemOptions_OrderItem] FOREIGN KEY ([orderItemObjid]) REFERENCES [dbo].[OrderItem] ([objid])
);



