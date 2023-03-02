CREATE TABLE [dbo].[ProductOptions] (
    [objid]       INT NOT NULL,
    [name]        NVARCHAR (150)   NOT NULL,
    [description] NVARCHAR (255)   NOT NULL,
    [deleted]     BIT          NOT NULL,
    CONSTRAINT [PK_ProductOptions] PRIMARY KEY CLUSTERED ([objid] ASC)
);

