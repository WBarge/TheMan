CREATE TABLE [dbo].[Customers] (
    [objid]     INT NOT NULL,
    [number]    INT              NOT NULL,
	[shippingIsSameAsBilling] [bit] NOT NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([objid] ASC)
);

