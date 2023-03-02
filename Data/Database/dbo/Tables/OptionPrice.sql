CREATE TABLE [dbo].[OptionPrice] (
    [objid]        INT             NOT NULL,
    [optionObjid]  INT             NOT NULL,
    [flatPrice]    DECIMAL (18, 2) NULL,
    [startDate]    DATETIME        NULL,
    [endDate]      DATETIME        NULL,
    [deleted]      BIT             NOT NULL,
    CONSTRAINT [PK_OptionPrice] PRIMARY KEY CLUSTERED ([objid] ASC),
    CONSTRAINT [FK_OptionPrice_ProductOptions] FOREIGN KEY ([optionObjid]) REFERENCES [dbo].[ProductOptions] ([objid])
);



