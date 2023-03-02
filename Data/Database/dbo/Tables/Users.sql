CREATE TABLE [dbo].[Users] (
    [objid]    INT            NOT NULL,
    [username] NVARCHAR (255) NOT NULL,
    [password] NVARCHAR (MAX) NOT NULL,
    [active]   BIT            NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([objid] ASC),
    CONSTRAINT [FK_Users_Customers] FOREIGN KEY ([objid]) REFERENCES [dbo].[Customers] ([objid]) ON UPDATE CASCADE,
    CONSTRAINT [FK_Users_Employees] FOREIGN KEY ([objid]) REFERENCES [dbo].[Employees] ([objid])
);


GO
ALTER TABLE [dbo].[Users] NOCHECK CONSTRAINT [FK_Users_Customers];


GO
ALTER TABLE [dbo].[Users] NOCHECK CONSTRAINT [FK_Users_Employees];



