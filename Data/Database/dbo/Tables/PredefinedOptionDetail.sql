CREATE TABLE [dbo].[PredefinedOptionDetail] (
    [objid]                 INT            NOT NULL,
    [predefinedOptionObjid] INT            NOT NULL,
    [attribuiteObjid]       INT            NOT NULL,
    [value]                 NVARCHAR (150) NOT NULL,
    [deleted]               BIT            NOT NULL,
    CONSTRAINT [PK_OptionDetail] PRIMARY KEY CLUSTERED ([objid] ASC),
    CONSTRAINT [FK_PredefinedOptionDetail_Attributes] FOREIGN KEY ([attribuiteObjid]) REFERENCES [dbo].[Attributes] ([objid]),
    CONSTRAINT [FK_PredefinedOptionDetail_PredefinedOptions] FOREIGN KEY ([predefinedOptionObjid]) REFERENCES [dbo].[PredefinedOptions] ([objid])
);



