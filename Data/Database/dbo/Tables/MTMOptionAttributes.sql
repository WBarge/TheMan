CREATE TABLE [dbo].[MTMOptionAttributes] (
    [objid]          INT NOT NULL,
    [mtmOptionObjid]    INT NOT NULL,
    [attributeObjid] INT NOT NULL,
    CONSTRAINT [PK_MTMOptionAttributes] PRIMARY KEY CLUSTERED ([objid] ASC),
    CONSTRAINT [FK_MTMOptionAttributes_Attributes] FOREIGN KEY ([attributeObjid]) REFERENCES [dbo].[Attributes] ([objid]),
	CONSTRAINT [FK_MTMOptionAttributes_MTMOptions] FOREIGN KEY([mtmOptionObjid]) REFERENCES [dbo].[MTMOptions] ([objid])
);



