CREATE TABLE [dbo].[PredefinedOptions] (
    [objid]                  INT            NOT NULL,
    [predefinedProductObjid] INT            NOT NULL,
    [optionObjid]            INT            NOT NULL,
    [marketDescription]      NVARCHAR (255) NULL,
    [deleted]                BIT            NOT NULL,
    CONSTRAINT [PK_PredefinedOptions] PRIMARY KEY CLUSTERED ([objid] ASC),
    CONSTRAINT [FK_PredefinedOptions_PredefinedProducts] FOREIGN KEY ([predefinedProductObjid]) REFERENCES [dbo].[PredefinedProducts] ([objid]),
    CONSTRAINT [FK_PredefinedOptions_ProductOptions] FOREIGN KEY ([optionObjid]) REFERENCES [dbo].[ProductOptions] ([objid])
);



