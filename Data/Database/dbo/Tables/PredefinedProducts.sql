CREATE TABLE [dbo].[PredefinedProducts] (
    [objid]             INT NOT NULL,
    [productObjid]      INT NOT NULL,
    [price]             DECIMAL (18, 2)  NOT NULL,
    [marketDescription] NVARCHAR (255)   NULL,
    [deleted]           BIT          NOT NULL,
    [quantity] INT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_PredefinedProducts] PRIMARY KEY CLUSTERED ([objid] ASC)
);

