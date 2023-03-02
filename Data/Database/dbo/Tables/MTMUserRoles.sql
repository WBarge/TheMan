CREATE TABLE [dbo].[MTMUserRoles] (
    [objid]     INT NOT NULL,
    [userObjid] INT NOT NULL,
    [roleObjid] INT NOT NULL,
    CONSTRAINT [PK_MTMUserRoles] PRIMARY KEY CLUSTERED ([objid] ASC)
);

