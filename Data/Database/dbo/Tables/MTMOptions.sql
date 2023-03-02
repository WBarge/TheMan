CREATE TABLE [dbo].[MTMOptions] (
    [objid]        INT NOT NULL,
    [optionObjid]  INT NOT NULL,
    [productObjid] INT NOT NULL,
    CONSTRAINT [PK_MTMOptions] PRIMARY KEY CLUSTERED ([objid] ASC),
    CONSTRAINT [FK_MTMOptions_ProductOptions] FOREIGN KEY ([optionObjid]) REFERENCES [dbo].[ProductOptions] ([objid]),
    CONSTRAINT [FK_MTMOptions_Products] FOREIGN KEY ([productObjid]) REFERENCES [dbo].[Products] ([objid])
);



