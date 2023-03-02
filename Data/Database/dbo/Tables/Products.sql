CREATE TABLE [dbo].[Products] (
    [objid]       INT            NOT NULL,
    [name]        NVARCHAR (150) NOT NULL,
    [description] NVARCHAR (255) NOT NULL,
    [deleted]     BIT            NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([objid] ASC),
    CONSTRAINT [FK_Products_PredefinedProducts] FOREIGN KEY ([objid]) REFERENCES [dbo].[PredefinedProducts] ([objid])
);


GO
ALTER TABLE [dbo].[Products] NOCHECK CONSTRAINT [FK_Products_PredefinedProducts];



