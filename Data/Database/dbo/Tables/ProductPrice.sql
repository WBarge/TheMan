CREATE TABLE [dbo].[ProductPrice] (
    [objid]        INT             NOT NULL,
    [productObjid] INT             NOT NULL,
    [flatPrice]    DECIMAL (18, 2) NULL,
    [formulaPrice] NVARCHAR (4000) NULL,
    [startDate]    DATETIME        NULL,
    [endDate]      DATETIME        NULL,
    [deleted]      BIT             NULL,
    CONSTRAINT [PK_ProductPrice] PRIMARY KEY CLUSTERED ([objid] ASC),
    CONSTRAINT [FK_ProductPrice_Products] FOREIGN KEY ([productObjid]) REFERENCES [dbo].[Products] ([objid])
);



