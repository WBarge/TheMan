CREATE TABLE [dbo].[OrderItem] (
    [objid]                  INT             NOT NULL,
    [orderInvoiceObjid]      INT             NOT NULL,
    [predefinedProductObjid] INT             NULL,
    [productObjid]           INT             NULL,
    [price]                  DECIMAL (18, 2) NOT NULL,
    [note]                   TEXT            NULL,
    CONSTRAINT [PK_OrderItem] PRIMARY KEY CLUSTERED ([objid] ASC),
    CONSTRAINT [FK_OrderItem_OrderInvoice] FOREIGN KEY ([orderInvoiceObjid]) REFERENCES [dbo].[OrderInvoice] ([objid])
);



